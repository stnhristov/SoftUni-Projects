using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace Actual_Game_Duh
{
    class TileLayer
    {
        private MapCell[,] map;
        private List<Texture2D> tileTextures = new List<Texture2D>();
        public TileLayer(int[,] existingMap, int[,] existingCollisionMap) 
        {
            map = new MapCell[existingMap.GetLength(0),existingMap.GetLength(1)];
            for (int y = 0; y < map.GetLength(0); y++) 
            {
                for (int x = 0; x < map.GetLength(1); x++) 
                {
                    map[y, x] = new MapCell(existingMap[y, x], existingCollisionMap[y, x]);
                }

            }
        }
        public void LoadTileTextures(ContentManager content, params string[] fileNames) 
        {
            Texture2D tileTexture;
            foreach (string filename in fileNames)
            {
                tileTexture = content.Load<Texture2D>(filename);
                tileTextures.Add(tileTexture);
            }
        }
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Begin();
            for (int y = 0; y < map.GetLength(0);y++ )
            {
                for (int x = 0; x < map.GetLength(1); x++) 
                {
                    int index = map[y, x].TileID;
                    Texture2D texture = tileTextures[index];
                    spriteBatch.Draw(texture, new Rectangle(x * Engine.TILE_WIDTH, y * Engine.TILE_HEIGHT, Engine.TILE_WIDTH, Engine.TILE_HEIGHT), Color.White);
                }
            }
                spriteBatch.End();
        }

    }
}
