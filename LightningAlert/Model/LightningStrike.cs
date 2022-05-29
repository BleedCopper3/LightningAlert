using LightningAlert.Common;
using LightningAlert.Converter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LightningAlert.Model
{
    public class LightningStrike
    {
        [JsonProperty(Required = Required.Always)]
        public FlashType FlashType { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(MillisecondUnixConverter))]
        public DateTime StrikeTime { get; set; }

        [JsonProperty(Required = Required.Always)]
        public double Latitude { get; set; }

        [JsonProperty(Required = Required.Always)]
        public double Longitude { get; set; }

        public int PeakAmps { get; set; }

        public string Reserved { get; set; }

        public int IcHeight { get; set; }

        [Newtonsoft.Json.JsonConverter(typeof(MillisecondUnixConverter))]
        public DateTime ReceivedTime { get; set; }

        public int NumberOfSensors { get; set; }

        public int Multiplicity { get; set; }
    }
}
