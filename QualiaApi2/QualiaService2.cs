using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using QualiaApi2.Models;

namespace QualiaApi2
{
	public class QualiaService2
	{
		private readonly string _graphQlUrl = "https://sandbox-connect.qualia.io/api/partner/graphql";
		private readonly GraphQLHttpClient _client;

		public QualiaService2()
		{
			_client = new GraphQLHttpClient(_graphQlUrl, new NewtonsoftJsonSerializer());
		}

		public async Task<UsersResponseType> GetUsers(string token)
		{
			GraphQLResponse<UsersResponseType> graphQLResponse = null;
			AddAuthorizationToken(token);
			try
			{
				var usersRequest = new GraphQLRequest
				{
					Query = @"
						query($input: UsersInput) 
							{ usersInOrganization(input: $input)
								{ users 
									{ user_id first_name last_name email } 
								}
							}",
					OperationName = "",
					Variables = new
					{
						input = new {limit = 5, offset = 5}
					}
				};

				graphQLResponse = await _client.SendQueryAsync<UsersResponseType>(usersRequest);
			}
			catch (Exception e)
			{

			}

			return graphQLResponse?.Data;
		}

		public async Task<AgenciesResponseType> GetAgencies(string token, string userId, string state)
		{
			GraphQLResponse<AgenciesResponseType> graphQLResponse = null;
			AddAuthorizationToken(token);
			try
			{
				var agenciesRequest = new GraphQLRequest
				{
					Query = @"
						query getSettlementAgencies($input: AvailableSettlementAgenciesInput!) 
							{ availableSettlementAgencies(input: $input)
									{ settlement_agencies 
										{ _id name } 
									} 
							}",
					OperationName = "getSettlementAgencies",
					Variables = new
					{
						input = new { ordering_user_id = userId, state = state }
					}
				};

				graphQLResponse = await _client.SendQueryAsync<AgenciesResponseType>(agenciesRequest);
			}
			catch (Exception e)
			{

			}

			return graphQLResponse?.Data;
		}

		public async Task<OrderResponseType> CreateOrder(string token, OrderRequest request)
		{
			GraphQLResponse<OrderResponseType> graphQLResponse = null;
			AddAuthorizationToken(token);
			try
			{
				var properties = new List<dynamic>();
				foreach (var property in request.Properties)
				{
					properties.Add(new
					{
						address_line_1 = property.AddressLine1,
						city = property.City,
						state = property.State,
						zipcode =  property.ZipCode
					});
				}

				var contacts = new List<dynamic>();
				foreach (var contact in request.Contacts)
				{
					contacts.Add(new
					{
						role_type = contact.RoleType,
						email = contact.Email,
						entity_type = contact.EntityType,
						first_name = contact.FirstName,
						last_name = contact.LastName
					});
				}
				var agenciesRequest = new GraphQLRequest
				{
					Query = @"
							mutation($input: PlaceOrderInput) 
							{ 
								placeOrder(input: $input)
									{ success order{ _id } } 
							}",
					OperationName = "",
					Variables = new
					{
						input = new
						{
							purpose = request.Purpose,
							settlement_agency_id = request.AgencyId,
							properties = properties,
							ordering_user_id = request.OrderingUserId,
							ordering_memo = request.OrderingMemo,
							contacts = contacts,
							order_placer_first_name = request.OrderPlacerFirstName,
							order_placer_last_name = request.OrderPlacerLastName,
							order_placer_organization_name = request.OrderPlacerOrgName,
							order_placer_email = request.OrderPlacerEmail,
							order_placer_role_type = request.OrderPlacerRoleType,

						}
					}
				};

				graphQLResponse = await _client.SendMutationAsync<OrderResponseType>(agenciesRequest);
			}
			catch (Exception e)
			{

			}
			return graphQLResponse?.Data;
		}

		private void AddAuthorizationToken(string token)
		{
			if (_client.HttpClient.DefaultRequestHeaders.Contains("Authorization"))
			{
				_client.HttpClient.DefaultRequestHeaders.Remove("Authorization");
			}

			_client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
		}
	}
}
