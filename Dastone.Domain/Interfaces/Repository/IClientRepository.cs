using Dastone.Domain.Entity;
using Dastone.Domain.Enum;
using Dastone.Domain.Interfaces.Repository.Base;

namespace Dastone.Domain.Interfaces.Repository
{
    public interface IClientRepository:IRepositoryBase<Client>
    {
        IQueryable<Client> GetAllActive(Situations pSituations);
    }
}
