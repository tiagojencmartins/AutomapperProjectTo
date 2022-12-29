using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutomapperProjectTo.Enums;
using AutomapperProjectTo.Helpers;
using AutomapperProjectTo.Models.Responses;
using AutomapperProjectTo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutomapperProjectTo.Services
{
    public class RepositoryService
    {
        private readonly IMapper _mapper;
        private readonly RepositoryContext _repositoryContext;

        public RepositoryService(IMapper mapper)
        {
            _mapper = mapper;
            _repositoryContext = new RepositoryContext();
        }

        public async Task GenerateDataAsync()
        {
            await _repositoryContext.Humans.AddRangeAsync(DataGenerator.GenerateHumansAndPets());
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task RemoveDataAsync()
        {
            _repositoryContext.Humans.RemoveRange(_repositoryContext.Humans);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<List<HumanResponse>> GetHumansWithoutProjection()
        {
            var query = await _repositoryContext
                .Humans
                .Include(_ => _.Pets)
                .Where(human => human.Pets.Any(pet => pet.PetType == PetType.Cat))
                .Take(50)
                .ToListAsync();

            return _mapper.Map<List<HumanResponse>>(query);
        }

        public async Task<List<HumanResponse>> GetHumansWithProjection()
        {
            return await _repositoryContext
                .Humans
                .Where(human => human.Pets.Any(pet => pet.PetType == PetType.Cat))
                .ProjectTo<HumanResponse>(_mapper.ConfigurationProvider)
                .Take(50)
                .ToListAsync();
        }

        public static async Task<RepositoryService> CreateAsync(IMapper mapper)
        {
            var service = new RepositoryService(mapper);
            await service.GenerateDataAsync();
            return service;
        }
    }
}
