using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace gRPCService.Services
{
    public class PeopleService : People.PeopleBase
    {
        private readonly ILogger<PeopleService> _logger;
        public PeopleService(ILogger<PeopleService> logger)
        {
            _logger = logger;
        }

        public override Task<PeopleResponse> GetPeople(PeopleRequest request, ServerCallContext context)
        {
            return Task.FromResult(new PeopleResponse
            {
                Name = "Alison",
                Cpf = "02161828088",
                Age = 30,
                Created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            });
        }

        public override Task<StringDto> HealthProve(StringDto request, ServerCallContext context)
        {
            return Task.FromResult(new StringDto
            {
                Message = "OK"
            });
        }
    }
}
