using System;
using System.Collections.Generic;
using System.Text;

namespace QualiaApi2.Models
{
	public class QualiaAddOrderBasicInfoRequest
	{
		public string OrderId { get; set; }
		public string UserId { get; set; }
		public QualiaAddOrderBasicInfoData Data { get; set; }
	}

	public class QualiaAddOrderBasicInfoData
	{
		public DateTime CloseDate { get; set; }
		public decimal LoanAmount { get; set; }
		public decimal PurchasePrice { get; set; }

	}
}
