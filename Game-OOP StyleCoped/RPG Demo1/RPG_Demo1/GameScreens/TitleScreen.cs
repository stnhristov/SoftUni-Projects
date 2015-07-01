namespace RPG_Demo1.GameScreens
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using XRpgLibrary;
    using XRpgLibrary.Controls;

    public class TitleScreen : BaseGameState
    {
        #region Field Region

        private Texture2D backgroundImage;
        private LinkLabel startLabel;

        #endregion

        #region Constructor Region

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager) 
        {
        }

        #endregion

        #region XNA Method Region

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(this.backgroundImage, GameRef.ScreenRectangle, Color.White);
            ControlManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            ContentManager content = GameRef.Content;

            this.backgroundImage = content.Load<Texture2D>("Backgrounds/menubackground");

            base.LoadContent();

            this.startLabel = new LinkLabel();
            this.startLabel.Position = new Vector2(360, 420);
            this.startLabel.Text = @"Press ""Enter""";
            this.startLabel.Color = Color.White;
            this.startLabel.TabStop = true;
            this.startLabel.HasFocus = true;
            this.startLabel.Selected += new EventHandler(this.StartLabel_Selected);

            ControlManager.Add(this.startLabel);
        }

        #endregion

        #region Title Screen Methods

        private void StartLabel_Selected(object sender, EventArgs e) 
        {
            StateManager.PushState(GameRef.StartMenuScreen);
        }

        #endregion
    }
}
