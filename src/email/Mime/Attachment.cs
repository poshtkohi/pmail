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
	public sealed class Attachment
	{
		private int id;
		private int StartPosition ;
		private int EndPosition ;
		private AsciiString name;
		private AsciiString source;
		private AsciiString filename;
		private AsciiString contentType;
		private AsciiString contentTransferEncoding;
		//private string CompleteFilename;
		//---------------------------------
		public Attachment()
		{
			this.StartPosition = 0;
			this.EndPosition = 0;
			this.id = 0;
			this.name = null;
			this.source = null;
			this.filename = null;
			this.contentType = null;
			this.contentTransferEncoding = null;
		}
		//---------------------------------
		public Attachment(AsciiString CompleteFilename)
		{
			FileStream fs = new FileStream(CompleteFilename.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read);
			byte[] buffer = new byte[fs.Length];
			fs.Read(buffer, 0, buffer.Length);
			fs.Close();
			this.contentTransferEncoding = Mime.Headrs.TransferEncoding.Base64;
			this.source = Mime.EncoderDecoder.LineLengthCompatible(Mime.EncoderDecoder.Base64Encoder(buffer), 76);
			return ;
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
		public AsciiString Filename
		{
			get
			{
				return this.filename;
			}
			set
			{
				this.filename = value;
			}
		}
		//---------------------------------
		public AsciiString Name
		{
			get
			{
				return this.name;
			}
			set 
			{
				this.name = value;
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
		public byte[] GetDecodedSource()
		{
				
			if(this.ContentTransferEncoding == null)
				return source.BaseStream;
			if(this.source == null)
				return null;
			else
			{
				AsciiString TransferEncoding = this.contentTransferEncoding.ToLower();
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.QuotedPrintable) == 0)
					return Mime.EncoderDecoder.StringToBinaryUTF8(Mime.EncoderDecoder.QuotedPrintableDecode(this.source));
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.SevenBit) == 0)
					return source.BaseStream;
				if(AsciiString.Compare(TransferEncoding , Mime.Headrs.TransferEncoding.EightBit) == 0)
					return source.BaseStream;
				if(AsciiString.Compare(TransferEncoding, Mime.Headrs.TransferEncoding.Base64) == 0)
				{
					byte[] buff = Mime.EncoderDecoder.Base64Decoder(source);
					if(buff == null)
						return source.BaseStream;
					else
					{
						return buff;
					}
				}
				else return source.BaseStream;
			}
		}
		//---------------------------------
		public byte[] ToXmlBytes()
		{
			AsciiString Name = this.Name;
			if(Name == null)
				Name = new AsciiString("null");
			AsciiString Filename = this.Filename;
			if(Filename == null)
				Filename = new AsciiString("null");
			AsciiString ContentType = this.ContentType;
			if(ContentType == null)
				ContentType = new AsciiString("null");
			AsciiString TransferEncoding = this.ContentTransferEncoding;
			if(TransferEncoding == null)
				TransferEncoding = new AsciiString("null");
			return (AsciiString.Format(new AsciiString("<?xml version=\"1.0\" encoding=\"us-ascii\"?><attachment Name=\"{0}\" Filename=\"{1}\" ContentType=\"{2}\" TransferEncoding=\"{3}\" start=\"{4}\" end=\"{5}\"/>"), Name, Filename, ContentType, TransferEncoding, new AsciiString(this.Start.ToString()), new AsciiString(this.End.ToString()))).BaseStream;
		}
		//---------------------------------
		public override string ToString()
		{
			return (new AsciiString("Name: ") + Name + new AsciiString(" FileName: ") + Filename + new AsciiString(" ContentType:") + ContentType).ToString();
		}
		//---------------------------------
	}
}
