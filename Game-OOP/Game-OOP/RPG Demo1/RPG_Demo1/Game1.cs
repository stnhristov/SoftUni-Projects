namespace RPG_Demo1
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using RPG_Demo1.GameScreens;

    using XRpgLibrary;

    public class Game1 : Game
    {
        #region Screen Field Region

        public readonly Rectangle ScreenRectangle;
        private const int ScreenWidth = 1024;
        private const int ScreenHeight = 768;

        #endregion

        #region XNA Field Region

        private GraphicsDeviceManager graphics;

        #endregion

        #region Game State Region

        private GameStateManager stateManager;

        #endregion

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);

            this.graphics.PreferredBackBufferWidth = ScreenWidth;
            this.graphics.PreferredBackBufferHeight = ScreenHeight;

            this.graphics.IsFullScreen = true;
            this.ScreenRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);

            Content.RootDirectory = "Content";
            Components.Add(new InputHandler(this));

            this.stateManager = new GameStateManager(this);
            Components.Add(this.stateManager);

            TitleScreen = new TitleScreen(this, this.stateManager);
            StartMenuScreen = new GameScreens.StartMenuScreen(this, this.stateManager);
            GamePlayScreen = new GamePlayScreen(this, this.stateManager);
            CharacterGenerationScreen = new CharacterGenerationScreen(this, this.stateManager);
            BattleScreen = new BattleScreen(this, this.stateManager);

            this.stateManager.ChangeState(TitleScreen);
        }

        #region Properties

        public SpriteBatch SpriteBatch { get; protected set; }

        public TitleScreen TitleScreen { get; protected set; }

        public StartMenuScreen StartMenuScreen { get; protected set; }

        public GamePlayScreen GamePlayScreen { get; protected set; }

        public CharacterGenerationScreen CharacterGenerationScreen { get; protected set; }

        public BattleScreen BattleScreen { get; protected set; }

        #endregion

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
            {
                this.Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}