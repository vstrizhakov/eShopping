﻿using Newtonsoft.Json;

namespace eShop.PromUaApi
{
    public class Multilang
    {
        [JsonProperty("ru")]
        public string Ru { get; set; }

        [JsonProperty("uk")]
        public string Uk { get; set; }
    }
}