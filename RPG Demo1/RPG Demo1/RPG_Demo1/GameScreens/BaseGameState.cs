using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary;
using XRpgLibrary.Controls;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG_Demo1.GameScreens
{
    public abstract partial class BaseGameState:GameState
    {
        #region Fields Region

        protected Game1 GameRef;
        protected ControlManager ControlManager;
        protected PlayerIndex PlayerIndexInControl;

        #endregion

        #region Properties Region
        #endregion
        #region Constructor Region
        public BaseGameState(Game game, GameStateManager manager) : base(game, manager) 
        {
            GameRef = (Game1)game;
            PlayerIndexInControl = PlayerIndex.One;
        }
        #endregion

        #region XNA Method Region

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;
            SpriteFont menuFont = Content.Load<SpriteFont>("Fonts/ControlFont");
            ControlManager = new ControlManager(menuFont);
            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
        #endregion
    }
}
