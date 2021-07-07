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
	}
}
