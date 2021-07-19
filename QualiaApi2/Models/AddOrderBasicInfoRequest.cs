using System;
using System.Collections.Generic;
using System.Text;

namespace QualiaApi2.Models
{
	public class AddOrderBasicInfoRequest
	{
		public string OrderId { get; set; }
		public string UserId { get; set; }
		public AddOrderBasicInfoData Data { get; set; }
	}

	public class AddOrderBasicInfoData
	{
		public DateTime CloseDate { get; set; }
		public decimal LoanAmount { get; set; }
		public decimal PurchasePrice { get; set; }

	}
}
