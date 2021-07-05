using System;
using System.Threading.Tasks;
using QualiaApi2;

namespace QualiaClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var service = new QualiaService2();

			var res = await service.GetUsers();

			Console.ReadLine();
		}
	}
}
