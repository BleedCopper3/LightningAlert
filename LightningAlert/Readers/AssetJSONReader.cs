using LightningAlert.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert.Readers
{
    public class AssetJSONReader:IAssetReader
    {
        public List<Asset> Read(string assetText)
        {
            List<Asset>? assets = JsonConvert.DeserializeObject<List<Asset>>(assetText);

            if (assets == null) throw new Exception("Error occurred while reading Asset JSON text.");
            return assets;
        }
    }
}
