using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class QualiaUploadDocumentsResponse
	{
		public QualiaThread CreateThread { get; set; }
	}

	public class QualiaThread
	{
		public bool Success { get; set; }
		[JsonProperty("thread_id")]
		public string ThreadId { get; set; }
		[JsonProperty("message_id")]
		public string MessageId { get; set; }
	}
}
