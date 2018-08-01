﻿using Newtonsoft.Json;

namespace MSAzureCogServiceExamples.Models.BingSearch
{
    public class Thumbnail
    {
        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
    }
}
