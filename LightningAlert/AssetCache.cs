using LightningAlert.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert
{
    public class AssetCache
    {
        private Dictionary<string, Asset> assetDict;
        public AssetCache()
        {
            this.assetDict = new Dictionary<string, Asset>();
        }

        public void AddAsset(Asset asset)
        {
            if (!assetDict.ContainsKey(asset.QuadKey))
            {
                assetDict[asset.QuadKey] = asset;
            }
        }

        public Asset? GetAssetAtQuadKey(string quadKey)
        {
            if (assetDict.ContainsKey(quadKey)) return assetDict[quadKey];

            return null;
        }
    }
}