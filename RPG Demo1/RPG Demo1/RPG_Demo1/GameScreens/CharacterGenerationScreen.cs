using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;
using XRpgLibrary.Controls;

namespace RPG_Demo1.GameScreens
{
    public class CharacterGenerationScreen:BaseGameState
    {
        #region Field Region

        LeftRightSelector genderSelector;
        LeftRightSelector raceSelector;
        PictureBox backgroundImage;

        string[] genderItems = {"Male","Female"};
        string[] raceItems = {"Nordic","Caucasian","Dwarf","Elf"};

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public CharacterGenerationScreen(Game game, GameStateManager stateManager) : base(game, stateManager) 
        {
        }

        #endregion

        #region XNA methods region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            CreateControls();
        }

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

        private void CreateControls() 
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>("GUI/RightArrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>("GUI/LeftArrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>("GUI/StopBar");

            backgroundImage = new PictureBox(Game.Content.Load<Texture2D>("Backgrounds/menubackground"), GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Label label1 = new Label();

            label1.Text = "Choose one handsome race\n for your adventure!!!";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X) / 2, 250);

            ControlManager.Add(label1);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 350);

            ControlManager.Add(genderSelector);

            raceSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            raceSelector.SetItems(raceItems, 125);
            raceSelector.Position = new Vector2(label1.Position.X, 400);

            ControlManager.Add(raceSelector);

            LinkLabel linkLabel1 = new LinkLabel();
            linkLabel1.Text = "Accept Character";
            linkLabel1.Position = new Vector2(label1.Position.X, 450);
            linkLabel1.Selected += new EventHandler(linkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            ControlManager.NextControl();
        }

        void linkLabel1_Selected(object sender, EventArgs e) 
        {
            InputHandler.Flush();

            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }

        #endregion
    }
}
