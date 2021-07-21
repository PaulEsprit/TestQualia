using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using QualiaApi2.Models;

namespace QualiaApi2
{
	public interface IQualiaService2
	{
		Task<QualiaUsersResponse> GetUsers(string token);
		Task<QualiaAgenciesResponse> GetAgencies(string token, string userId, string state);
		Task<QualiaCreateOrderResponse> CreateOrder(string token, QualiaCreateOrderRequest request);
		Task<QualiaOrderResponse> GetOrders(string token, string status)
		Task<QualiaAddOrderBasicInfoResponse> AddOrderBasicInfo(string token, QualiaAddOrderBasicInfoRequest request);
		Task<QualiaUploadDocumentsResponse> UploadDocuments(string token, QualiaUploadDocumentsRequest request);

	}
}
