﻿namespace RPG_Demo1.GameScreens
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using XRpgLibrary;
    using XRpgLibrary.Controls;

    public class CharacterGenerationScreen : BaseGameState
    {
        #region Field Region

        private readonly string[] genderItems = { "Male", "Female" };
        private readonly string[] raceItems = { "Nordic", "Caucasian", "Dwarf", "Elf" };

        private LeftRightSelector genderSelector;
        private LeftRightSelector raceSelector;
        private PictureBox backgroundImage;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public CharacterGenerationScreen(Game game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }

        #endregion

        #region XNA methods region

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Methods Region

        protected override void LoadContent()
        {
            base.LoadContent();

            this.CreateControls();
        }

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>("GUI/RightArrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>("GUI/LeftArrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>("GUI/StopBar");

            this.backgroundImage = new PictureBox(Game.Content.Load<Texture2D>("Backgrounds/menubackground"), GameRef.ScreenRectangle);
            ControlManager.Add(this.backgroundImage);

            Label label1 = new Label();

            label1.Text = "Choose one handsome race\n for your adventure!!!";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X) / 2, 250);

            ControlManager.Add(label1);

            this.genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            this.genderSelector.SetItems(this.genderItems, 125);
            this.genderSelector.Position = new Vector2(label1.Position.X, 350);

            ControlManager.Add(this.genderSelector);

            this.raceSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            this.raceSelector.SetItems(this.raceItems, 125);
            this.raceSelector.Position = new Vector2(label1.Position.X, 400);

            ControlManager.Add(this.raceSelector);

            LinkLabel linkLabel1 = new LinkLabel();
            linkLabel1.Text = "Accept Character";
            linkLabel1.Position = new Vector2(label1.Position.X, 450);
            linkLabel1.Selected += new EventHandler(this.LinkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            ControlManager.NextControl();
        }

        private void LinkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }

        #endregion
    }
}