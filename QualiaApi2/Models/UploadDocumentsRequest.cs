using System;
using System.Collections.Generic;
using System.Text;

namespace QualiaApi2.Models
{
	public class UploadDocumentsRequest
	{
		public string OrderId { get; set; }
		public bool AgencyOnThread { get; set; }
		public string MessageSenderId { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public List<string> ConnectedUserIds { get; set; }
		public List<QualiaAttachment> Attachments { get; set; }
	}

	public class QualiaAttachment
	{
		public string Name { get; set; }
		public byte[] File { get; set; }
		public QualiaMime Mime { get; set; }
	}

	public enum QualiaMime
	{
		DOC,
		DOCX,
		ODT,
		PDF,
		RTF,
		TXT,
		JPG,
		PNG
	}
}
