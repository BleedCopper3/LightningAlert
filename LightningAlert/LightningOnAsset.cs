using LightningAlert.Converter;
using LightningAlert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert
{
    public class LightningOnAsset
    {
        HashSet<string> assetsWithLightning = new HashSet<string>();
        private AssetCache assetCache;
        public LightningOnAsset(AssetCache assetCache)
        {
            this.assetCache = assetCache;
        }

        public Asset? GetAssetStruckByLightning(LightningStrike lightningStrike)
        {
            Asset? asset = null;
            string quadKey = LatLongToQuadKeyConverter.LatLongToQuadKey(lightningStrike.Latitude, lightningStrike.Longitude);

            if (!assetsWithLightning.Contains(quadKey))
            {
                asset = assetCache.GetAssetAtQuadKey(quadKey);
                if (asset != null)
                {
                    assetsWithLightning.Add(quadKey);
                }
            }

            return asset;
        }
    }
}
