using Dastone.Data.Context;
using Dastone.Data.Repository.Base;
using Dastone.Domain.Entity;
using Dastone.Domain.Enum;
using Dastone.Domain.Interfaces.Repository;

namespace Dastone.Data.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DastoneDbContext _pDastoneDbContext) : base(_pDastoneDbContext)
        {
        }

        public IQueryable<Client> GetAllActive(Situations pSituations)
        {
            var result = GetAll(c => c.Situations == pSituations);
            return result;
        }
    }
}
