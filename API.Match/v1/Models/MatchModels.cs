using System;

namespace API.Match.v1.Models
{
    /* 
     * Opted to be explicit here versus using inheritance.
     * If complexity increases, consider changing this strategy.
     */

    public class MatchModel : BaseModel
    {
        public Guid ID { get; set; }
        public Guid ExternalID { get; set; }
        public string Playlist { get; set; }
        public int BlueTeamScore { get; set; }
        public int RedTeamScore { get; set; }
    }

    public class MatchAddModel
    {
        public Guid ExternalID { get; set; }
        public string Playlist { get; set; }
        public int BlueTeamScore { get; set; }
        public int RedTeamScore { get; set; }

    }

    public class MatchUpdateModel
    {
        public Guid ID { get; set; }
        public Guid ExternalID { get; set; }
        public string Playlist { get; set; }
        public int BlueTeamScore { get; set; }
        public int RedTeamScore { get; set; }
        public string ETag { get; set; }
    }
}
