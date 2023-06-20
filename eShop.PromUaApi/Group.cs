﻿using Newtonsoft.Json;

namespace eShop.PromUaApi
{
    public class Group
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_multilang")]
        public Multilang NameMultilang { get; set; }
    }
}