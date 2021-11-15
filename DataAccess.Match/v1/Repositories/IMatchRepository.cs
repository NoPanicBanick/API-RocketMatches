using DataAccess.Match.v1.DataEntities;
using System.Threading.Tasks;

namespace DataAccess.Match.v1.Repositories
{
    public interface IMatchRepository
    {
        Task<MatchTableEntity> AddAsync(MatchTableEntity entity);
        Task<MatchTableEntity> GetByIDAsync(string rowKey);
        Task<MatchTableEntity> UpdateAsync(MatchTableEntity entity);
        Task DeleteAsync(string rowKey);
        Task<MatchTableEntity> GetByExternalIDAsync(string externalID);
    }
}
