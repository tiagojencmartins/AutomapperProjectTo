using AutoMapper;
using BenchmarkDotNet.Attributes;
using ImplicitOperator.Mappers;
using ImplicitOperator.Models;
using ImplicitOperator.Models.Responses;
using ImplicitOperator.Profiles;
using ImplicitOperator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImplicitOperator
{
    [MemoryDiagnoser(false)]
    public class BenchmarkDI
    {
        private IMapper _mapper;
        private RepositoryService _repositoryService;
        private List<Human> _humanList;

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public async Task Setup()
        {
            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(HumanProfile));

            var serviceProvider = services.BuildServiceProvider();

            _mapper = serviceProvider.GetRequiredService<IMapper>();

            _repositoryService = new RepositoryService();
            _humanList = await _repositoryService.GetHumansWithCatsAsync();
        }

        [Benchmark]
        public void WithAutomapper()
        {
            foreach (var human in _humanList)
            {
                _ = _mapper.Map<HumanResponse>(human);
            }
        }

        [Benchmark]
        public void WithImplicitOperator()
        {
            foreach (var human in _humanList)
            {
                HumanResponse _ = human;
            }
        }

        [Benchmark]
        public void WithExtensionMethod()
        {
            foreach (var human in _humanList)
            {
                _ = human.ToHumanResponse();
            }
        }
    }
}
