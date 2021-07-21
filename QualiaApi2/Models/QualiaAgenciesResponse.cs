using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class QualiaAgenciesResponse
	{
		public QualiaSettlementAgencies AvailableSettlementAgencies { get; set; }
	}

	public class QualiaSettlementAgencies
	{
		[JsonProperty("settlement_agencies")]
		public List<QualiaAgency> Agencies { get; set; }
	}

	public class QualiaAgency
	{
		[JsonProperty("_id")]
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
