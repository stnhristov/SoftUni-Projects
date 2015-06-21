using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary;
using XRpgLibrary.TileEngine;

using RPG_Demo1.Component;
namespace RPG_Demo1.GameScreens
{
    public class GamePlayScreen:BaseGameState
    {
        #region Field Region

        Engine engine = new Engine(32, 32);
        Tileset tileset;
        TileMap map;
        Player player;
        Song song;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager) 
        {
            player = new Player(game);
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/starterTileSet1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/tileset2");
            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            List<Tileset> tilesets = new List<Tileset>();
            tilesets.Add(tileset1);
            tilesets.Add(tileset2);

            MapLayer layer = new MapLayer(40, 40);

            for (int y = 0; y < layer.Height; y++) 
            {
                for (int x = 0; x < layer.Width; x++) 
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

           MapLayer splatter = new MapLayer(40, 40);

           Random random = new Random();
          
           for (int i = 0; i < 80; i++) 
           {
               int x = random.Next(0, 40);
               int y = random.Next(0, 40);
               int index = random.Next(2, 14);
          
               Tile tile = new Tile(index,0);
               splatter.SetTile(x, y, tile);
           }
           splatter.SetTile(1, 1, new Tile(0, 1));
           splatter.SetTile(2, 1, new Tile(2, 1));
           splatter.SetTile(3, 1, new Tile(0, 1));
           splatter.SetTile(4, 1, new Tile(0, 1));
           splatter.SetTile(1, 0, new Tile(17, 1));
           splatter.SetTile(2, 0, new Tile(18, 1));
           splatter.SetTile(3, 0, new Tile(19, 1));
           splatter.SetTile(4, 0, new Tile(20, 1));

           List<MapLayer> mapLayers = new List<MapLayer>();
           mapLayers.Add(layer);
           mapLayers.Add(splatter);

           map = new TileMap(tilesets, mapLayers);

           ContentManager Content = Game.Content;
           song = Content.Load<Song>("Music/LEVEL_1");
           MediaPlayer.Play(song);
            
        }
        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin
                (SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity
                );
            map.Draw(GameRef.SpriteBatch,player.Camera);
            base.Draw(gameTime);
            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
