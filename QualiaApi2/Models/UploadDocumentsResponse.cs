using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class UploadDocumentsResponse
	{
		private CreateThread CreateThread { get; set; }
	}

	public class CreateThread
	{
		public bool Success { get; set; }
		[JsonProperty("thread_id")]
		public string ThreadId { get; set; }
		[JsonProperty("message_id")]
		public string MessageId { get; set; }
	}
}
