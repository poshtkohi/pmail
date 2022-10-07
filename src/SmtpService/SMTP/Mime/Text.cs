/*
	All rights reserved to Alireza Poshtkohi (c) 1999-2023.
	Email: arp@poshtkohi.info
	Website: http://www.poshtkohi.info
*/

using System;
using System.IO;
using Mime.ASCII;

namespace Mime
{
	//-------------------------------------------------------------------------------------------------------------------
	public sealed class Text
	{
		private int StartPosition;
		private int EndPosition;
		private int id;
		private AsciiString charset;
		private AsciiString source;
		private AsciiString contentType;
		private AsciiString contentTransferEncoding;
		//---------------------------------
		public Text()
		{
			this.StartPosition = 0;
			this.EndPosition = 0;
			this.source = null;
			this.charset = null;
			this.contentType = null;
			this.contentTransferEncoding = null;
			return ;
		}
		//---------------------------------
		public Text(AsciiString filename, AsciiString ContentTransferEncoding, AsciiString charset, bool FromFile)
		{
			FileStream fs = new FileStream(filename.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);
			fs.Close();
			this.source = new AsciiString(buffer);
			buffer = null;
			ContentTransferEncoding = ContentTransferEncoding.ToLower();
			this.contentTransferEncoding = ContentTransferEncoding;
			if(charset == null || charset.ToString() == "")
				charset = Mime.Headrs.Charset.UTF8;
			this.charset = charset;
			if(AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.EightBit)== 0 || AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.SevenBit) == 0)
			{
				this.source = this.source.Replace(new AsciiString("\r\n"), new AsciiString(""));
				this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
				if(this.charset == Mime.Headrs.Charset.UTF8)
					this.source = new AsciiString("=EF=BB=BF") + this.source;
				return ;
			}
			if(AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.Base64) == 0)
			{
				this.source = Mime.EncoderDecoder.Base64Encoder(this.source.BaseStream);
				this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
				return ;
			}
			if(AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.QuotedPrintable) == 0)
			{
				this.source = Mime.EncoderDecoder.QuotedPrintableEncode(this.source);
				this.source = this.source.Replace(new AsciiString("\r\n"), new AsciiString(""));
				this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
				if(this.charset == Mime.Headrs.Charset.UTF8)
					this.source = new AsciiString("=EF=BB=BF") + this.source;
				return ;
			}
			else
			{
				this.contentTransferEncoding = Mime.Headrs.TransferEncoding.QuotedPrintable;
				this.source = Mime.EncoderDecoder.QuotedPrintableEncode(this.source);
				this.source = this.source.Replace(new AsciiString("\r\n"), new AsciiString(""));
				this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
				if(this.charset == Mime.Headrs.Charset.UTF8)
					this.source = new AsciiString("=EF=BB=BF") + this.source;
				return ;
			}
		}
		//---------------------------------
		public Text(AsciiString DecodedSource, AsciiString ContentTransferEncoding, AsciiString charset)
		{
			if(DecodedSource == null)
				throw new Exception("DecodedSource is null.");
			else
			{
				if(charset == null || charset.ToString() == "")
					charset = Mime.Headrs.Charset.UTF8;
				this.charset = charset;
				this.contentTransferEncoding = ContentTransferEncoding.ToLower();
				if(AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.EightBit) ==0 || AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.SevenBit) == 0)
				{
					this.source = DecodedSource;
					this.source = this.source.Replace(new AsciiString("\r\n"), new AsciiString(""));
					this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
					if(this.charset == Mime.Headrs.Charset.UTF8)
						this.source = new AsciiString("=EF=BB=BF") + this.source;
				}
				if(AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.Base64) == 0)
				{
					this.source = Mime.EncoderDecoder.Base64Encoder(DecodedSource.BaseStream);
					this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
					return ;
				}
				if(AsciiString.Compare(ContentTransferEncoding, Mime.Headrs.TransferEncoding.QuotedPrintable) == 0)
				{
					this.source = Mime.EncoderDecoder.QuotedPrintableEncode(DecodedSource);
					this.source = this.source.Replace(new AsciiString("\r\n"), new AsciiString(""));
					this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
					if(this.charset == Mime.Headrs.Charset.UTF8)
						this.source = new AsciiString("=EF=BB=BF") + this.source;
					return ;
				}
				else
				{
					this.contentTransferEncoding = Mime.Headrs.TransferEncoding.QuotedPrintable;
					this.source = Mime.EncoderDecoder.QuotedPrintableEncode(DecodedSource);
					this.source = this.source.Replace(new AsciiString("\r\n"), new AsciiString(""));
					this.source = Mime.EncoderDecoder.LineLengthCompatible(this.source, 76);
					if(this.charset == Mime.Headrs.Charset.UTF8)
						this.source = new AsciiString("=EF=BB=BF") + this.source;
					return ;
				}
			}
		}
		//---------------------------------
		public int ID
		{
			get
			{
				return this.id;
			}
			set
			{
				this.id = value;
			}
		}
		//---------------------------------
		public int Start
		{
			get
			{
				return this.StartPosition;
			}
			set
			{
				this.StartPosition = value;
			}
		}
		//---------------------------------
		public int End
		{
			get
			{
				return this.EndPosition;
			}
			set
			{
				this.EndPosition = value;
			}
		}
		//---------------------------------
		public AsciiString Charset
		{
			get
			{
				return this.charset;
			}
			set
			{
				this.charset = value;
			}
		}
		//---------------------------------
		public AsciiString ContentTransferEncoding
		{
			get
			{
				return this.contentTransferEncoding;
			}
			set 
			{
				this.contentTransferEncoding = value;
			}
		}
		//---------------------------------
		public AsciiString ContentType
		{
			get
			{
				return this.contentType;
			}
			set 
			{
				this.contentType = value;
			}
		}
		//---------------------------------
		public AsciiString Source
		{
			get
			{
				return this.source;
			}
			set 
			{
				this.source = value;
			}
		}
		//---------------------------------
		public int StartPositionInBuffer
		{
			get
			{
				return this.StartPosition;
			}
			set 
			{
				this.StartPosition= value;
			}
		}
		//---------------------------------
		public int EndPositionInBuffer
		{
			get
			{
				return this.EndPosition;
			}
			set 
			{
				this.EndPosition = value;
			}
		}
		//---------------------------------
		public string GetDecodedSource()
		{
				
			if(this.ContentTransferEncoding == null)
				return Mime.EncoderDecoder.BinaryToStringUTF8(this.source.BaseStream);
			if(this.source == null)
				return null;
			else
			{
				AsciiString TransferEncoding = this.contentTransferEncoding.ToLower();
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.QuotedPrintable) == 0)
					return EncoderDecoder.QuotedPrintableDecode(this.source);
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.SevenBit) == 0)
					return source.ToString();
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.EightBit) == 0)
					return Mime.EncoderDecoder.BinaryToStringUTF8(this.source.BaseStream);
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.Base64) == 0)
				{
					byte[] buff = EncoderDecoder.Base64Decoder(this.source);
					if(buff == null)
						return Mime.EncoderDecoder.BinaryToStringUTF8(this.source.BaseStream);
					else
					{
						AsciiString chasert = this.charset;
						if(charset == null)
							return EncoderDecoder.BinaryToStringUTF8(buff, buff.Length);
						else
						{
							if(AsciiString.Compare(charset, Mime.Headrs.Charset.AsciiUS) == 0)
								return EncoderDecoder.BinaryToStringASCII(buff, buff.Length);
							if(AsciiString.Compare(charset, Mime.Headrs.Charset.UTF8) == 0)
								return EncoderDecoder.BinaryToStringUTF8(buff, buff.Length);
							else
								return EncoderDecoder.BinaryToStringUTF8(buff, buff.Length);
						}
					}
				}
				else return Mime.EncoderDecoder.BinaryToStringUTF8(this.source.BaseStream);
			}
		}
		//---------------------------------
	}
	//------------------------------------------------------------------------------------------------------------------------------
}
