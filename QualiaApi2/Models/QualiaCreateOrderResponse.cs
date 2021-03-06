using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class QualiaCreateOrderResponse
	{
		public QualiaPlaceOrder PlaceOrder { get; set; }
	}

	public class QualiaPlaceOrder
	{
		public bool Success { get; set; }
		public QualiaOrder Order { get; set; }
	}

	public class QualiaOrder
	{
		[JsonProperty("_id")]
		public string Id { get; set; }
	}
}
