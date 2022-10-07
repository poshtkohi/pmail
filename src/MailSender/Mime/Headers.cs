/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using Mime.ASCII;

namespace Mime.Headrs
{
	//-------------------------------------------------------------------------------------------------------------------
	public struct TransferEncoding
	{
		public readonly static AsciiString SevenBit = new AsciiString("7bit");
		public readonly static AsciiString EightBit = new AsciiString("8bit");
		public readonly static AsciiString Binary = new AsciiString("binary");
		public readonly static AsciiString Base64 = new AsciiString("base64");
		public readonly static AsciiString QuotedPrintable = new AsciiString("quoted-printable");
	}
	//-------------------------------------------------------------------------------------------------------------------
	public struct ContentType
	{
		public readonly static AsciiString TextHtml = new AsciiString("text/html");
		public readonly static AsciiString TextPlain = new AsciiString("text/plain");
		public readonly static AsciiString TextEnriched = new AsciiString("text/enriched");
		public readonly static AsciiString ImageGif = new AsciiString("image/gif");
		public readonly static AsciiString ImageJpeg = new AsciiString("image/jpeg");
		public readonly static AsciiString ImagePng = new AsciiString("image/png");
		public readonly static AsciiString AudioBasic = new AsciiString("audio/basic");
		public readonly static AsciiString VideoMpeg = new AsciiString("video/mpeg");
		public readonly static AsciiString ApplicationOctetStream = new AsciiString("application/octet-stream");
		public readonly static AsciiString MultipartMixed = new AsciiString("multipart/mixed");
		public readonly static AsciiString MultipartAlternative = new AsciiString("multipart/alternative");
		public readonly static AsciiString Text = new AsciiString("text/");
		public readonly static AsciiString Image = new AsciiString("image/");
		public readonly static AsciiString Audio = new AsciiString("audio/");
		public readonly static AsciiString Video = new AsciiString("video/");
		public readonly static AsciiString Application = new AsciiString("application/");
		public readonly static AsciiString Multipart = new AsciiString("multipart/");
		public readonly static AsciiString contentType = new AsciiString("Content-Type:");
		public readonly static AsciiString contentDisposition = new AsciiString("Content-Disposition:");
		public readonly static AsciiString contentID = new AsciiString("Content-ID:");
		public readonly static AsciiString contentTransferEncoding = new AsciiString("Content-Transfer-Encoding:");
		public readonly static AsciiString Attachment = new AsciiString("attachment");
	}
	//-------------------------------------------------------------------------------------------------------------------
	public struct Charset
	{
		public readonly static AsciiString AsciiUS = new AsciiString("ascii-us");
		public readonly static AsciiString UTF8 = new AsciiString("utf-8");
		public readonly static AsciiString Iso_8859_1 = new AsciiString("iso-8859-1");
	}
	//-------------------------------------------------------------------------------------------------------------------
	public struct Line
	{
		public readonly static AsciiString CRLF = new AsciiString("\r\n");
		public readonly static AsciiString CrlfCrlf = new AsciiString("\r\n\r\n");
	}
	//-------------------------------------------------------------------------------------------------------------------
}