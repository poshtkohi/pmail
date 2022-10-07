<%@ Page language="c#" Codebehind="ShowAddressBook.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.ShowAddressBook" %>
<HTML>
	<HEAD>
		<title>Address Book</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script language="JavaScript">
<!--
function FP_preloadImgs() {//v1.0
 var d=document,a=arguments; if(!d.FP_imgs) d.FP_imgs=new Array();
 for(var i=0; i<a.length; i++) { d.FP_imgs[i]=new Image; d.FP_imgs[i].src=a[i]; }
}

function FP_swapImg() {//v1.0
 var doc=document,args=arguments,elm,n; doc.$imgSwaps=new Array(); for(n=2; n<args.length;
 n+=2) { elm=FP_getObjectByID(args[n]); if(elm) { doc.$imgSwaps[doc.$imgSwaps.length]=elm;
 elm.$src=elm.src; elm.src=args[n+1]; } }
}

function FP_getObjectByID(id,o) {//v1.0
 var c,el,els,f,m,n; if(!o)o=document; if(o.getElementById) el=o.getElementById(id);
 else if(o.layers) c=o.layers; else if(o.all) el=o.all[id]; if(el) return el;
 if(o.id==id || o.name==id) return o; if(o.childNodes) c=o.childNodes; if(c)
 for(n=0; n<c.length; n++) { el=FP_getObjectByID(id,c[n]); if(el) return el; }
 f=o.forms; if(f) for(n=0; n<f.length; n++) { els=f[n].elements;
 for(m=0; m<els.length; m++){ el=FP_getObjectByID(id,els[n]); if(el) return el; } }
 return null;
}
// -->
		</script>
		<style type="text/css">
		.copy { FONT-WEIGHT: 900; FONT-SIZE: 9px; COLOR: #f4fcdd; FONT-FAMILY: Tahoma }
		.boxes1 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		.boxes2 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		.boxes3 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		.boxes31 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		.boxes21 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		.boxes4 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		A { COLOR: #039; TEXT-DECORATION: none }
		A:visited { COLOR: #039; TEXT-DECORATION: none }
		A:hover { TEXT-DECORATION: underline }
		BODY { MARGIN: 0px }
		.boxes { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		.copyright { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: Arial, Helvetica, sans-serif }
		.footer { FONT-WEIGHT: bold; FONT-SIZE: x-small; COLOR: #ffffff }
		.folders { FONT-WEIGHT: bolder; FONT-SIZE: small; COLOR: #660000; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
		.EE { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
		.tasks { FONT-SIZE: x-small; FONT-FAMILY: Tahoma }
		.visited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
		.Unvisited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
		.ColumnText { FONT-SIZE: x-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
		.EE1 { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
		.txtbox { BORDER-RIGHT: 0px ridge; BORDER-TOP: 0px ridge; FONT-SIZE: x-small; BORDER-LEFT: 0px ridge; WIDTH: 300px; BORDER-BOTTOM: 0px ridge; FONT-FAMILY: Tahoma; HEIGHT: 20px }
		.to { FONT-WEIGHT: bolder; FONT-SIZE: x-small; COLOR: #6600ff; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
		.style6 { FONT-WEIGHT: bold; COLOR: #ff0000 }
		.boxes311 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		</style>
		<script language="javascript" src="js/style.js" type="text/javascript"></script>
		<script language="javascript" type="text/javascript">
		/* All rights reserved to Mr. Alireza Poshtkoohi (C) 2005. */
		//---------------------------------------------------------------------------------------------------------------------------
		function CheckBoxClick(checkbox, VisitedStr)
		{
		   var str = 'Td' + checkbox.name.substring(3);
		   var ColorVisited = "#dbeaf5";
		   var ColorUnvisited = "#fff7e5";
		   var ColorSelected = "#CCCCCC";
		   var n = document.getElementById(str);
		   if(VisitedStr == "visited")
		   {
		      if(getStyleById(str, "background") == ColorVisited)
			  {
	               n.style["background"] = ColorSelected;
				   return ;
			  }
			  else
			  {
			       n.style["background"] = ColorVisited;
				   return ;
			  }
		   }
		  if(VisitedStr == "unvisited")
		  {
		      if(getStyleById(str, "background") == ColorUnvisited)
			  {
	               n.style["background"] = ColorSelected;
				   return ;
			  }
			  else
			  {
			       n.style["background"] = ColorUnvisited;
				   return ;
			  }
		   }
		}
		//-----------------------------------------
		function SelectAllCheckBox(arr)
		{
			var j = 0;
		    for(var i = 0 ; i < arr.length ; i++)
			    if(arr[i][0].checked)
			     j++;
			if(j == arr.length)
			{
			    for(var i = 0 ; i < arr.length ; i++)
				{
				   arr[i][0].checked = false;
				   CheckBoxClick(arr[i][0],  arr[i][1]);
				}
				return ;
			}
			else
			{
			    for(var i = 0 ; i < arr.length ; i++)
				{
				    if(!arr[i][0].checked)
					   CheckBoxClick(arr[i][0],  arr[i][1]);
				    arr[i][0].checked = true;
				}
				return ;
			}
		}
		//---------------------------------------------------------------------------------------------------------------------------
		</script>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" onload="FP_preloadImgs(/*url*/'images/button23.gif', /*url*/'images/button24.gif', /*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button29.gif', /*url*/'images/button2A.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif')"
		marginheight="0" marginwidth="0">
		<form id="inbox" name="inbox" method="post" runat="server">
			<table id="Table_01" height="558" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<!--DWLayoutTable-->
				<tr>
					<td vAlign="top" align="left" colSpan="4" height="27"><font face="Arial">welcome to
							<%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%>
							your AddressBook &nbsp;
							<%=this.Session["username"]%>
						</font>
					</td>
					<td vAlign="middle" align="right" colSpan="3"><div align="center"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></div>
					</td>
					<td vAlign="middle" align="right" colSpan="2"><div align="left">
						<a href="/about.aspx"><font face="Arial" size="2">About 
						PMail</font></a><font face="Arial" size="2"> | Help</font></div>
					</td>
					<td align="right" vAlign="middle" bgcolor="#c1e0ff"><div align="center"><span class="folders"><a href="/email/fa/ShowAddressBook.aspx">FA</a></span></div>
					</td>
				<tr>
					<td align="left" colSpan="3" height="29"><IMG height="89" alt="PMail Service" src="/images/arm1.jpg" width="279"></td>
					<td vAlign="top" colSpan="5"><!--DWLayoutEmptyCell-->&nbsp; 
				  </td>
					<td vAlign="top" align="right" colSpan="2"><a href="?i=signout"><IMG src="images/email_06.gif" alt="" width="85" height="29" border="0"></a></td>
				</tr>
				<tr>
					<td bgColor="#ffffe6" colSpan="2" height="26"><!--DWLayoutEmptyCell-->&nbsp; 
					</td>
					<td vAlign="bottom" align="right" bgColor="#ffffe6" colSpan="8">&nbsp; <A href="Compose.aspx">
							<IMG onmouseup="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button23.gif')" onmousedown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button24.gif')"
								id="img1" onmouseover="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button23.gif')"
								onmouseout="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button22.gif')" height="22"
								alt="Compose" src="images/button22.gif" width="90" border="0" fp-title="Compose"
								fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0"></A>
						<IMG onmouseup="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button26.gif')" onmousedown="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button27.gif')"
							id="img4" onmouseover="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button26.gif')"
							onmouseout="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button25.gif')" height="22"
							alt="Address book" src="images/button25.gif" width="90" border="0" fp-title="Address book"
							fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0">
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="69" bgColor="#c1e0ff" rowSpan="3">
						<table cellSpacing="0" cellPadding="0" width="50%" bgColor="#c1e0ff" border="0">
							<!--DWLayoutTable-->
							<tr>
								<td vAlign="top" width="95" bgColor="#c1e0ff" height="23"><span class="folders" title="Available Foldrs">Folders</span>
								</td>
								<td width="14"></td>
							</tr>
							<tr>
								<td vAlign="top" height="19"><!--DWLayoutEmptyCell-->&nbsp; 
								</td>
								<td></td>
							</tr>
							<tr>
								<td vAlign="top" height="19"><span class="boxes"><IMG height="12" src="images/inbox.gif" width="15">&nbsp;<A title="Inbox Folder" href="/email/?ShowFolder=Inbox" target="_self">Inbox</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td vAlign="top" height="19"><span class="boxes1"><IMG height="12" src="images/draft.gif" width="15">&nbsp;<A title="Draft Folder" href="/email/?ShowFolder=Draft" target="_self">Draft</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td vAlign="top" height="19"><span class="boxes4"><IMG height="12" src="images/sent.gif" width="15">&nbsp;<A title="Sent Folder" href="/email/?ShowFolder=Sent">Sent</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td vAlign="top" height="19"><span class="boxes21"><IMG height="12" src="images/bulk.gif" width="15">&nbsp;<A title="Bulk Folder" href="/email/?ShowFolder=Bulk" target="_self">Bulk</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td vAlign="top" height="19"><span class="boxes311"><IMG height="12" src="images/trash.gif" width="13">&nbsp;<A href="?ShowFolder=Trash" title="Trash Folder">Trash</A> (<a href="?EmptyTrash=1">Empty</a>)</span></td>
								<td></td>
							</tr>
							<tr>
								<td height="249">&nbsp;</td>
								<td></td>
							</tr>
						</table>
					</td>
					<td vAlign="top" bgColor="#ffffe5" colSpan="4" height="21"><asp:panel id="PanelShow1" runat="server">&nbsp;<FONT size="2"></FONT> <%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%><SPAN lang="en-us"><FONT face="Arial" size="2">Show :&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=all"><U> All</U></A> , <A 
      href="?ShowFolder=<%=box%>&amp;Show=none"><U>None</U></A></FONT></SPAN></asp:panel></td>
					<td width="9" bgColor="#ffffe6">&nbsp;</td>
					<td vAlign="top" align="right" bgColor="#ffffe5" colSpan="4"><font face="Arial" color="#808000" size="2">You 
							are used 8% of your Mailbox storage </font>
					</td>
				</tr>
				<tr>
					<td vAlign="top" bgColor="#c1e0ff" colSpan="9" height="336">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<!--DWLayoutTable-->
							<tr>
								<td vAlign="top" width="100%" bgColor="#dbeaf5" height="165"><asp:panel id="PanelMain" runat="server" Height="100%" Width="100%" Wrap="False" EnableViewState="False">
										<asp:Table id="TableTopTexts" runat="server" EnableViewState="False" Width="100%" Height="4px"
											CellPadding="0" CellSpacing="0" HorizontalAlign="Center">
											<asp:TableRow>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" Width="5px" BorderColor="White"
													ID="SelectAllColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="Email" Width="200px"
													BorderColor="White" Text="Email" CssClass="ColumnText" ID="FromColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="First Name" Width="200px"
													BorderColor="White" Text="First Name" CssClass="ColumnText" ID="SubjectColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="Last Name" Width="200px"
													BorderColor="White" Text="Last Name" CssClass="ColumnText" ID="DateColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="Phone" Width="200px"
													BorderColor="White" Text="Phone" CssClass="ColumnText" ID="SizeColumn"></asp:TableCell>
											</asp:TableRow>
										</asp:Table>
										<asp:Panel id="PanelTasks" runat="server" Width="100%" Height="16px" BackColor="#E0E0E0">
											<TABLE id="TableTasks" height="27" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD width="475">
														<asp:Label id="DeleteLabel" runat="server" EnableViewState="False" CssClass="tasks">Delete selected item(s).</asp:Label>
														<asp:ImageButton id="delete" runat="server" EnableViewState="False" ImageUrl="images/delete.gif"
															ToolTip="Delete the selected itme(s) in your Address Book."></asp:ImageButton></TD>
													<TD align="right">
														<asp:Panel id="PanelNext" runat="server" Width="100%">
															<P>&nbsp;&nbsp;&nbsp;
																<asp:HyperLink id="HyperLinkPrevious" runat="server" ToolTip="Previous" Font-Bold="True">Previous  |</asp:HyperLink>&nbsp;
																<asp:HyperLink id="HyperLinkNext" runat="server" ToolTip="Next" Font-Bold="True">Next</asp:HyperLink></P>
														</asp:Panel></TD>
												</TR>
											</TABLE>
										</asp:Panel>
										<asp:Panel id="PanelFrom" runat="server" EnableViewState="False" Width="48px" Height="10px">
<asp:Image id="Attention" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;Email</asp:Panel>
										<asp:Panel id="PanelSubject" runat="server" EnableViewState="False" Width="88px" Height="10px">
<asp:Image id="Image2" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;First 
            Name</asp:Panel>
										<asp:Panel id="PanelDate" runat="server" EnableViewState="False" Width="80px" Height="10px">
<asp:Image id="Image1" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;Last 
            Name</asp:Panel>
										<asp:Panel id="PanelSize" runat="server" EnableViewState="False" Width="48px" Height="10px">
<asp:Image id="Image3" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;Phone</asp:Panel>
									</asp:panel></td>
							</tr>
							<tr>
								<td class="folders" vAlign="top" bgColor="#c1e0ff" height="21">Add new email 
									address to your address book.</td>
							</tr>
							<tr>
								<td vAlign="top" bgColor="#c1e0ff" height="144">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<!--DWLayoutTable-->
										<tr>
											<td vAlign="top" borderColor="#c1e0ff" width="387" bgColor="#c1e0ff" height="145">
												<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#c1e0ff" border="0">
													<!--DWLayoutTable-->
													<tr>
														<td class="to" vAlign="top" width="88" bgColor="#c1e0ff" height="22">Fisrt Name :</td>
														<td vAlign="top" width="300" bgColor="#c1e0ff"><asp:textbox id="FirstName" runat="server" CssClass="txtbox" ToolTip="First Name" MaxLength="50"></asp:textbox></td>
													</tr>
													<tr>
														<td class="to" vAlign="top" bgColor="#c1e0ff" height="22">Last Name :
														</td>
														<td vAlign="top" bgColor="#c1e0ff"><asp:textbox id="LastName" runat="server" CssClass="txtbox" ToolTip="Last Name"></asp:textbox></td>
													</tr>
													<tr>
														<td class="to" vAlign="top" bgColor="#c1e0ff" height="22"><span class="style6">* </span>Email 
															:
														</td>
														<td vAlign="top" bgColor="#c1e0ff"><asp:textbox id="Email" runat="server" CssClass="txtbox" ToolTip="Email"></asp:textbox></td>
													</tr>
													<tr>
														<td class="to" vAlign="top" bgColor="#c1e0ff" height="22">Phone :
														</td>
														<td vAlign="top" bgColor="#c1e0ff"><asp:textbox id="Phone" runat="server" CssClass="txtbox" ToolTip="Phone"></asp:textbox></td>
													</tr>
													<tr bgColor="#dbeaf5">
														<td vAlign="top" bgColor="#c1e0ff" height="24"><!--DWLayoutEmptyCell-->&nbsp; 
														</td>
														<td vAlign="top" bgColor="#c1e0ff"><asp:button id="save" runat="server" ToolTip="Save to your Address Book." Font-Names="Tahoma"
																Text="Save"></asp:button><asp:button id="cancel" runat="server" ToolTip="Cancel" Font-Names="Tahoma" Text="Cancel"></asp:button></td>
													</tr>
													<tr>
														<td height="32"></td>
														<td></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" width="303">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<!--DWLayoutTable-->
													<tr>
														<td width="303" height="22" valign="top"><asp:label id="FirstNameError" runat="server" Width="100%" BackColor="Yellow" Font-Bold="True"
																Font-Names="Arial" BorderColor="Black" Visible="False" BorderWidth="1px" Font-Size="XX-Small" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td vAlign="top" height="22"><asp:label id="LastNameError" runat="server" Width="100%" BackColor="Yellow" Font-Bold="True"
																Font-Names="Arial" BorderColor="Black" Visible="False" BorderWidth="1px" Font-Size="XX-Small" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td vAlign="top" height="22"><asp:label id="EmailError" runat="server" Width="100%" BackColor="Yellow" Font-Bold="True"
																Font-Names="Arial" BorderColor="Black" Visible="False" BorderWidth="1px" Font-Size="XX-Small" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td vAlign="top" height="22"><asp:label id="PhoneError" runat="server" Width="100%" BackColor="Yellow" Font-Bold="True"
																Font-Names="Arial" BorderColor="Black" Visible="False" BorderWidth="1px" Font-Size="XX-Small" ForeColor="Red"></asp:label></td>
													</tr>
													<tr>
														<td height="57">&nbsp;</td>
													</tr>
												</table>
											</td>
											<td width="292">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" bgColor="#ffffe5" colSpan="8" height="29"><!--DWLayoutEmptyCell-->&nbsp; 
						
					</td>
					<td width="31" bgColor="#ffffe5">&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="top" bgColor="#ffffff" height="37"></td>
					<td vAlign="top" width="9" bgColor="#ffffff"></td>
					<td vAlign="top" borderColor="#ffffe5" width="97" bgColor="#ffffff">&nbsp;
					</td>
					<td vAlign="top" bgColor="#ffffff" colSpan="9">
						<p align="center"><font color="#808000">You are used 8% of your mailbox storage </font>
						</p>
					</td>
				</tr>
				<tr>
					<td vAlign="top" align="center" colSpan="11" height="22">
					<span class="copy"><font face="Arial" color="#808000">&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; © Copyright 2005 
					PMail. All rights reserved.</b></font></span><b><font face="Arial" color="#808000">
				  </font></b>
			    	</td>
				</tr>
				<tr>
					<td height="31"></td>
					<td></td>
					<td></td>
					<td width="125"></td>
					<td width="54"></td>
					<td></td>
					<td width="251"></td>
					<td width="136"></td>
					<td width="203"></td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
