namespace RPG_Demo1.GameScreens
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using XRpgLibrary;
    using XRpgLibrary.Controls;

    public abstract class BaseGameState : GameState
    {
        #region Fields Region

        #endregion

        #region Constructor Region

        protected BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            this.GameRef = (Game1)game;
            this.PlayerIndexInControl = PlayerIndex.One;
        }

        #endregion

        #region Properties Region

        public Game1 GameRef { get; protected set; }

        public ControlManager ControlManager { get; protected set; }

        public PlayerIndex PlayerIndexInControl { get; protected set; }

        #endregion

        #region XNA Method Region

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;
            SpriteFont menuFont = content.Load<SpriteFont>("Fonts/ControlFont");
            ControlManager = new ControlManager(menuFont);
            base.LoadContent();
        }

        #endregion
    }
}