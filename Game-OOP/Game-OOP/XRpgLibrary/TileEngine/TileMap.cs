namespace XRpgLibrary.TileEngine
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TileMap
    {
        #region Field Region

        private static int mapWidth;
        private static int mapHeight;
        private readonly List<Tileset> tilesets;
        private readonly List<MapLayer> mapLayers;

        #endregion

        #region Constructor Region

        public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
        {
            this.tilesets = tilesets;
            this.mapLayers = layers;

            mapWidth = this.mapLayers[0].Width;
            mapHeight = this.mapLayers[0].Height;

            for (int i = 1; i < layers.Count; i++)
            {
                if (mapWidth != this.mapLayers[i].Width || mapHeight != this.mapLayers[i].Height)
                {
                    throw new Exception("Map layer size exception");
                }
            }
        }

        public TileMap(Tileset tileset, MapLayer layer)
        {
            this.tilesets = new List<Tileset>();
            this.tilesets.Add(tileset);

            this.mapLayers = new List<MapLayer>();
            this.mapLayers.Add(layer);

            mapWidth = this.mapLayers[0].Width;
            mapHeight = this.mapLayers[0].Height;
        }

        #endregion

        #region Property Region

        public static int WidthInPixels
        {
            get { return mapWidth * Engine.TileWidth; }
        }

        public static int HeightInPixels
        {
            get { return mapHeight * Engine.TileHeight; }
        }

        #endregion

        #region Method Region

        public void AddLayer(MapLayer layer)
        {
            if (layer.Width != mapWidth && layer.Height != mapHeight)
            {
                throw new Exception("Map layer size exception");
            }

            this.mapLayers.Add(layer);
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
            Tile tile;
            foreach (MapLayer layer in this.mapLayers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    destination.Y = (y * Engine.TileHeight) - (int)camera.Position.Y;
                    for (int x = 0; x < layer.Width; x++)
                    {
                        tile = layer.GetTile(x, y);
                        if (tile.TileIndex == -1 || tile.TileSet == -1)
                        {
                            continue;
                        }

                        destination.X = (x * Engine.TileWidth) - (int)camera.Position.X;
                        spriteBatch.Draw(
                            this.tilesets[tile.TileSet].Texture,
                            destination,
                            this.tilesets[tile.TileSet].SourceRectangles[tile.TileIndex],
                            Color.White);
                    }
                }
            }
        }

        #endregion
    }
}