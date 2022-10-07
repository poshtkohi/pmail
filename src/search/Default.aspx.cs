/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Search
{
	/// <summary>
	/// Summary description for _Default.
	/// </summary>
	public class _Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtQuery;
		protected System.Web.UI.WebControls.Label lblQueryType;
		protected System.Web.UI.WebControls.DropDownList cboDirectory;
		protected System.Web.UI.WebControls.Label lblDirectory;
		protected System.Web.UI.WebControls.DropDownList cboQueryType;
		protected System.Web.UI.WebControls.Label lblSortOrder;
		protected System.Web.UI.WebControls.DropDownList cboSortBy;
		protected System.Web.UI.WebControls.DropDownList cboSortOrder;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid dgResultsGrid;
		protected System.Web.UI.WebControls.Label lblResultCount;
		protected System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		protected System.Data.OleDb.OleDbDataAdapter dbAdapter;
		protected System.Data.OleDb.OleDbConnection dbConnection;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqValQuery;
		protected System.Web.UI.WebControls.Label lblQuery;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dbAdapter = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dbConnection = new System.Data.OleDb.OleDbConnection();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.dgResultsGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgResultsGrid_PageIndexChanged);
			// 
			// dbAdapter
			// 
			this.dbAdapter.SelectCommand = this.oleDbSelectCommand1;
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.Connection = this.dbConnection;
			// 
			// dbConnection
			// 
			this.dbConnection.ConnectionString = "Provider=MSIDXS.1;Integrated Security .=\"\";Data Source=Web";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			this.Search();
		}

		private void dgResultsGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			// Update the current page index.
			this.dgResultsGrid.CurrentPageIndex = e.NewPageIndex;
			this.Search();
		}

		/// <summary>
		/// Gets the command string for the search.
		/// <seealso cref="Search"/>
		/// </summary>
		private string Command
		{
			get
			{
				// Construct the base query.
				string query = String.Format(@"
SELECT Rank, VPath, DocTitle, Filename, Characterization, Write
FROM SCOPE('DEEP TRAVERSAL OF ""{0}""')
WHERE NOT CONTAINS(VPath, '""_vti_"" OR "".config""')",
					this.cboDirectory.SelectedItem.Value);

				// Conditionally construct the rest of the WHERE clause.
				string type = this.cboQueryType.SelectedItem.Value.ToLower();
				string fmt = @" AND (CONTAINS('{0}') OR CONTAINS(DocTitle, '{0}'))";

				// Get the query string and remove all semi-colons, which should stop
				// attempt to run malicious SQL code.
				string text = this.txtQuery.Text.Replace(";", "");
				if (type == "all" || type == "any" || type == "boolean")
				{
					string[] words = text.Split(' ');
					int len = words.Length;
					for (int i=0; i<len; i++)
					{
						string word = words[i];
						if (type == "boolean")
							if (String.Compare(word, "and", true) == 0 ||
								String.Compare(word, "or", true) == 0 ||
								String.Compare(word, "not", true) == 0 ||
								String.Compare(word, "near", true) == 0)
								continue;

						words[i] = String.Format(@"""{0}""", word);
						if (i < len - 1)
						{
							if (type == "all") words[i] += " AND";
							else if (type == "any") words[i] += " OR";
						}
					}

					query += String.Format(fmt, String.Join(" ", words));
				}
				else if (type == "exact")
				{
					query += String.Format(fmt, text);
				}
				else if (type == "natural")
				{
					query += String.Format(" AND FREETEXT('{0}')", text);
				}

				// Sort the results.
				query += String.Format(" ORDER BY {0} {1}",
					this.cboSortBy.SelectedItem.Value, this.cboSortOrder.SelectedItem.Value);

				Trace.Write("Query", query);
				return query;
			}
		}

		/// <summary>
		/// Perform the search.
		/// </summary>
		private void Search()
		{
			// Create a new DataSet and fill it.
			try
			{
				this.dbAdapter.SelectCommand.CommandText = Command;
				DataSet ds = new DataSet("Results");
				this.dbAdapter.Fill(ds);

				this.lblResultCount.ForeColor = Color.Black;
				int rows = ds.Tables[0].Rows.Count;
				this.lblResultCount.Text = String.Format("{0} document{1} found{2}",
					rows, rows == 1 ?  " was" : "s were", rows == 0 ? "." : ":");

				// Bind the resulting DataSet.
				this.dgResultsGrid.DataSource = ds;
				this.dgResultsGrid.DataBind();

				// If all was bound well, display the DataGrid.
				this.dgResultsGrid.Visible = (rows > 0);
			}
			catch (Exception ex)
			{
				this.lblResultCount.ForeColor = Color.Red;
				this.lblResultCount.Text = String.Format("Unable to retreive a list " +
					"of documents for the specified query: {0}", ex.Message);

				this.dgResultsGrid.Visible = false;
			}
			finally
			{
				this.lblResultCount.Visible = true;
			}
		}

		/// <summary>
		/// Get the appropriate title from the <see cref="DataGridItem.DataItem"/>
		/// bound to the <see cref="DataGrid"/>.
		/// </summary>
		/// <param name="value">A <see cref="DataGridItem.DataItem"/> for the current record.</param>
		/// <returns>Either the "DocTitle" or "Filename" respectively.</returns>
		protected object GetTitle(object value)
		{
			string title = DataBinder.Eval(value, "DocTitle") as string;
			if (title != null  && title.Length > 0) return title;

			return DataBinder.Eval(value, "Filename");
		}

		/// <summary>
		/// Encodes the characterization since some malformed text could cause
		/// the web browser to not render the remaining elements.
		/// </summary>
		/// <param name="value">A <see cref="DataGridItem.DataItem"/> for the current record.</param>
		/// <returns>The encoded characterization.</returns>
		protected string GetCharacterization(object value)
		{
			return Server.HtmlEncode(DataBinder.Eval(value, "Characterization") as string);
		}
	}
}
