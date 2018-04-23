using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServidorMoviles.Utils;

namespace ServidorMoviles.Models
{
    public partial class Tapa
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Category { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public long? BarId { get; set; }

        [JsonIgnore]
        public string PhotoUrl { get; set; }
        public string Image => $"{ConfigurationManager.Instance.HostUrl}/{PhotoUrl}";

        [JsonIgnore]
        public Bar Bar { get; set; }
    }
}
