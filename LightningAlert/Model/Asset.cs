using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert.Model
{
    public class Asset
    {
        [JsonProperty(Required = Required.Always)]
        public string AssetName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string QuadKey { get; set; }
        [JsonProperty(Required = Required.Always)]
        public long AssetOwner { get; set; }
    }
}
