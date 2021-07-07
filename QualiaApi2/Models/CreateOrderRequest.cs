using System;
using System.Collections.Generic;
using System.Text;

namespace QualiaApi2.Models
{
	public class CreateOrderRequest
	{
		public string Purpose { get; set; }
		public string AgencyId { get; set; }
		public string OrderingUserId { get; set; }
		public string OrderingMemo { get; set; }
		public string OrderPlacerFirstName { get; set; }
		public string OrderPlacerLastName { get; set; }
		public string OrderPlacerOrgName { get; set; }
		public string OrderPlacerEmail { get; set; }
		public string OrderPlacerRoleType { get; set; }
		public List<QualiaPropertyAddress> Properties { get; set; }
		public List<QualiaContact> Contacts { get; set; }
	}

	public class QualiaPropertyAddress
	{
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
	}

	public class QualiaContact
	{
		public string RoleType { get; set; }
		public string Email { get; set; }
		public string EntityType { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
}
