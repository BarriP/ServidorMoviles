using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServidorMoviles.Utils;

namespace ServidorMoviles.Models
{
    public partial class Bar
    {
        public Bar()
        {
            Tapa = new HashSet<Tapa>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Rating { get; set; }
        [JsonIgnore]
        public string PhotoUrl { get; set; }
        public string Image => $"{ConfigurationManager.Instance.HostUrl}/{PhotoUrl}";

        public ICollection<Tapa> Tapa { get; set; }
    }
}
