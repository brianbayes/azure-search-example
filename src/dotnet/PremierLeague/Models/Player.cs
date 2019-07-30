namespace PremierLeague.Models
{
    using System;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Newtonsoft.Json;

    public partial class Player
    {
        [IsSearchable]
        [JsonProperty("playerName")]
        public string PlayerName { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        [JsonProperty("playerAttributes")]
        public string[] PlayerAttributes { get; set; }
    }
}