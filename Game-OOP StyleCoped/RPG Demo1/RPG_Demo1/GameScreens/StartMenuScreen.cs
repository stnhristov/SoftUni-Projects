namespace RPG_Demo1.GameScreens
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;

    using RPG_Demo1.MusicManager;

    using XRpgLibrary;
    using XRpgLibrary.Controls;

    public class StartMenuScreen : BaseGameState
    {
        #region Field Region

        private PictureBox backgroundImage;
        private PictureBox arrowImage;
        private LinkLabel startGame;
        private LinkLabel loadGame;
        private LinkLabel exitGame;
        private Song song;
        private float maxItemWidth = 0f;

        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region Property Region
        #endregion

        #region XNA Method Region

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, this.PlayerIndexInControl);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            ContentManager content = Game.Content;
            Music menu = new Music("Music/MENU", this.song);

            this.backgroundImage = new PictureBox(
                content.Load<Texture2D>("Backgrounds/menubackground"),
                GameRef.ScreenRectangle);

            ControlManager.Add(this.backgroundImage);

            Texture2D arrowTexture = content.Load<Texture2D>("GUI/LeftArrowUp");

            this.arrowImage = new PictureBox(
                arrowTexture,
                new Rectangle(0, 0, arrowTexture.Width, arrowTexture.Height));

            ControlManager.Add(this.arrowImage);

            this.startGame = new LinkLabel();
            this.startGame.Text = "START GAME";
            this.startGame.Size = this.startGame.SpriteFont.MeasureString(this.startGame.Text);
            this.startGame.Selected += new EventHandler(this.MenuItem_Selected);

            ControlManager.Add(this.startGame);

            this.loadGame = new LinkLabel();
            this.loadGame.Text = "LOAD GAME";
            this.loadGame.Size = this.loadGame.SpriteFont.MeasureString(this.loadGame.Text);
            this.loadGame.Selected += this.MenuItem_Selected;

            ControlManager.Add(this.loadGame);

            this.exitGame = new LinkLabel();
            this.exitGame.Text = "EXIT GAME";
            this.exitGame.Size = this.exitGame.SpriteFont.MeasureString(this.exitGame.Text);
            this.exitGame.Selected += this.MenuItem_Selected;

            ControlManager.Add(this.exitGame);

            ControlManager.NextControl();

            this.ControlManager.FocusChanged += new EventHandler(this.ControlManager_FocusChanged);
            Vector2 position = new Vector2(350, 350);

            foreach (Control c in this.ControlManager)
            {
                if (!(c is LinkLabel))
                {
                    continue;
                }

                if (c.Size.X > this.maxItemWidth)
                {
                    this.maxItemWidth = c.Size.X;
                }

                c.Position = position;
                position.Y += c.Size.Y + 5f;
            }

            this.ControlManager_FocusChanged(this.startGame, null);
        }

        private void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + this.maxItemWidth + 10f, control.Position.Y);
            this.arrowImage.SetPosition(position);
        }

        private void MenuItem_Selected(object sender, EventArgs e)
        {
            if (sender == this.startGame)
            {
                StateManager.PushState(GameRef.CharacterGenerationScreen);
            }

            if (sender == this.loadGame)
            {
                StateManager.PushState(GameRef.GamePlayScreen);
            }

            if (sender == this.exitGame)
            {
                GameRef.Exit();
            }
        }
        #endregion

        #region Game State Method Region
        #endregion
    }
}