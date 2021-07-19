using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class CreateOrderResponse
	{
		public PlaceOrder PlaceOrder { get; set; }
	}

	public class PlaceOrder
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
