using API.Match.v1.Models;
using System;
using System.Threading.Tasks;

namespace API.Match.v1.Services
{
    public interface IClass1Service
    {
        Task<MatchModel> GetByIDAsync(Guid id);
        Task<MatchModel> GetByExternalIDAsync(string externalId);
        Task<MatchModel> AddAsync(MatchAddModel model);
        Task<MatchModel> UpdateAsync(MatchUpdateModel model);
        Task DeleteAsync(Guid id);
    }
}
