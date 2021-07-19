using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class AddOrderBasicInfoResponse
	{
		public AddOrderBasicInfo AddOrderBasicInfo { get; set; }
	}

	public class AddOrderBasicInfo
	{
		[JsonProperty("order_id")]
		public string OrderId { get; set; }
	}
}
