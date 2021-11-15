using API.Match.v1.Models;
using AutoMapper;
using DataAccess.Match.v1.DataEntities;
using DataAccess.Match.v1.Repositories;
using System;
using System.Threading.Tasks;

namespace API.Match.v1.Services
{
    public class Class1Service : IClass1Service
    {
        private readonly IMapper _mapper;
        private readonly IMatchRepository _Class1Repository;

        public Class1Service(IMapper mapper, IMatchRepository Class1Repository)
        {
            _mapper = mapper;
            _Class1Repository = Class1Repository;
        }

        public async Task<MatchModel> GetByIDAsync(Guid id)
        {
            var response = await _Class1Repository.GetByIDAsync(id.ToString());
            return _mapper.Map<MatchModel>(response);
        }

        public async Task<MatchModel> GetByExternalIDAsync(string externalId)
        {
            var response = await _Class1Repository.GetByIDAsync(externalId);
            return _mapper.Map<MatchModel>(response);
        }

        public async Task<MatchModel> AddAsync(MatchAddModel model)
        {
            var entity = _mapper.Map<MatchTableEntity>(model);
            var response = await _Class1Repository.AddAsync(entity);
            return _mapper.Map<MatchModel>(response);
        }

        public async Task<MatchModel> UpdateAsync(MatchUpdateModel model)
        {
            var entity = _mapper.Map<MatchTableEntity>(model);
            var response = await _Class1Repository.UpdateAsync(entity);
            return _mapper.Map<MatchModel>(response);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _Class1Repository.DeleteAsync(id.ToString());
        }
    }
}
