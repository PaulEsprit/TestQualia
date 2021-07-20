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
		Task<UsersResponse> GetUsers(string token);
		Task<AgenciesResponse> GetAgencies(string token, string userId, string state);
		Task<OrderResponse> CreateOrder(string token, CreateOrderRequest request);
		Task<CreateOrderResponse> GetOrders(string token, string status);
		Task<AddOrderBasicInfoResponse> AddOrderBasicInfo(string token, AddOrderBasicInfoRequest request);
		Task<UploadDocumentsResponse> UploadDocuments(string token, UploadDocumentsRequest request);

	}
}
