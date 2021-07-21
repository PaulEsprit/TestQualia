using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using QualiaApi2.Models;

namespace QualiaApi2
{
	public class QualiaService2: IQualiaService2
	{
		private readonly string _graphQlUrl = "https://sandbox-connect.qualia.io/api/partner/graphql";
		private readonly GraphQLHttpClient _client;

		public QualiaService2()
		{
			_client = new GraphQLHttpClient(_graphQlUrl, new NewtonsoftJsonSerializer());
		}

		public async Task<QualiaUsersResponse> GetUsers(string token)
		{
			GraphQLResponse<QualiaUsersResponse> graphQLResponse = null;
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

				graphQLResponse = await _client.SendQueryAsync<QualiaUsersResponse>(usersRequest);
			}
			catch (Exception e)
			{

			}

			return graphQLResponse?.Data;
		}

		public async Task<QualiaAgenciesResponse> GetAgencies(string token, string userId, string state)
		{
			GraphQLResponse<QualiaAgenciesResponse> graphQLResponse = null;
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

				graphQLResponse = await _client.SendQueryAsync<QualiaAgenciesResponse>(agenciesRequest);
			}
			catch (Exception e)
			{

			}

			return graphQLResponse?.Data;
		}

		public async Task<QualiaCreateOrderResponse> CreateOrder(string token, QualiaCreateOrderRequest request)
		{
			GraphQLResponse<QualiaCreateOrderResponse> graphQLResponse = null;
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
				var orderRequest = new GraphQLRequest
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

				graphQLResponse = await _client.SendMutationAsync<QualiaCreateOrderResponse>(orderRequest);
			}
			catch (Exception e)
			{

			}
			return graphQLResponse?.Data;
		}

		public async Task<QualiaAddOrderBasicInfoResponse> AddOrderBasicInfo(string token, QualiaAddOrderBasicInfoRequest request)
		{
			GraphQLResponse<QualiaAddOrderBasicInfoResponse> graphQLResponse = null;
			AddAuthorizationToken(token);
			try
			{

				var data = new
				{
					estimated_close_date = request.Data.CloseDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
					loan_amount = request.Data.LoanAmount.ToString("##.###"),
					purchase_price = request.Data.PurchasePrice.ToString("##.###")
				};

				var orderRequest = new GraphQLRequest
				{
					Query = @"
							mutation($input: AddOrderBasicInfoInput!) { addOrderBasicInfo(input: $input)
								{ order_id } 
							}",
					OperationName = "",
					Variables = new
					{
						input = new
						{
							order_id = request.OrderId,
							user_id = request.UserId,
							data = data,
						}
					}
				};

				graphQLResponse = await _client.SendMutationAsync<QualiaAddOrderBasicInfoResponse>(orderRequest);
			}
			catch (Exception e)
			{

			}
			return graphQLResponse?.Data;
		}

		public async Task<QualiaUploadDocumentsResponse> UploadDocuments(string token, QualiaUploadDocumentsRequest request)
		{
			GraphQLResponse<QualiaUploadDocumentsResponse> graphQLResponse = null;
			AddAuthorizationToken(token);
			try
			{

				var attachments = request.Attachments.Select(x => new
				{
					name = x.Name,
					base_64 = Convert.ToBase64String(x.File),
					mime = x.Mime.ToString()
				}).ToArray();

				var orderRequest = new GraphQLRequest
				{
					Query = @"
							mutation CreateThread($input: CreateThreadInput!) {
								createThread(input: $input)
									{ success thread_id message_id }
							}",
					OperationName = "CreateThread",
					Variables = new
					{
						input = new
						{
							order_id = request.OrderId,
							settlement_agency_on_thread = request.AgencyOnThread,
							message_sender_id = request.MessageSenderId,
							connect_user_ids = request.ConnectedUserIds.ToArray(),
							subject = request.Subject,
							message = request.Message,
							attachments = attachments,
						}
					}
				};

				graphQLResponse = await _client.SendMutationAsync<QualiaUploadDocumentsResponse>(orderRequest);
			}
			catch (Exception e)
			{

			}
			return graphQLResponse?.Data;
		}

		public async Task<QualiaOrderResponse> GetOrders(string token, string status)
		{
			GraphQLResponse<QualiaOrderResponse> graphQLResponse = null;
			AddAuthorizationToken(token);
			try
			{
				var ordersRequest = new GraphQLRequest
				{
					Query = @"
						query($input: OrdersInput) 
							{ orders(input: $input)
								{ orders { _id  status  } } }",
					OperationName = "",
					Variables = new
					{
						input = new { status = status }
					}
				};

				graphQLResponse = await _client.SendQueryAsync<QualiaOrderResponse>(ordersRequest);
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
