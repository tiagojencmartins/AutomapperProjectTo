using ImplicitOperator.Models;
using ImplicitOperator.Repositories;
using ImplicitOperator.Types;
using Microsoft.EntityFrameworkCore;

namespace ImplicitOperator.Services
{
    public class RepositoryService
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryService()
        {
            _repositoryContext = new RepositoryContext();
        }

        public async Task<List<Human>> GetHumansWithCatsAsync()
        {
            return await _repositoryContext
                .Humans
                .Include(_ => _.Pets)
                .Where(human => human.Pets.Any(pet => pet.PetType == PetType.Cat))
                .Take(50)
                .ToListAsync();
        }
    }
}
