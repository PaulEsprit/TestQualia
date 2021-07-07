using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using QualiaApi2;
using QualiaApi2.Models;

namespace QualiaClient
{
	class Program
	{
		private static string _basicToken = "cHJvcHlfc2FuZGJveDozNHE2WnNDSFlxNWhKTnEwSWhLVDdtX3QxNXhsbEZ4dHYxODd2YzFCU1Rx";
		static async Task Main(string[] args)
		{
			var service = new QualiaService2();
			
			var users = await service.GetUsers(_basicToken);

			var agencies = await service.GetAgencies(_basicToken, "5xSJPE2uirpJmHqjo", "CA");

			var orderRequest = new CreateOrderRequest
			{
				AgencyId = "HMXscM3Dge3gJfqmb",
				Contacts = new List<QualiaContact>
				{
					new QualiaContact
					{
						Email = "yuriy.dovhopol@advantiss.com",
						EntityType = "INDIVIDUAL",
						FirstName = "Yur",
						LastName = "Dov",
						RoleType = "BORROWERS"
					}
				},
				OrderPlacerEmail = "yuriy.dovhopol@propy.com",
				OrderPlacerFirstName = "Yuriy",
				OrderPlacerLastName = "Dovhopol",
				OrderPlacerOrgName = "Best Seller inc",
				OrderPlacerRoleType = "SELLING_AGENTS",
				OrderingMemo = "Memo",
				OrderingUserId = "5xSJPE2uirpJmHqjo",
				Properties = new List<QualiaPropertyAddress>
				{
					new QualiaPropertyAddress
					{
						AddressLine1 = "Dallas str 123",
						City = "Dallas",
						State = "TX",
						ZipCode = "97000"
					}
				},
				Purpose = "PURCHASE"
			};

			var order = await service.CreateOrder(_basicToken, orderRequest);

			var orders = await service.GetOrders(_basicToken, "Pending");


			Console.ReadLine();
		}
	}
}
