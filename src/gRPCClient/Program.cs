using Grpc.Net.Client;
using gRPCService;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace gRPCClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Account.AccountClient(channel);
            var reply = await client.HealthProveAsync(new StringResponse { Message = "Ok" });
            Console.WriteLine("HealthProve gRPC.Account: " + reply.Message);

            var replyTwo = await client.GetAccountAsync(new AccountRequest { Cpf = "02161828088" });
            Console.WriteLine("GetAccount gRPC.Account: " + JsonSerializer.Serialize(replyTwo));

            var clientPeople = new People.PeopleClient(channel);
            var replyPeople = await clientPeople.HealthProveAsync(new StringDto { Message = "Ok" });
            Console.WriteLine("HealthProve gRPC.People: " + replyPeople.Message);

            var replyPeopleTwo = await clientPeople.GetPeopleAsync(new PeopleRequest { Cpf = "02161828088" });
            Console.WriteLine("GetPeople gRPC.People: " + JsonSerializer.Serialize(replyPeopleTwo));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
