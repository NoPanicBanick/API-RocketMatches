using Microsoft.Azure.Cosmos.Table;
using PoorMan;
using System;

namespace DataAccess.Match.v1.DataEntities
{
    public class MatchTableEntity : TableEntity, IAudit
    {
        public Guid ExternalID { get; set; }
        
        //public string Playlist { get; set; } // This is going to be the partition key
        public int BlueTeamScore { get; set; }
        public int RedTeamScore { get; set; }
        public DateTime CreatedOnUTCDate { get; set; }
        public DateTime LastModifiedOnUTCDate { get; set; }
    }
}
