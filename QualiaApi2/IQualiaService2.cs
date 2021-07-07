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
		Task<UsersResponseType> GetUsers(string token);
		Task<AgenciesResponseType> GetAgencies(string token, string userId, string state);
		Task<OrderResponseType> CreateOrder(string token, CreateOrderRequest request);
		Task<CreateOrderResponseType> GetOrders(string token, string status);

	}
}
