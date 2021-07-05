using System;
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
		private readonly string _basicToken = "cHJvcHlfc2FuZGJveDozNHE2WnNDSFlxNWhKTnEwSWhLVDdtX3QxNXhsbEZ4dHYxODd2YzFCU1Rx";
		private readonly GraphQLHttpClient _client;

		public QualiaService2()
		{
			_client = new GraphQLHttpClient(_graphQlUrl, new NewtonsoftJsonSerializer());
			_client.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {_basicToken}");
		}

		public async Task<GraphQLResponse<UsersResponseType>> GetUsers()
		{
			GraphQLResponse<UsersResponseType> graphQLResponse = null;
			try
			{
				var usersRequest = new GraphQLRequest
				{
					Query = @"
						query($input: UsersInput) 
							{ usersInOrganization(input: $input)
								{ users { user_id first_name last_name email } 
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

			return graphQLResponse;
		}
	}
}
