<%@ Page CodeBehind="SignIn.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="pmail.SignIn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
	    <META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<TITLE>سیستم جامع پست الکترونیکی دانشگاه آزاد آسلامی قزوین</TITLE>
		<LINK href="images/waqua.css" type="text/css" rel="STYLESHEET">
			<style type="text/css">
		.txtBox { WIDTH: 200px }
		</style>
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" rightMargin="0" MARGINHEIGHT="0"
		MARGINWIDTH="0">
		<CENTER>
			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<TR>
						<TD vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="806" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" noWrap align="left" colSpan="4">
											<p dir="rtl" align="center">
												<font face="Tahoma">امنیت پست الکترونیکی شما هم اکنون با استفاده از SSL3 برقرار 
													است.(Secure Socket Layer Version3 used by HTTPS)</font></p>
										</TD>
									</TR>
									<TR>
										<TD width="223" height="18" align="left" vAlign="top" noWrap><IMG height="1" alt=" " src="images/spacer.gif" width="4" border="0"></TD>
										<TD width="583" colSpan="3"><IMG height="1" alt=" " src="images/spacer.gif" width="9" border="0"></TD>
									</TR>
								</TBODY></TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#ffffff" colSpan="4" height="3"><IMG height="5" alt=" " src="images/spacer.gif" width="1" border="0"></TD>
					</TR>
				</TBODY></TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="535" align="center" border="0">
				<!--DWLayoutTable-->
				<TBODY>
					<TR>
						<TD colSpan="3" height="28" width="383">
							<asp:Label id="Signout" runat="server" Width="382px" Font-Names="Tahoma" Visible="False" Font-Size="X-Small"
								ForeColor="Red" BackColor="#FFFF80" Font-Bold="True">.جلسه شما منقضی شده است</asp:Label></TD>
						<TD width="13"></TD>
						<TD width="56"></TD>
						<TD width="16"></TD>
						<TD width="58"></TD>
					</TR>
					<TR>
						<TD width="112" height="18" align="right" vAlign="top" background="images/frameleft.gif"><IMG height="10" alt="" src="images/frame_upleft.gif" width="112" border="0"></TD>
						<TD width="279" align="left" vAlign="top" background="images/frame_topbg.gif"></TD>
						<TD colspan="3" align="left" vAlign="top" background="images/frameright.gif"><IMG height="10" alt="" src="images/frame_upright.gif" width="72" border="0"></TD>
						<TD></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD rowspan="2" align="right" vAlign="top" background="images/frameleft.gif"><IMG height="175" alt="" src="images/frameleft.gif" width="112" border="0"></TD>
						<TD height="89" align="left" vAlign="top"><a href="/"><img src="/images/arm1.jpg" alt="اولین سیستم جامع فارسی زبان پست الکترونیکی"
									width="279" height="89" border="0"></a></TD>
						<TD colspan="3" rowspan="2" align="left" vAlign="top" background="images/frameright.gif"><IMG height="17" alt="" src="/images/lock.gif" width="72" border="0"><BR>
							<IMG height="158" alt="" src="images/frameright.gif" width="72" border="0"></TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD height="203" vAlign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
								<!--DWLayoutTable-->
								<tr>
									<td width="279" height="51" valign="top">
										<form runat="server">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<!--DWLayoutTable-->
												<TBODY>
													<TR>
														<TD height="18" colspan="3" valign="top">
															<asp:Label id="SigninError" runat="server" Width="232px" Font-Names="Tahoma" Visible="False"
																Font-Size="X-Small" ForeColor="Red" BackColor="#FFFF80"></asp:Label></TD>
														<td></td>
													</TR>
													<TR>
														<TD width="33" height="32">&nbsp;</TD>
														<TD colspan="2" align="left" valign="top">
															<p align="right"><span class="headline">کلمه کاربری</span><BR>
																<FONT class="form" face="Courier, Courier New" size="2">
																	<asp:TextBox id="username" runat="server" CssClass="txtBox" MaxLength="50" ToolTip="Username"></asp:TextBox>
																</FONT>
															</p>
														</TD>
														<TD>&nbsp;</TD>
													</TR>
													<TR>
														<TD height="8" colspan="2"></TD>
														<td width="7"></td>
														<td></td>
													</TR>
													<TR>
														<TD height="32">&nbsp;</TD>
														<TD colspan="2" align="left" valign="top">
															<p align="right"><span class="headline">کلمه عبور</span><BR>
																<FONT class="form" face="Courier, Courier New" size="2">
																	<asp:TextBox id="password" runat="server" CssClass="txtBox" ToolTip="Password" TextMode="Password"></asp:TextBox>
																</FONT>
															</p>
														</TD>
														<TD>&nbsp;</TD>
													</TR>
													<TR>
														<TD height="8" colspan="2"></TD>
														<td></td>
														<td></td>
													</TR>
													<TR>
														<TD height="23">&nbsp;</TD>
														<TD colspan="2" align="right" valign="top">
															<P align="center">
																<asp:Button id="enter" runat="server" ToolTip="Sign In" Text="ورود به صندوق پستی" Font-Names="Tahoma"></asp:Button></P>
														</TD>
														<td></td>
													</TR>
													<TR>
														<TD height="10" colspan="2"></TD>
														<td></td>
														<td></td>
													</TR>
													<TR>
														<TD height="12"></TD>
														<TD colspan="2" align="right" valign="top" class="body"></TD>
														<td></td>
													</TR>
													<tr>
														<td height="1"></td>
														<td width="201"></td>
														<td></td>
														<td></td>
													</tr>
												</TBODY></TABLE>
										</form>
									</td>
								</tr>
								<tr>
									<td height="24" valign="top">
										<p dir="rtl">
											<font face="Tahoma" style="FONT-SIZE: 8pt">اگر کلمه عبور خود را فراموش کرده اید<a href="#">
													اینجا</a> را کلیک کنید.</font></p>
									</td>
								</tr>
								<tr>
									<td height="39" valign="top">
										<p dir="rtl">ا<font face="Tahoma" size="2">گر تاکنون در سیستم ثبت نام نکر ده اید اینجا 
												را <a href="SignUp.aspx">کلیک</a> کنید.&nbsp;&nbsp;&nbsp;&nbsp;
										<a href="SignUp.aspx">صفحه ثبت نام</a></font></p>
									</td>
								</tr>
							</table>
						</TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD height="136" align="right" vAlign="bottom" background="images/frameleft.gif"><IMG height="136" alt="" src="images/frame_botleft.gif" width="112" border="0"></TD>
						<TD colSpan="2" align="center" vAlign="middle" width="261"><!-- Message 2 -->
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TBODY>
									<TR>
										<TD></TD>
									</TR>
									<TR>
										<TD align="left">
											<p dir="rtl" align="justify"><IMG height="13" alt="" src="images/frame_hr.gif" width="275" vspace="8" border="0"></p>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
						<TD colSpan="2" align="left" vAlign="bottom" background="images/frameright.gif"><IMG height="136" alt="" src="images/frame_botright.gif" width="71" border="0"></TD>
						<TD>&nbsp;</TD>
					</TR>
					<tr>
						<td height="0"></td>
						<td></td>
						<td width="1"></td>
						<td></td>
						<td></td>
						<td></td>
						<td></td>
					</tr>
				</TBODY></TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TBODY>
					<TR>
						<TD class="disclaimer" align="center" width="600"><a href="/about.aspx">About 
						PMail</a></TD>
					</TR>
				</TBODY></TABLE>
			<!-- END CONTENT -->
			<TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
				<TBODY>
					<TR>
						<TD class="disclaimer" align="center" width="600">
							<p dir="ltr">©&nbsp;Copyright 2005 PMail. All rights reserved.<BR>
								<BR>
							</p>
						</TD>
					</TR>
				</TBODY></TABLE>
		</CENTER>
	</BODY>
</HTML>