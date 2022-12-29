using AutoMapper;
using AutomapperProjectTo.Models.Responses;
using AutomapperProjectTo.Profiles;
using AutomapperProjectTo.Services;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace AutomapperProjectTo
{
    [MemoryDiagnoser(false)]
    public class BenchmarkDI
    {
        private RepositoryService _repositoryService;

        [Params(10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(HumanProfile));

            var serviceProvider = services.BuildServiceProvider();

            _repositoryService = new RepositoryService(serviceProvider.GetRequiredService<IMapper>());
        }

        [Benchmark]
        public async Task<List<HumanResponse>> GetHumansWithoutProjection() => await _repositoryService.GetHumansWithoutProjection();

        [Benchmark]
        public async Task<List<HumanResponse>> GetHumansWithProjection() => await _repositoryService.GetHumansWithProjection();
    }
}
