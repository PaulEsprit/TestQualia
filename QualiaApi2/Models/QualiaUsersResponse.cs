using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QualiaApi2.Models
{
	public class QualiaUsersResponse
	{
		public QualiaUsersInOrganization UsersInOrganization { get; set; }
	}

	public class QualiaUsersInOrganization
	{
		public List<QualiaUser> Users { get; set; }
	}

	public class QualiaUser
	{
		[JsonProperty("user_id")]
		public string UserId { get; set; }
		[JsonProperty("first_name")]
		public string FirstName { get; set; }
		[JsonProperty("last_name")]
		public string LastName { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
