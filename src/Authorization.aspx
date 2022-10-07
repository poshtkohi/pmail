<%@ Page language="c#" Codebehind="Authorization.aspx.cs" AutoEventWireup="false" Inherits="pmail.Authorization" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>سیستم جامع پست الکترونیکی دانشگاه آزاد آسلامی قزوین</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
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
							<TABLE cellSpacing="0" cellPadding="0" width="725" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" noWrap align="left" colSpan="4"><p dir="rtl" align="center"> <font face="Tahoma">امنیت پست الکترونیکی شما هم اکنون با استفاده از SSL3 برقرار است.(Secure Socket Layer Version3 used by HTTPS)</font></TD>
									</TR>
									<TR>
										<TD vAlign="top" noWrap align="left" height="18"><IMG height="1" alt=" " src="images/spacer.gif" width="4" border="0"></TD>
										<TD colSpan="3"><IMG height="1" alt=" " src="images/spacer.gif" width="9" border="0"></TD>
									</TR>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD align="center" bgColor="#ffffff" colSpan="4" height="3"><IMG height="5" alt=" " src="images/spacer.gif" width="1" border="0"></TD>
					</TR>
				</TBODY>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="535" align="center" border="0">
				<!--DWLayoutTable-->
				<TBODY>
					<TR>
						<TD colSpan="3" height="28">
							<asp:Label id="Signout" runat="server" BackColor="#FFFF80" ForeColor="Red" Visible="False"
								Font-Names="Tahoma" Width="424px" Font-Bold="True" Font-Size="X-Small">.جلسه شما منقضی شده است </asp:Label></TD>
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
						<TD height="89" align="left" vAlign="top"><a href="/"><img src="/images/arm1.jpg" alt="سیستم جامع پست الکترونیکی دانشگاه آزاد آسلامی قزوین"
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
										<form runat="server" ID="Form1">
											<TABLE cellSpacing="0" cellPadding="0" border="0">
												<!--DWLayoutTable-->
												<TBODY>
													<TR>
														<TD height="17" colspan="3" valign="top">
															<asp:Label id="AuthorizationError" runat="server" Width="232px" Font-Names="Tahoma" Visible="False"
																ForeColor="Red" BackColor="Yellow"></asp:Label></TD>
														<td width="6" height="17"></td>
													</TR>
													<TR>
														<TD width="33" height="32">&nbsp;</TD>
														<TD colspan="2" align="left" valign="top">
															<p align="right">
																<span class="headline">کد دانشجویی</span><BR>
																<FONT class="form" face="Courier, Courier New" size="2">
																	<asp:TextBox id="code" runat="server" CssClass="txtBox" MaxLength="50" ToolTip="Student Code"></asp:TextBox>
																</FONT>
															</p>
														</TD>
														<TD>&nbsp;</TD>
													</TR>
													<TR>
														<TD height="8" colspan="2"></TD>
														<td width="33"></td>
														<td></td>
													</TR>
													<TR>
														<TD height="32">&nbsp;</TD>
														<TD colspan="2" align="left" valign="top">
															<p align="right">
																<span class="headline">شماره شناسنامه</span><BR>
																<FONT class="form" face="Courier, Courier New" size="2">
																	<asp:TextBox id="cert" runat="server" CssClass="txtBox" ToolTip="Birth Certification Number"></asp:TextBox>
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
														<TD colspan="2" align="center" valign="middle">
															<asp:Button id="submit" runat="server" Text="تایید اطلاعات بالا" Font-Names="Tahoma" Font-Bold="True"></asp:Button></TD>
														<td></td>
													</TR>
													<TR>
														<TD height="10" colspan="2"></TD>
														<td></td>
														<td></td>
													</TR>
													<TR>
														<TD height="12"></TD>
														<TD width="181"></TD>
														<TD></TD>
														<td></td>
													</TR>
												</TBODY>
											</TABLE>
										</form>
									</td>
								</tr>
								<tr>
									<td height="63" valign="top">
										<p dir="rtl" align="justify">
											<font face="Tahoma" size="2"><font color="#ff0000">*</font>برای ثبت نام در سیستم 
												جامع پست الکترونیکی دانشگاه آزاد اسلامی قزوین، اگر دانشجوی این دانشگاه بوده اید 
												یا هستید باید&nbsp; ابتدا کد دانشجویی و شماره شناسنامه خود را در فرم بالا وارد 
												نمایید.</font></p>
									</td>
								</tr>
							</table>
						</TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>
					<TR>
						<TD height="136" align="right" vAlign="bottom" background="images/frameleft.gif"><IMG height="136" alt="" src="images/frame_botleft.gif" width="112" border="0"></TD>
						<TD colSpan="2" align="center" vAlign="middle"><!-- Message 2 -->
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TBODY>
									<TR>
										<TD></TD>
									</TR>
									<TR>
										<TD align="left">
											<p dir="rtl" align="justify"><IMG height="13" alt="" src="images/frame_hr.gif" width="275" vspace="8" border="0"><BR>
											</p>
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
				</TBODY>
			</TABLE>
			<TABLE cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
				<TBODY>
					<TR>
					  <TD class="disclaimer" align="center" width="600"><a href="/about.aspx">About Network Software Programming Group</a>.</TD>
					</TR>
				</TBODY>
			</TABLE>
			<!-- END CONTENT -->
			<TABLE cellSpacing="0" cellPadding="0" width="600" border="0">
				<TBODY>
					<TR>
						<TD class="disclaimer" align="center" width="600">
							<p dir="ltr">©&nbsp;Copyright 2005 Islamic Azad University of Qazvin. All rights 
								reserved.<BR>
								©&nbsp;Copyright 2005 Network Software Programming Group. All rights reserved.<BR>
								<BR>
							</p>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
		</CENTER>
	</BODY>
</HTML>