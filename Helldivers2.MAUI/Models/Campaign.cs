using Newtonsoft.Json;

namespace Helldivers2.MAUI.Models
{
    public class Campaign
    {
        [JsonProperty("planetIndex")]
        public int PlanetIndex { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("faction")]
        public string? Faction { get; set; }

        [JsonProperty("players")]
        public int Players { get; set; }

        [JsonProperty("health")]
        public int Health { get; set; }

        [JsonProperty("maxHealth")]
        public int MaxHealth { get; set; }

        [JsonProperty("percentage")]
        public float Percentage { get; set; }

        [JsonProperty("defense")]
        public bool Defense { get; set; }

        [JsonProperty("majorOrder")]
        public bool MajorOrder { get; set; }

        [JsonProperty("biome")]
        public Biome? Biome { get; set; }

        [JsonProperty("expireDateTime")]
        public float? expireDateTime { get; set; }
    }

    public class Biome
    {
        [JsonProperty("slug")]
        public string? Slug { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}