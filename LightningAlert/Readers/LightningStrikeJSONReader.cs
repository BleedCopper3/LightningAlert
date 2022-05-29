using LightningAlert.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert.Readers
{
    public class LightningStrikeJSONReader : ILightningStrikeReader
    {
        public LightningStrike Read(string line)
        {
            LightningStrike? lightningStrike = JsonConvert.DeserializeObject<LightningStrike>(line);

            if (lightningStrike == null) throw new Exception("Error occured while reading Lightning Strike JSON text.");
            return lightningStrike;
        }
    }
}
