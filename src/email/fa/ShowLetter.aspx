<%@ Page language="c#" Codebehind="ShowLetter.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.fa.ShowLetter" %>
<HTML>
	<HEAD>
		<title><<%=this.Session["username"]%>@pmail.sharif.edu><% string box = this.Request.QueryString["ShowFolder"]; if(box == null || box == "") box = "Inbox"; else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash") box = "Inbox"; this.Response.Write(box); %></title>
		<meta http-equiv="Content-Language" content="fa">
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
.style8 { FONT-WEIGHT: 900; FONT-SIZE: 9px; COLOR: #000066; FONT-FAMILY: Tahoma }
.style9 { COLOR: #000033 }
.boxes { MARGIN-TOP: 7px; FONT-WEIGHT: bold; FONT-SIZE: x-small; MARGIN-LEFT: 12px; WIDTH: 10px; COLOR: #333333; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-ALIGN: left; font-stretch: expanded }
.copyright { FONT-WEIGHT: normal; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: Arial, Helvetica, sans-serif }
.folders { FONT-WEIGHT: bolder; FONT-SIZE: small; COLOR: #660000; FONT-FAMILY: Arial, Helvetica, sans-serif; FONT-VARIANT: normal }
.EE { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
.tasks { FONT-SIZE: x-small; FONT-FAMILY: Tahoma }
.visited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
.Unvisited { BORDER-RIGHT: 0px solid; BORDER-TOP: #6600cc 0px solid; FONT-SIZE: x-small; BORDER-LEFT: 0px solid; BORDER-BOTTOM: #6600cc 1px solid; FONT-FAMILY: Tahoma; HEIGHT: 30px }
.ColumnText { FONT-SIZE: x-small; COLOR: #0033ff; FONT-FAMILY: Tahoma }
.EE1 { BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #ffffff 1px solid; BORDER-COLLAPSE: collapse; EMPTY-CELLS: show }
A { COLOR: #039; TEXT-DECORATION: none }
A:visited { COLOR: #039; TEXT-DECORATION: none }
A:hover { TEXT-DECORATION: underline }
.style10 { FONT-FAMILY: Tahoma }
</style>
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"
		onload="FP_preloadImgs(/*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif', /*url*/'images/button4.jpg', /*url*/'images/button5.jpg', /*url*/'images/buttonA.jpg', /*url*/'images/buttonB.jpg')">
		<table id="Table_01" width="100%" height="599" border="0" cellpadding="0" cellspacing="0">
			<!-- MSTableType="layout" -->
			<tr>
				<td colspan="3" align="left" valign="top">
					<p align="left" dir="rtl">
					<font face="Tahoma" style="FONT-SIZE: 8pt"> 
					<a href="/about.aspx" target="_blank" style="color: #039; text-decoration: none">
								???????????? <span lang="en-us">PMail</span> </a>
							&nbsp;|
											<span lang="en-us">
								&nbsp;</span><a target="_blank" href="/specifications.aspx" style="color: #039; text-decoration: none">???????????? 
					?????????? ?????? ?????????????????? <span lang="en-us">PMai</span></a><span lang="en-us">l</span></font></p>
			  </td>
				<td colspan="2" align="right" valign="middle"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></td>
				<td colspan="3" align="right" valign="middle">
					<p align="center"><font face="Arial">welcome&nbsp;
							<%=this.Session["username"]%>
						</font>
				  </p>
				</td>
				<td height="32" bgcolor="#AECBF5"><div align="center"><span class="folders"><a href="/email/">En</a></span></div></td>
			</tr>
			<tr>
				<td align="right">
					<a href="?i=signout"><img src="images/email_06.gif" alt="????????" width="85" height="29" border="0"></a></td>
				<td colspan="5" valign="top" height="35" align="right">
				</td>
				<td valign="top" rowspan="3" colspan="3">
					<p align="right">
						<img src="/images/arm1.jpg" alt="PMail Service" border="0"></p>
				</td>
			</tr>
			<tr>
				<td valign="top" colspan="2">
					<p align="right" dir="rtl"><font face="Tahoma" color="#000066"> <span style="FONT-SIZE: 8pt"> ?????????? ??????????<span lang="en-us">
					</span>???????? ?????????? ???????? ?????? ????????????????????</span></font></p>
			  </td>
				<td colspan="4" align="left" valign="bottom" height="38">
					<p align="right" dir="rtl">&nbsp; <a href="Compose.aspx"><img border="0" id="img1" src="images/button3.jpg" height="22" width="110" alt="?????????? ?????????? ????????"
								onmouseover="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button4.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button3.jpg')"
								onmousedown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button5.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button4.jpg')"
								fp-style="fp-btn: Soft Tab 6; fp-proportional: 0" fp-title="?????????? ?????????? ????????"></a>
						<a href="ShowAddressBook.aspx"><img border="0" id="img5" src="images/button9.jpg" height="22" width="95" alt="??????????????"
								onmouseover="FP_swapImg(1,0,/*id*/'img5',/*url*/'images/buttonA.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img5',/*url*/'images/button9.jpg')"
								onmousedown="FP_swapImg(1,0,/*id*/'img5',/*url*/'images/buttonB.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img5',/*url*/'images/buttonA.jpg')"
								fp-style="fp-btn: Soft Tab 6; fp-proportional: 0" fp-title="??????????????"></a></p>
				</td>
			</tr>
			<tr>
				<td colspan="4" valign="top" bgcolor="#caeeff">
					<span class="style9">
						<font face="Arial" size="2">You are used 8% of your Mailbox storage </font>
					</span>
				</td>
				<td colspan="2" align="left" valign="top" bgcolor="#caeeff" height="22"><FONT style="BACKGROUND-COLOR: #ffffff"></FONT>
				</td>
			</tr>
			<tr>
				<td height="47" colspan="7" valign="bottom" bgcolor="#caeeff">
					<p align="right">&nbsp;&nbsp;</p>
				</td>
				<td colspan="2" rowspan="4" align="right" valign="top">
					<table width="222" height="399" border="1" cellpadding="0" cellspacing="0" bordercolorlight="#caeeff"
						bordercolordark="#a4e1ff">
						<!-- MSTableType="layout" -->
						<tr>
							<td height="21" align="right" valign="top" bgcolor="#a4e1ff" dir="rtl">
								<p align="right"><b> <a href="/email/fa/?ShowFolder=Inbox">
											<span lang="fa">
												<font face="Tahoma" style="FONT-SIZE: 8pt">?????????? ?????? ???????????? ?????? </font></span></a></b><span lang="en-us"><font face="Tahoma" size="1">(Inbox)</font></span></p>
							</td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl">
								<b><a href="/email/fa/?ShowFolder=Sent">
										<span lang="fa">
											<font face="Tahoma" style="FONT-SIZE: 8pt">?????????? ?????? ?????????????? ?????? </font></span></a></b>
								<font face="Tahoma" size="1"><span lang="en-us">(Sent)</span></font></td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl"><b> <a href="/email/fa/?ShowFolder=Draft">
										<font face="Tahoma" style="FONT-SIZE: 8pt">
											<span lang="fa">???????? ?????? ???????? ???????? ???? ?????????? ??????</span><span lang="en-us"></span>
											<span lang="fa">??????</span></font></a></b><font face="Tahoma" style="FONT-SIZE:9px"><span lang="en-us">(Draft)</span></font></td>
						</tr>
						<tr>
							<td height="23" align="right" valign="top" dir="rtl">
								<b><a href="/email/fa/?ShowFolder=Trash">
										<span lang="fa">
											<font face="Tahoma" style="FONT-SIZE: 8pt">?????????? ???????? ???? ?????? ???????? ??????</font></span></a><font face="Tahoma" style="FONT-SIZE: 8pt"><span lang="en-us">
											<a href="?EmptyTrash=1">(??????)</a>
										</span></font></b><font face="Tahoma" style="FONT-SIZE: 8pt">
									<span lang="en-us">(Trash)</span></font></td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl">
								<b><a href="/email/fa/?ShowFolder=Bulk">
										<span lang="fa">
											<font face="Tahoma" style="FONT-SIZE: 8pt">?????? ???????? ?????? ?????????????? ?????? ???? ??????</font></span></a></b><font face="Tahoma" size="1"><span lang="en-us">(Bulk)</span></font></td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl">
								<a href="/email/fa/?ShowFolder=Inbox&amp;Show=all">
									<span lang="fa">
										<b><font face="Tahoma" style="FONT-SIZE: 8pt">?????????? ?????????? ?????? ???????????? ??????</font></b></span></a></td>
						</tr>
						<tr>
							<td height="19" align="right" valign="top" bgcolor="#a4e1ff" dir="rtl">
							</td>
						</tr>
						<tr>
							<td height="250" width="222" valign="top">
								<p align="right" dir="rtl">
									<span lang="en-us"></span>&nbsp;</p>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<form runat="server" method="post" ID="Form1">
				<tr>
					<td height="299" colspan="7" valign="top">
						<asp:panel id="PanelMain" runat="server" Font-Names="Tahoma" Font-Size="X-Small" BackColor="WhiteSmoke"
							Wrap="False" Width="100%" Height="164px">
							<asp:Panel id="PanelTasks" runat="server" BackColor="#E0E0E0" Width="100%">
<asp:Label id="Label2" runat="server" CssClass="tasks">???????????? ???? ????????:</asp:Label>&nbsp;&nbsp;&nbsp; 
<asp:Label id="InboxLabel" runat="server" CssClass="tasks">Inbox</asp:Label>
<asp:ImageButton id="inboxx" runat="server" ImageUrl="/email/images/inbox.gif" ToolTip="Move the following message to Inbox."></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:Label id="DraftLabel" runat="server" CssClass="tasks">Draft</asp:Label>
<asp:ImageButton id="draft" runat="server" ImageUrl="/email/images/draft.gif" ToolTip="Move the following message to Draft box."></asp:ImageButton>&nbsp;&nbsp;&nbsp; 
<asp:Label id="SentLabel" runat="server" CssClass="tasks">Sent</asp:Label>
<asp:ImageButton id="sent" runat="server" ImageUrl="/email/images/sent.gif" ToolTip="Move the following message to Sent box."></asp:ImageButton>&nbsp;&nbsp;&nbsp; 
<asp:Label id="BulkLabel" runat="server" CssClass="tasks">Bulk</asp:Label>
<asp:ImageButton id="bulk" runat="server" ImageUrl="/email/images/bulk.gif" ToolTip="Move the following message to Bulk box."></asp:ImageButton>&nbsp;&nbsp; 
<asp:Label id="TrashLabel" runat="server" CssClass="tasks">Trash</asp:Label>
<asp:ImageButton id="trash" runat="server" ImageUrl="/email/images/delete.gif" ToolTip="Move the following message to Trash box."></asp:ImageButton></asp:Panel>
							<asp:Table id="TableTopTexts" runat="server" Width="100%" Height="4px" CellPadding="0" CellSpacing="0"
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
						</asp:panel>
					</td>
				</tr>
			</form>
			<tr>
				<td height="20" colspan="7" align="right" valign="top" bgcolor="#caeeff" dir="rtl"></td>
			</tr>
			<tr>
				<td colspan="7" valign="top" bgcolor="#caeeff" dir="rtl" height="33">
					<div align="right">
					</div>
				</td>
			</tr>
			<tr>
				<td height="34" colspan="9" valign="top">
					<p align="center" class="style9">
						You are used 8% of your mailbox storage</p>
				</td>
			</tr>
			<tr>
				<td height="38" colspan="9" align="center" valign="top">
					<span class="style8"><font size="2">??&nbsp;Copyright 2005
					<span lang="en-us">PMail</span>. All rights reserved.</font>
                    </span>
                </td>
			</tr>
			<tr>
				<td width="211">
				</td>
				<td width="58"></td>
				<td width="96"></td>
				<td width="1"></td>
				<td width="238"></td>
				<td width="169"></td>
				<td width="57"></td>
				<td width="187"></td>
				<td height="1" width="40"></td>
			</tr>
		</table>
	</body>
</HTML>
