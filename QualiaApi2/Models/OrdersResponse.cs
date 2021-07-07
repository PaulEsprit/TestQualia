using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class OrderResponseType
	{
		public OrderInput Orders { get; set; }
	}

	public class OrderInput
	{
		public List<QualiaGetOrder> Orders { get; set; }
	}

	public class QualiaGetOrder
	{
		[JsonProperty("_id")]
		public string Id { get; set; }
		public string Status { get; set; }

	}
}


