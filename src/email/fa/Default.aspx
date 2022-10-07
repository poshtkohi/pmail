<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="Cyber.email.fa._Default" %>
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
		<script language="javascript" src="/email/js/style.js" type="text/javascript"></script>
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
		onload="FP_preloadImgs(/*url*/'images/button26.gif', /*url*/'images/button27.gif', /*url*/'images/button2C.gif', /*url*/'images/button2D.gif', /*url*/'images/button33.gif', /*url*/'images/button34.gif', /*url*/'images/button36.gif', /*url*/'images/button37.gif', /*url*/'images/button4.jpg', /*url*/'images/button5.jpg', /*url*/'images/buttonA.jpg', /*url*/'images/buttonB.jpg')">
		<table id="Table_01" width="100%" height="599" border="0" cellpadding="0" cellspacing="0">
			<!-- MSTableType="layout" -->
			<tr>
				<td colspan="3" align="left" valign="top">
					<p align="left" dir="rtl">
					<font face="Tahoma" style="FONT-SIZE: 8pt"> 
					<a href="/about.aspx" target="_blank" style="color: #039; text-decoration: none">
								درباره <span lang="en-us">PMail</span> </a>
							&nbsp;|
											<span lang="en-us">
								&nbsp;</span><a target="_blank" href="/specifications.aspx" style="color: #039; text-decoration: none">مشخصات 
					سیستم پست الکترونیک <span lang="en-us">PMai</span></a><span lang="en-us">l</span></font></p>
				</td>
				<td colspan="2" align="right" valign="middle"><b><font size="2" face="Arial"> <%=this.Session["username"]%>@pmail.sharif.edu</font></b></td>
				<td colspan="3" align="right" valign="middle">
					<p align="center"><font face="Arial">welcome 
							&nbsp;
							<%=this.Session["username"]%>
						</font>
				  </p>
				</td>
				<td height="32" bgcolor="#ACCCFB"><div align="center"><span class="folders"><a href="/email/">En</a></span></div></td>
			</tr>
			<tr>
				<td align="right">
					<a href="?i=signout"><img src="images/email_06.gif" alt="خروج" width="85" height="29" border="0"></a></td>
				<td colspan="5" valign="top" height="35" align="right">
					<asp:Panel id="PanelShow2" runat="server">
						<SPAN class="style10">&nbsp;&nbsp; <%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%><FONT size="2">نمایش :&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=all"><U>&nbsp;همه</U></A> ,&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=unread"><U>نخوانده ها&nbsp;</U></A>, <A href="?ShowFolder=<%=box%>&amp;Show=none">
									<U>هیچ</U></A></FONT></SPAN>
					</asp:Panel>
				</td>
				<td valign="top" rowspan="3" colspan="3">
					<p align="right">
						<img src="/images/arm1.jpg" alt="PMail Service" border="0"></p>
				</td>
			</tr>
			<tr>
				<td valign="top" colspan="2">
					<p align="right" dir="rtl"><font face="Tahoma" color="#000066"> <span style="FONT-SIZE: 8pt"> اولین سیستم<span lang="en-us">
					</span>جامع فارسی زبان پست الکترونیکی</span></font></p>
				</td>
				<td colspan="4" align="left" valign="bottom" height="38">
					<p align="right" dir="rtl">&nbsp; <a href="Compose.aspx"><img border="0" id="img1" src="images/button3.jpg" height="22" width="110" alt="ارسال ايميل جديد"
								onmouseover="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button4.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button3.jpg')"
								onmousedown="FP_swapImg(1,0,/*id*/'img1',/*url*/'images/button5.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img1',/*url*/'images/button4.jpg')"
								fp-style="fp-btn: Soft Tab 6; fp-proportional: 0" fp-title="ارسال ايميل جديد"></a>
						<a href="ShowAddressBook.aspx"><img border="0" id="img5" src="images/button9.jpg" height="22" width="95" alt="تنظيمات"
								onmouseover="FP_swapImg(1,0,/*id*/'img5',/*url*/'images/buttonA.jpg')" onmouseout="FP_swapImg(0,0,/*id*/'img5',/*url*/'images/button9.jpg')"
								onmousedown="FP_swapImg(1,0,/*id*/'img5',/*url*/'images/buttonB.jpg')" onmouseup="FP_swapImg(0,0,/*id*/'img5',/*url*/'images/buttonA.jpg')"
								fp-style="fp-btn: Soft Tab 6; fp-proportional: 0" fp-title="تنظيمات"></a></p>
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
								<p align="right"><b> <a href="?ShowFolder=Inbox">
											<span lang="fa">
												<font face="Tahoma" style="FONT-SIZE: 8pt">ايميل هاي دريافت شده</font></span></a></b><span lang="en-us"><font face="Tahoma" size="1">(Inbox)</font></span></p>
							</td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl">
								<b><a href="?ShowFolder=Sent">
										<span lang="fa">
											<font face="Tahoma" style="FONT-SIZE: 8pt">ايميل هاي فرستاده شده </font></span></a></b><font face="Tahoma" size="1"><span lang="en-us">(Sent)</span></font></td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl"><b> <a href="?ShowFolder=Draft"><font face="Tahoma" style="FONT-SIZE: 8pt">
											<span lang="fa">نامه هاي نيمه كاره كه ذخيره شده</span><span lang="en-us"></span>
											<span lang="fa">اند</span></font></a></b><font face="Tahoma" style="FONT-SIZE:9px"><span lang="en-us">(Draft)</span></font></td>
						</tr>
						<tr>
							<td height="23" align="right" valign="top" dir="rtl">
								<b><a href="?ShowFolder=Trash">
										<span lang="fa">
											<font face="Tahoma" style="FONT-SIZE: 8pt">ايميل هايي كه پاك كرده ايد</font></span></a><font face="Tahoma" style="FONT-SIZE: 8pt"><span lang="en-us">
											<a href="?EmptyTrash=1">(حذف)</a>
										</span></font></b><font face="Tahoma" style="FONT-SIZE: 8pt">
									<span lang="en-us">(Trash)</span></font></td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl">
								<b><a href="?ShowFolder=Bulk">
										<span lang="fa">
											<font face="Tahoma" style="FONT-SIZE: 8pt">هرز نامه هاي فرستاده شده به شما</font></span></a></b><font face="Tahoma" size="1"><span lang="en-us">(Bulk)</span></font></td>
						</tr>
						<tr>
							<td height="21" align="right" valign="top" dir="rtl">
								<a href="?ShowFolder=Inbox&amp;Show=all">
									<span lang="fa">
										<b><font face="Tahoma" style="FONT-SIZE: 8pt">تمامي ايميل هاي دريافت شده</font></b></span></a></td>
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
			<form runat="server" method="post">
				<tr>
					<td height="299" colspan="7" valign="top">
						&nbsp;
						<asp:panel id="PanelMain" runat="server" EnableViewState="False" Wrap="False" Width="100%"
							Height="100%">
							<asp:Table id="TableTopTexts" runat="server" Height="4px" Width="100%" EnableViewState="False"
								CellPadding="0" CellSpacing="0" HorizontalAlign="Center">
								<asp:TableRow>
									<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" Width="5px" BorderColor="White"
										ID="SelectAllColumn"></asp:TableCell>
									<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" Width="5px" BorderColor="White"
										ID="AttachmentColumn"></asp:TableCell>
									<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="ایمیل دریافت شده از"
										Width="50%" BorderColor="White" Text="ایمیل دریافت شده از" CssClass="ColumnText" ID="FromColumn"></asp:TableCell>
									<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="موضوع" Width="100%"
										BorderColor="White" Text="موضوع" CssClass="ColumnText" ID="SubjectColumn"></asp:TableCell>
									<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="تاریخ ایمیل"
										Width="100%" BorderColor="White" Text="تاریخ" CssClass="ColumnText" ID="DateColumn"></asp:TableCell>
									<asp:TableCell BorderStyle="Solid" BorderWidth="1px" BackColor="#DBEAF5" ToolTip="حجم ایمیل" Width="100%"
										BorderColor="White" Text="حجم" CssClass="ColumnText" ID="SizeColumn"></asp:TableCell>
								</asp:TableRow>
							</asp:Table>
							<asp:Panel id="PanelTasks" runat="server" Height="8px" Width="100%" BackColor="#E0E0E0">
								<TABLE id="TableTasks" height="27" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR>
										<TD width="554">
											<TABLE id="Table1" height="27" cellSpacing="1" cellPadding="1" width="100%" border="0">
												<TR>
													<TD width="475">
														<asp:Label id="Label2" runat="server" Width="88px" EnableViewState="False" CssClass="tasks">انتقال به پوشه:</asp:Label>
														<asp:Label id="InboxLabel" runat="server" EnableViewState="False" CssClass="tasks">Inbox</asp:Label>
														<asp:ImageButton id="inboxx" runat="server" EnableViewState="False" ImageUrl="/email/images/inbox.gif"
															ToolTip="Move the selected above items to Inbox."></asp:ImageButton>&nbsp;
														<asp:Label id="DraftLabel" runat="server" EnableViewState="False" CssClass="tasks">Draft</asp:Label>
														<asp:ImageButton id="draft" runat="server" EnableViewState="False" ImageUrl="/email/images/draft.gif"
															ToolTip="Move the selected above items to Draft box."></asp:ImageButton>&nbsp;
														<asp:Label id="SentLabel" runat="server" EnableViewState="False" CssClass="tasks">Sent</asp:Label>
														<asp:ImageButton id="sent" runat="server" EnableViewState="False" ImageUrl="/email/images/sent.gif"
															ToolTip="Move the selected above items to Sent box."></asp:ImageButton>&nbsp;
														<asp:Label id="BulkLabel" runat="server" EnableViewState="False" CssClass="tasks">Bulk</asp:Label>
														<asp:ImageButton id="bulk" runat="server" EnableViewState="False" ImageUrl="/email/images/bulk.gif"
															ToolTip="Move the selected above items to Bulk box."></asp:ImageButton>&nbsp;
														<asp:Label id="TrashLabel" runat="server" EnableViewState="False" CssClass="tasks">Trash</asp:Label>
														<asp:ImageButton id="trash" runat="server" EnableViewState="False" ImageUrl="/email/images/delete.gif"
															ToolTip="Move the selected above items to Trash box."></asp:ImageButton></TD>
												</TR>
											</TABLE>
										</TD>
										<TD align="right">
											<asp:Panel id="PanelNext" runat="server" Width="100%">
												<P>&nbsp;&nbsp;&nbsp;
													<asp:HyperLink id="HyperLinkPrevious" runat="server" ToolTip="Previous" Font-Bold="True">قبلی  |</asp:HyperLink>&nbsp;
													<asp:HyperLink id="HyperLinkNext" runat="server" ToolTip="Next" Font-Bold="True">بعدی</asp:HyperLink></P>
											</asp:Panel></TD>
									</TR>
								</TABLE>
							</asp:Panel>
							<asp:Panel id="PanelFrom" runat="server" Height="10px" Width="128px" EnableViewState="False">
<asp:Image id="Attention" runat="server" ImageUrl="/email/images/desc.gif"></asp:Image>&nbsp;ایمیل 
      دریافت شده از</asp:Panel>
							<asp:Panel id="PanelSubject" runat="server" Height="10px" Width="56px" EnableViewState="False">
<asp:Image id="Image2" runat="server" ImageUrl="/email/images/desc.gif"></asp:Image>موضوع&nbsp;</asp:Panel>
							<asp:Panel id="PanelDate" runat="server" Height="10px" Width="48px" EnableViewState="False">
<asp:Image id="Image1" runat="server" ImageUrl="/email/images/desc.gif"></asp:Image>&nbsp;تاریخ</asp:Panel>
							<asp:Panel id="PanelSize" runat="server" Height="10px" Width="48px" EnableViewState="False">
<asp:Image id="Image3" runat="server" ImageUrl="/email/images/desc.gif"></asp:Image>&nbsp;حجم</asp:Panel>
						</asp:panel>
					</td>
				</tr>
			</form>
			<tr>
				<td height="20" colspan="7" align="right" valign="top" bgcolor="#caeeff" dir="rtl">
					<asp:Panel id="PanelShow1" runat="server">
						<SPAN class="style10">&nbsp;&nbsp; <%
				   string box = this.Request.QueryString["ShowFolder"];
				   if(box == null || box == "")
					  box = "Inbox"; 
				   else if(box != "Inbox" && box != "Draft" && box != "Sent" && box != "Bulk" && box != "Trash")
					  box = "Inbox"; 
				%><FONT size="2">نمایش :&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=all"><U>&nbsp;همه</U></A> ,&nbsp;<A 
      href="?ShowFolder=<%=box%>&amp;Show=unread"><U>نخوانده ها&nbsp;</U></A>, <A href="?ShowFolder=<%=box%>&amp;Show=none">
									<U>هیچ</U></A></FONT></SPAN>
					</asp:Panel></td>
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
					<span class="style8"><font size="2">©&nbsp;Copyright 2005
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
