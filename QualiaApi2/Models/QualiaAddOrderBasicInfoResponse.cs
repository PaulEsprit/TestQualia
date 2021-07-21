using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class QualiaAddOrderBasicInfoResponse
	{
		public QualiaAddOrderBasicInfo AddOrderBasicInfo { get; set; }
	}

	public class QualiaAddOrderBasicInfo
	{
		[JsonProperty("order_id")]
		public string OrderId { get; set; }
	}
}
