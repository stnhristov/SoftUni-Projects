using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XRpgLibrary;
using RPG_Demo1.GameScreens;

using RPG_Demo1.MusicManager;

namespace RPG_Demo1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region XNA Field Region

        GraphicsDeviceManager graphics;
        public SpriteBatch SpriteBatch;

        #endregion

        #region Game State Region

        GameStateManager stateManager;

        public TitleScreen TitleScreen;
        public StartMenuScreen StartMenuScreen;
        public GamePlayScreen GamePlayScreen;
        public CharacterGenerationScreen CharacterGenerationScreen;

        #endregion

        #region Screen Field Region

        const int screenWidth = 1024;
        const int screenHeight = 768;
        public readonly Rectangle ScreenRectangle;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.IsFullScreen = true;
            ScreenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            Content.RootDirectory = "Content";
            Components.Add(new InputHandler(this));

            stateManager = new GameStateManager(this);
            Components.Add(stateManager);

            TitleScreen = new TitleScreen(this, stateManager);
            StartMenuScreen = new GameScreens.StartMenuScreen(this, stateManager);
            GamePlayScreen = new GamePlayScreen(this, stateManager);
            CharacterGenerationScreen = new CharacterGenerationScreen(this, stateManager);

            stateManager.ChangeState(TitleScreen);
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {
            
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
