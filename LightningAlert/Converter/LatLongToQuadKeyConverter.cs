using Microsoft.MapPoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningAlert.Converter
{
    public class LatLongToQuadKeyConverter
    {
        private const int DEFAULT_ZOOM = 12;
        public static string LatLongToQuadKey(double latitude, double longitude, int zoom = DEFAULT_ZOOM)
        {
            int xPix, yPix, xTile, yTile;

            TileSystem.LatLongToPixelXY(latitude, longitude, zoom, out xPix, out yPix);
            TileSystem.PixelXYToTileXY(xPix, yPix, out xTile, out yTile);
            return TileSystem.TileXYToQuadKey(xTile, yTile, zoom);

        }
    }
}
