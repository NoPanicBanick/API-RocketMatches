using DataAccess.Match.v1.DataEntities;
using Microsoft.Azure.Cosmos.Table;
using PoorMan;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Match.v1.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private const string _defaultPartionKey = "1";
        private readonly ITable<MatchTableEntity> _tableService;

        public MatchRepository(ITable<MatchTableEntity> tableService)
        {
            _tableService = tableService;
        }

        public async Task<MatchTableEntity> AddAsync(MatchTableEntity entity)
        {
            entity.RowKey = Guid.NewGuid().ToString();
            entity.PartitionKey = _defaultPartionKey;
            return await _tableService.AddAsync(entity);
        }

        public async Task<MatchTableEntity> GetByIDAsync(string rowKey)
        {
            return await _tableService.GetAsync(_defaultPartionKey, rowKey);
        }

        public async Task<MatchTableEntity> GetByExternalIDAsync(string externalID)
        {
            var query = TableQuery.GenerateFilterCondition(nameof(MatchTableEntity.ExternalID), QueryComparisons.Equal, externalID);
            return (await _tableService.QueryAsync(query)).FirstOrDefault();
        }

        public async Task<MatchTableEntity> UpdateAsync(MatchTableEntity entity)
        {
            entity.PartitionKey = _defaultPartionKey;
            return await _tableService.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string rowKey)
        {
            await _tableService.DeleteAsync(_defaultPartionKey, rowKey);
        }
    }
}
