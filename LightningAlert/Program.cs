using LightningAlert;
using LightningAlert.Common;
using LightningAlert.Model;
using LightningAlert.Readers;

if (args.Length != 2) throw new Exception("Please provide paths to assets and lightning strikes.");

string assetPath = args[0];
string assetText = File.ReadAllText(assetPath);

string lightningPath = args[1];
string[] lightningEntries = File.ReadAllLines(lightningPath);

IAssetReader assetReader = new AssetJSONReader();
AssetCache assetCache = PrepareAssetCache(assetReader, assetText);
LightningOnAsset lightningAsset = new LightningOnAsset(assetCache);

ILightningStrikeReader lsReader = new LightningStrikeJSONReader();
foreach (string line in lightningEntries)
{
    ProcessLightningText(lightningAsset, lsReader, line);
}
Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();

static AssetCache PrepareAssetCache(IAssetReader assetReader, string assetText)
{
    List<Asset> assetList = new List<Asset>();
    AssetCache assetCache = new AssetCache();
    try
    {
        assetList = assetReader.Read(assetText);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    foreach (Asset asset in assetList)
    {
        if (assetCache.GetAssetAtQuadKey(asset.QuadKey) == null)
        {
            assetCache.AddAsset(asset);
        }
        else
        {
            Console.WriteLine("Asset at location quadkey {0} already exists.", asset.QuadKey);
        }
    }

    return assetCache;
}

static void ProcessLightningText(LightningOnAsset lightningAsset, ILightningStrikeReader lsReader, string lightningText)
{
    LightningStrike? lightningStrike = null;
    try
    {
        lightningStrike = lsReader.Read(lightningText);
    }
    catch (Exception e)
    {
        Console.WriteLine("Error on reading lightning strike. Please confirm its format.");
    }

    if(lightningStrike != null && lightningStrike.FlashType != FlashType.Heartbeat)
    {
        Asset? struckAsset = lightningAsset.GetAssetStruckByLightning(lightningStrike);
        if (struckAsset != null)
        {
            System.Console.WriteLine("lightning alert for {0}:{1}", struckAsset.AssetOwner, struckAsset.AssetName);
        }
    }
}