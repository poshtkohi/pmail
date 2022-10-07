<%@ Page language="c#" Codebehind="ShowLetter.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.ShowLetter" %>
<HTML>
	<HEAD>
		<title>Show Letter</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
		.boxes311 { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
		</style>
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
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0"
		onload="FP_preloadImgs(/*url*/'images/button23.gif', /*url*/'images/button24.gif', /*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button29.gif', /*url*/'images/button2A.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif')">
		<table height="558" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<!--DWLayoutTable-->
			<tr>
				<td height="24" colspan="4" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
						<!--DWLayoutTable-->
						<tr>
							<td width="262" height="24" valign="top"><font face="Arial">welcome&nbsp; <%=this.Session["username"]%> </font> </td>
							<td width="336" valign="top"><div align="center"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></div></td>
							<td width="360" valign="top"><div align="left">
								<a href="/about.aspx">
								<font face="Arial" size="2">About PMail</font></a><font face="Arial" size="2"> | Help</font></div></td>
						<td width="26" valign="top" bgcolor="#C1E0FF"><div align="center"><span class="folders"><a href="/email/fa/">FA</a></span></div></td>
						</tr>
						<tr>
							<td height="0"></td>
							<td></td>
							<td colspan="2"></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td height="29" colspan="2" valign="top"><IMG height="89" alt="PMail Service" src="/images/arm1.jpg" width="279"></td>
				<td width="100%" valign="top"><!--DWLayoutEmptyCell-->&nbsp; 
				</td>
				<td width="226" valign="top"><div align="right"><a href="?i=signout"><IMG src="images/email_06.gif" alt="" width="85" height="29" border="0"></a></div>
				</td>
			</tr>
			<tr>
				<td width="90" height="27" valign="top" bgcolor="#ffffe6"><!--DWLayoutEmptyCell-->&nbsp;
					
				</td>
				<td colspan="3" valign="top" bgcolor="#ffffe6"><div align="right"><a href="Compose.aspx"><img onMouseUp="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button23.gif')" onMouseDown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button24.gif')"
								id="img1" onMouseOver="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button23.gif')" onMouseOut="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button22.gif')" height="22"
								alt="Compose" src="images/button22.gif" width="90" border="0" fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0" fp-title="Compose"></a>
						<a href="ShowAddressBook.aspx"><IMG onmouseup="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button26.gif')" onmousedown="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button27.gif')"
								id="img4" onmouseover="FP_swapImg(1,0,/*id*/'img4',/*url*/'images/button26.gif')" onmouseout="FP_swapImg(0,0,/*id*/'img4',/*url*/'images/button25.gif')"
								height="22" alt="Address book" src="images/button25.gif" width="90" border="0" fp-style="fp-btn: Soft Tab 9; fp-transparent: 1; fp-proportional: 0"
								fp-title="Address book"></a></div>
				</td>
			</tr>
			<tr>
				<td rowspan="4" valign="top" bgcolor="#c1e0ff"><table cellSpacing="0" cellPadding="0" width="100%" border="0">
						<!--DWLayoutTable-->
						<tr>
							<td vAlign="top" width="95" bgColor="#c1e0ff" height="23"><span class="folders" title="Available Foldrs">Folders</span>
							</td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><!--DWLayoutEmptyCell-->&nbsp; 
							</td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes"><IMG height="12" src="images/inbox.gif" width="15">&nbsp;<A title="Inbox Folder" href="/email/?ShowFolder=Inbox" target="_self">Inbox</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes1"><IMG height="12" src="images/draft.gif" width="15">&nbsp;<A title="Draft Folder" href="/email/?ShowFolder=Draft" target="_self">Draft</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes4"><IMG height="12" src="images/sent.gif" width="15">&nbsp;<A title="Sent Folder" href="/email/?ShowFolder=Sent">Sent</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes21"><IMG height="12" src="images/bulk.gif" width="15">&nbsp;<A title="Bulk Folder" href="/email/?ShowFolder=Bulk" target="_self">Bulk</A></span></td>
						</tr>
						<tr>
							<td height="19" vAlign="top" bgcolor="#c1e0ff"><span class="boxes311"><IMG height="12" src="images/trash.gif" width="13">&nbsp;<A href="?ShowFolder=Trash" title="Trash Folder">Trash</A> (<a href="?EmptyTrash=1">Empty</a>)</span></td>
						</tr>
						<tr>
							<td height="331" bgcolor="#c1e0ff">&nbsp;</td>
						</tr>
					</table>
				</td>
				<td height="22" colspan="3" valign="top" bgcolor="#ffffe6"><div align="right"><font face="Arial" color="#808000" size="2">You 
							are used 8% of your Mailbox storage </font>
					</div>
				</td>
			</tr>
			<tr>
				<td height="139" colspan="3" valign="top">
					<form id="inbox" name="inbox" method="post" runat="server">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<!--DWLayoutTable-->
							<tr>
								<td width="100%" height="168" bgcolor="#dbeaf5"><asp:panel id="PanelMain" runat="server" Wrap="False" Width="100%" Height="164px" BackColor="WhiteSmoke"
										Font-Size="X-Small" Font-Names="Tahoma">
										<asp:Panel id="PanelTasks" runat="server" BackColor="#E0E0E0" Width="100%">
<asp:Label id="Label2" runat="server" CssClass="tasks">Move To:</asp:Label>&nbsp;&nbsp;&nbsp; 
<asp:Label id="InboxLabel" runat="server" CssClass="tasks">Inbox</asp:Label>
<asp:ImageButton id="inboxx" runat="server" ImageUrl="images/inbox.gif" ToolTip="Move the following message to Inbox."></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:Label id="DraftLabel" runat="server" CssClass="tasks">Draft</asp:Label>
<asp:ImageButton id="draft" runat="server" ImageUrl="images/draft.gif" ToolTip="Move the following message to Draft box."></asp:ImageButton>&nbsp;&nbsp;&nbsp; 
<asp:Label id="SentLabel" runat="server" CssClass="tasks">Sent</asp:Label>
<asp:ImageButton id="sent" runat="server" ImageUrl="images/sent.gif" ToolTip="Move the following message to Sent box."></asp:ImageButton>&nbsp;&nbsp;&nbsp; 
<asp:Label id="BulkLabel" runat="server" CssClass="tasks">Bulk</asp:Label>
<asp:ImageButton id="bulk" runat="server" ImageUrl="images/bulk.gif" ToolTip="Move the following message to Bulk box."></asp:ImageButton>&nbsp;&nbsp; 
<asp:Label id="TrashLabel" runat="server" CssClass="tasks">Trash</asp:Label>
<asp:ImageButton id="trash" runat="server" ImageUrl="images/delete.gif" ToolTip="Move the following message to Trash box."></asp:ImageButton></asp:Panel>
										<asp:Table id="TableTopTexts" runat="server" Height="4px" Width="100%" CellPadding="0" CellSpacing="0"
											HorizontalAlign="Center">
											<asp:TableRow ID="DateRow">
												<asp:TableCell BackColor="Tan" Width="200px" Font-Size="X-Small" Font-Names="Tahoma" Font-Bold="True"
													Text="Date :" ID="Date_0"></asp:TableCell>
												<asp:TableCell BackColor="Cornsilk" Width="100%" Font-Size="XX-Small" Font-Names="Tahoma" ID="Date_1"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="EmailFromRow">
												<asp:TableCell BackColor="Tan" Width="200px" Font-Size="X-Small" Font-Names="Tahoma" Font-Bold="True"
													Text="From :" ID="MailFrom_0"></asp:TableCell>
												<asp:TableCell BackColor="Cornsilk" Width="200px" Font-Size="XX-Small" Font-Names="Tahoma" ID="MailFrom_1"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="SubjectRow">
												<asp:TableCell BackColor="Tan" Font-Size="X-Small" Font-Names="Tahoma" Font-Bold="True" Text="Subject :"
													ID="Subject_0"></asp:TableCell>
												<asp:TableCell BackColor="Cornsilk" Font-Size="XX-Small" Font-Names="Tahoma" ID="Subject_1"></asp:TableCell>
											</asp:TableRow>
											<asp:TableRow ID="ToRow">
												<asp:TableCell BackColor="Tan" Font-Size="X-Small" Font-Names="Tahoma" Font-Bold="True" Text="To :"
													ID="To_0"></asp:TableCell>
												<asp:TableCell BackColor="Cornsilk" Font-Size="XX-Small" Font-Names="Tahoma" ID="To_1"></asp:TableCell>
											</asp:TableRow>
										</asp:Table>
									</asp:panel></td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<tr>
				<td height="0" colspan="3">&nbsp;</td>
			</tr>
			<tr>
				<td height="24" colspan="3" valign="top" bgcolor="#ffffe6"><!--DWLayoutEmptyCell-->&nbsp;
					
				</td>
			</tr>
			<tr>
				<td height="26" colspan="4" valign="top"><div align="center"><font color="#808000">You are 
							used 8% of your mailbox storage </font>
					</div>
				</td>
			</tr>
			<tr>
				<td height="32" colspan="4" valign="top"><div align="center">
					<span class="copy"><font face="Arial" color="#808000">&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;</b>
					<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; © Copyright 2005 
					PMail. All rights reserved.</b></font></span><b><font face="Arial" color="#808000">
				  </font></b>
			    </div>
				</td>
			</tr>
			<tr>
				<td height="24">&nbsp;</td>
				<td width="100%">&nbsp;</td>
				<td>&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td height="1"><img src="images/spacert.gif" alt="" width="90" height="1"></td>
				<td></td>
				<td></td>
				<td><img src="images/spacert.gif" alt="" width="226" height="1"></td>
			</tr>
		</table>
	</body>
</HTML>
