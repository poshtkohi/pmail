<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.Default" %>
<HTML>
	<HEAD>
		<title><<%=this.Session["username"]%>@pmail.sharif.edu><% string box = this.Request.QueryString["ShowFolder"]; if(box == null || box == "") box = "Inbox"; else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash") box = "Inbox"; this.Response.Write(box); %></title>
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
.style4 { COLOR: #660000 }
.style5 { FONT-SIZE: x-small; COLOR: #660000; FONT-FAMILY: Tahoma }
.ColumnText { FONT-SIZE: x-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
.EE1 { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
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
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"
		onload="FP_preloadImgs(/*url*/'images/button23.gif', /*url*/'images/button24.gif', /*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button29.gif', /*url*/'images/button2A.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif')">
		<form id="inbox" name="inbox" method="post" runat="server">
			<table id="Table_01" width="100%" height="558" border="0" cellpadding="0" cellspacing="0">
				<!--DWLayoutTable-->
				<tr>
					<td height="27" colspan="4" align="left" valign="top"><font face="Arial">welcome to
							<%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%>
							your
							<%=box%>
							&nbsp;
							<%=this.Session["username"]%>
						</font>
					</td>
					<td colspan="3" align="right" valign="middle">
						<div align="center"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></div></td>
					<td colspan="2" align="right" valign="middle">
						<div align="left"><a href="/about.aspx">
							<font face="Arial" size="2">About PMail</font></a><font face="Arial" size="2"> | Help</font></div></td>
				<td align="right" valign="middle" bgcolor="#C1E0FF"><div align="center"><span class="folders"><a href="/email/fa/">FA</a></span></div></td>
				<tr>
					<td height="29" colspan="3" align="left">						<IMG height="89" alt="PMail Service" src="/images/arm1.jpg" width="279"></td>
					<td colspan="5" valign="top"><!--DWLayoutEmptyCell-->&nbsp; 
					</td>
					<td colspan="2" align="right" valign="top">
						<a href="?i=signout"><img src="images/email_06.gif" alt="" width="85" height="29" border="0"></a></td>
				</tr>
				<tr>
					<td height="26" colspan="2" bgcolor="#ffffe6"><!--DWLayoutEmptyCell-->&nbsp; 
					</td>
					<td colspan="8" align="right" valign="bottom" bgcolor="#ffffe6">&nbsp; <a href="Compose.aspx">
							<img border="0" id="img1" src="images/button22.gif" height="22" width="90" alt="Compose"
								onmouseover="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button23.gif')" onmouseout="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button22.gif')"
								onmousedown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button24.gif')" onmouseup="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button23.gif')"
								fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0" fp-title="Compose"></a>
						<a href="ShowAddressBook.aspx"><img border="0" id="img4" src="images/button25.gif" height="22" width="90" alt="Address book"
								onmouseover="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button26.gif')" onmouseout="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button25.gif')"
								onmousedown="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button27.gif')" onmouseup="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button26.gif')"
								fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0" fp-title="Address book"></a>
					</td>
				</tr>
				<tr>
					<td width="74" rowspan="3" valign="top" bgcolor="#c1e0ff">
						<table width="50%" border="0" cellpadding="0" cellspacing="0" bgcolor="#c1e0ff">
							<!--DWLayoutTable-->
							<tr>
								<td width="95" height="23" valign="top" bgcolor="#c1e0ff"><span class="folders" title="Available Foldrs">Folders</span>
								</td>
								<td width="14"></td>
							</tr>
							<tr>
								<td height="19" valign="top"><!--DWLayoutEmptyCell-->&nbsp; 
								</td>
								<td></td>
							</tr>
							<tr>
								<td height="19" valign="top"><span class="boxes"><IMG height="12" src="images/inbox.gif" width="15">&nbsp;<A href="?ShowFolder=Inbox" target="_self" title="Inbox Folder">Inbox</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td height="19" valign="top"><span class="boxes1"><IMG height="12" src="images/draft.gif" width="15">&nbsp;<A href="?ShowFolder=Draft" target="_self" title="Draft Folder">Draft</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td height="19" valign="top"><span class="boxes4"><IMG height="12" src="images/sent.gif" width="15">&nbsp;<A href="?ShowFolder=Sent" title="Sent Folder">Sent</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td height="19" valign="top"><span class="boxes21"><IMG height="12" src="images/bulk.gif" width="15">&nbsp;<A href="?ShowFolder=Bulk" target="_self" title="Bulk Folder">Bulk</A></span></td>
								<td></td>
							</tr>
							<tr>
								<td height="19" valign="top"><span class="boxes31"><IMG height="12" src="images/trash.gif" width="13">&nbsp;<A href="?ShowFolder=Trash" title="Trash Folder">Trash</A> (<a href="?EmptyTrash=1">Empty</a>)</span></td>
								<td></td>
							</tr>
							<tr>
								<td height="249">&nbsp;</td>
								<td></td>
							</tr>
						</table>
					</td>
					<td height="21" colspan="4" valign="top" bgcolor="#ffffe5">
						<asp:Panel id="PanelShow1" runat="server">&nbsp;<FONT size="2"></FONT> <%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%><SPAN lang="en-us">
								<FONT face="Arial" size="2">Show :&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=all"><U> All</U></A> , <A 
      href="?ShowFolder=<%=box%>&amp;Show=unread"><U>Unread </U></A>, <A 
      href="?ShowFolder=<%=box%>&amp;Show=none"><U>None</U></A></FONT></SPAN></asp:Panel></td>
					<td width="9" bgcolor="#ffffe6">&nbsp;</td>
					<td colspan="4" valign="top" align="right" bgcolor="#ffffe5">
						<font face="Arial" size="2" color="#808000">You are used 8% of your Mailbox storage </font>
					</td>
				</tr>
				<tr>
					<td height="336" colspan="9" valign="top" bgcolor="#dbeaf5">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<!--DWLayoutTable-->
							<tr>
								<td width="100%" height="317" valign="top" bgcolor="#dbeaf5"><asp:panel id="PanelMain" runat="server" EnableViewState="False" Wrap="False" Width="100%"
										Height="100%">
										<asp:Table id="TableTopTexts" runat="server" Height="4px" Width="100%" EnableViewState="False"
											HorizontalAlign="Center" CellSpacing="0" CellPadding="0">
											<asp:TableRow>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" Width="5px" BorderColor="White"
													ID="SelectAllColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" Width="5px" BorderColor="White"
													ID="AttachmentColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="From" Width="50%"
													BorderColor="White" Text="From" CssClass="ColumnText" ID="FromColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="Subject" Width="100%"
													BorderColor="White" Text="Subject" CssClass="ColumnText" ID="SubjectColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="Email Date" Width="100%"
													BorderColor="White" Text="Date" CssClass="ColumnText" ID="DateColumn"></asp:TableCell>
												<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="Email size" Width="100%"
													BorderColor="White" Text="Size" CssClass="ColumnText" ID="SizeColumn"></asp:TableCell>
											</asp:TableRow>
										</asp:Table>
										<asp:Panel id="PanelTasks" runat="server" Height="8px" Width="100%" BackColor="#E0E0E0">
											<TABLE id="TableTasks" height="27" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD width="475">
														<asp:Label id="Label2" runat="server" Width="56px" EnableViewState="False" CssClass="tasks">Move To:</asp:Label>
														<asp:Label id="InboxLabel" runat="server" EnableViewState="False" CssClass="tasks">Inbox</asp:Label>
														<asp:ImageButton id="inboxx" runat="server" EnableViewState="False" ToolTip="Move the selected above items to Inbox."
															ImageUrl="images/inbox.gif"></asp:ImageButton>&nbsp;
														<asp:Label id="DraftLabel" runat="server" EnableViewState="False" CssClass="tasks">Draft</asp:Label>
														<asp:ImageButton id="draft" runat="server" EnableViewState="False" ToolTip="Move the selected above items to Draft box."
															ImageUrl="images/draft.gif"></asp:ImageButton>&nbsp;
														<asp:Label id="SentLabel" runat="server" EnableViewState="False" CssClass="tasks">Sent</asp:Label>
														<asp:ImageButton id="sent" runat="server" EnableViewState="False" ToolTip="Move the selected above items to Sent box."
															ImageUrl="images/sent.gif"></asp:ImageButton>&nbsp;
														<asp:Label id="BulkLabel" runat="server" EnableViewState="False" CssClass="tasks">Bulk</asp:Label>
														<asp:ImageButton id="bulk" runat="server" EnableViewState="False" ToolTip="Move the selected above items to Bulk box."
															ImageUrl="images/bulk.gif"></asp:ImageButton>&nbsp;
														<asp:Label id="TrashLabel" runat="server" EnableViewState="False" CssClass="tasks">Trash</asp:Label>
														<asp:ImageButton id="trash" runat="server" EnableViewState="False" ToolTip="Move the selected above items to Trash box."
															ImageUrl="images/delete.gif"></asp:ImageButton></TD>
													<TD align="right">
														<asp:Panel id="PanelNext" runat="server" Width="100%">
															<P>&nbsp;&nbsp;&nbsp;
																<asp:HyperLink id="HyperLinkPrevious" runat="server" ToolTip="Previous" Font-Bold="True">Previous  |</asp:HyperLink>&nbsp;
																<asp:HyperLink id="HyperLinkNext" runat="server" ToolTip="Next" Font-Bold="True">Next</asp:HyperLink></P>
														</asp:Panel></TD>
												</TR>
											</TABLE>
										</asp:Panel>
										<asp:Panel id="PanelFrom" runat="server" Height="10px" Width="48px" EnableViewState="False">
<asp:Image id="Attention" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;From</asp:Panel>
										<asp:Panel id="PanelSubject" runat="server" Height="10px" Width="48px" EnableViewState="False">
<asp:Image id="Image2" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;Subject</asp:Panel>
										<asp:Panel id="PanelDate" runat="server" Height="10px" Width="48px" EnableViewState="False">
<asp:Image id="Image1" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;Date</asp:Panel>
										<asp:Panel id="PanelSize" runat="server" Height="10px" Width="48px" EnableViewState="False">
<asp:Image id="Image3" runat="server" ImageUrl="images/desc.gif"></asp:Image>&nbsp;Size</asp:Panel>
									</asp:panel></td>
							</tr>
							<tr>
								<td height="19" bgcolor="#dbeaf5">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="29" colspan="8" valign="top" bgcolor="#ffffe5">
						<asp:Panel id="PanelShow2" runat="server">
							<%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%>
							<SPAN lang="en-us">
								<FONT face="Arial" size="2">Show :&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=all"><U> All</U></A> , <A 
      href="?ShowFolder=<%=box%>&amp;Show=unread"><U>Unread </U></A>, <A 
      href="?ShowFolder=<%=box%>&amp;Show=none"><U>None</U></A></FONT></SPAN>
						</asp:Panel></td>
					<td width="26" bgcolor="#ffffe5">&nbsp;</td>
				</tr>
				<tr>
					<td height="37" valign="top" bgcolor="#ffffff"></td>
					<td width="9" valign="top" bgcolor="#ffffff"></td>
					<td width="99" valign="top" bordercolor="#ffffe5" bgcolor="#ffffff">&nbsp;
					</td>
					<td colspan="9" valign="top" bgcolor="#ffffff">
						<p align="center"><font color="#808000">You are used 8% of your mailbox storage </font>
						</p>
					</td>
				</tr>
				<tr>
					<td height="22" colspan="11" align="center" valign="top">
					<span class="copy"><font face="Arial" color="#808000">&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</b>
					<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; © Copyright 2005 
					PMail. All rights reserved.</b></font></span><b><font face="Arial" color="#808000">
				  </font></b>
			    	</td>
				</tr>
				<tr>
					<td height="31"></td>
					<td></td>
					<td></td>
					<td width="124"></td>
					<td width="54"></td>
					<td></td>
					<td width="249"></td>
					<td width="133"></td>
					<td width="207"></td>
					<td></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
