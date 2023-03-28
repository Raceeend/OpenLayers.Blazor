﻿namespace OpenLayers.Blazor;

public class SwissMap : Map
{
    public SwissMap()
    {
        Layers.Add(new TileLayer()
        {
            Extent = new double[] {2420000, 1030000, 2900000, 1350000},
            Source =
                new TileSource()
                {
                    SourceType = SourceType.TileWMS,
                    Url = "https://wms.geo.admin.ch/",
                    CrossOrigin = "anonymous",
                    Params = new Dictionary<string, object>() { { "LAYERS", "ch.swisstopo.pixelkarte-farbe" }, { "FORMAT", "image/jpeg" } },
                    ServerType = "mapserver",
                    Attributions = "© <a href=\"https://www.swisstopo.admin.ch/en/home.html\" target=\"_blank\">swisstopo</a>"
                }
        });
        Center = new Coordinate { X = 2660013.54, Y = 1185171.98 }; // Swiss Center
        Zoom = 2.4;
        Defaults.CoordinatesProjection = "EPSG:2056"; // VT95 // VT03="EPSG:21781" // WG83 "EPSG:4326";
    }

    /// <summary>
    /// e.g. ch.astra.wanderland-sperrungen_umleitungen
    /// </summary>
    /// <param name="layerId"></param>
    public void AddLayer(string layerId)
    {
        Layers.Add(new TileLayer()
        {
            Opacity = .8,
            Source = new TileSource()
            {
                SourceType = SourceType.TileWMS,
                Url = $"https://wms0.geo.admin.ch/?SERVICE=WMS&VERSION=1.3.0&REQUEST=GetMap&FORMAT=image%2Fpng&TRANSPARENT=true&LAYERS={layerId}&LANG=en"
            }
        });
        
    }
}