namespace PremierLeague.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Newtonsoft.Json;

    public partial class Team
    {
        [System.ComponentModel.DataAnnotations.Key]
        [IsFilterable]
        [JsonProperty("teamId")]
        public string TeamId { get; set; }

        [IsSearchable, IsSortable]
        [JsonProperty("teamName")]
        public string TeamName { get; set; }

        [IsSearchable, IsSortable]
        [JsonProperty("stadium")]
        public string Stadium { get; set; }

        [IsSearchable, IsSortable]
        [JsonProperty("players")]
        public List<Player> Players { get; set; }
    }
}