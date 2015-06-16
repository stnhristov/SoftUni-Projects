using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;
<<<<<<< HEAD
using XRpgLibrary.TileEngine;
=======
>>>>>>> c351f761c38918c84819703b6401f7dd7bbc0bc0

namespace RPG_Demo1.GameScreens
{
    public class GamePlayScreen:BaseGameState
    {
        #region Field Region
<<<<<<< HEAD

        Engine engine = new Engine(32, 32);
        Tileset tileset;
        TileMap map;
=======
>>>>>>> c351f761c38918c84819703b6401f7dd7bbc0bc0
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager) 
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
<<<<<<< HEAD
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/starterTileSet1");
            tileset = new Tileset(tilesetTexture, 8, 8, 32, 32);

            MapLayer layer = new MapLayer(40, 40);
            for (int y = 0; y < layer.Height; y++) 
            {
                for (int x = 0; x < layer.Width; x++) 
                {
                    Tile tile = new Tile(3, 0);
                    layer.SetTile(x, y, tile);
                }
            }
            map = new TileMap(tileset, layer);
=======
>>>>>>> c351f761c38918c84819703b6401f7dd7bbc0bc0
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
<<<<<<< HEAD
            GameRef.SpriteBatch.Begin
                (SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity
                );
            map.Draw(GameRef.SpriteBatch);
            base.Draw(gameTime);
            GameRef.SpriteBatch.End();
=======
            base.Draw(gameTime);
>>>>>>> c351f761c38918c84819703b6401f7dd7bbc0bc0
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
