using System;
using System.Collections.Generic;
using System.IO;
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

			var orderRequest = new QualiaCreateOrderRequest
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

			//var order = await service.CreateOrder(_basicToken, orderRequest);

			var basicInfoRequest = new QualiaAddOrderBasicInfoRequest
			{
				OrderId = "B4wqfCc2C6GPF4z5F",
				UserId = "5xSJPE2uirpJmHqjo",
				Data =  new QualiaAddOrderBasicInfoData
				{
					CloseDate = DateTime.Now.AddYears(2),
					LoanAmount = (decimal)3322.33,
					PurchasePrice = (decimal)4433.44
				}
			};
			//var orderInfo = await service.AddOrderBasicInfo(_basicToken, basicInfoRequest);

			var uploadDocs = new QualiaUploadDocumentsRequest
			{
				OrderId = "B4wqfCc2C6GPF4z5F",
				MessageSenderId = "5xSJPE2uirpJmHqjo",
				AgencyOnThread = true,
				ConnectedUserIds = new List<string>(),
				Message = "Docs from transaction 1213123123",
				Subject = "My Docs",
				Attachments = new List<QualiaAttachment>
				{
					new QualiaAttachment
					{
						Name = "My1.txt",
						Mime = QualiaMime.TXT,
						File = File.ReadAllBytes(@"E:\Test\propy\test.txt")

					},
					new QualiaAttachment
					{
						Name = "5e4c20977ed6df095f8dba42_1.pdf",
						Mime = QualiaMime.PDF,
						File = File.ReadAllBytes(@"E:\Test\propy\pdfs\Tests\5e4c20977ed6df095f8dba42_1.pdf")

					},
				}
			};

			var docsResp = await service.UploadDocuments(_basicToken, uploadDocs);

			var orders = await service.GetOrders(_basicToken, "Open");


			Console.ReadLine();
		}
	}
}
