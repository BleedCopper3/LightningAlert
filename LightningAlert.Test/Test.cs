using LightningAlert.Converter;
using LightningAlert.Model;
using LightningAlert.Readers;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LightningAlert.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void DuplicateAsset_ShouldNotFail()
        {
            AssetCache cache = new AssetCache();
            Asset sample = new Asset()
            {
                AssetName = "Sample",
                QuadKey = "123",
                AssetOwner = 456
            };

            cache.AddAsset(sample);
            cache.AddAsset(sample);
        }

        [TestMethod]
        public void MissingAsset_ShouldNotFail()
        {
            AssetCache cache = new AssetCache();
            LightningOnAsset la = new LightningOnAsset(cache);

            Asset? asset = la.GetAssetStruckByLightning(new LightningStrike() { Longitude = 0, Latitude = 0 });
            Assert.IsNull(asset);
        }

        [TestMethod]
        [ExpectedException(typeof(Newtonsoft.Json.JsonSerializationException))]
        public void IncorrectAssetFormat_ShouldThrowError()
        {
            string asset = "[{\"quadKey\":\"023112133033\", \"assetOwner\":\"6720\"}]";
            IAssetReader reader = new AssetJSONReader();
            List<Asset> assetList = reader.Read(asset);
        }

        [TestMethod]
        [ExpectedException(typeof(Newtonsoft.Json.JsonSerializationException))]
        public void IncorrectLightningFormat_ShouldThrowError()
        {
            string lightningStrike = "[{\"flashType\":\"6\", \"strikeTime\":abcd}]";
            ILightningStrikeReader reader = new LightningStrikeJSONReader();
            LightningStrike strike = reader.Read(lightningStrike);
        }
    }
}