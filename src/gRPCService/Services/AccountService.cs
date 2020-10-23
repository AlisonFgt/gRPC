using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gRPCService.Services
{
    public class AccountService : Account.AccountBase
    {
        private readonly ILogger<AccountService> _logger;
        public AccountService(ILogger<AccountService> logger)
        {
            _logger = logger;
        }

        public override Task<AccountResponse> GetAccount(AccountRequest request, ServerCallContext context)
        {
            return Task.FromResult(new AccountResponse
            {
                Name = "Alison",
                AccountNumer = 123456,
                AgencyNumber = 7,
                Created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        public override Task<StringResponse> HealthProve(StringResponse request, ServerCallContext context)
        {
            return Task.FromResult(new StringResponse
            {
                Message = "OK"
            });
        }
    }
}
