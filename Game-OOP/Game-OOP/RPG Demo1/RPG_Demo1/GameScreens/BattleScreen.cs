namespace RPG_Demo1.GameScreens
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Media;

    using RPG_Demo1.MusicManager;

    using XRpgLibrary;
    using XRpgLibrary.Controls;

    public class BattleScreen : BaseGameState
    {
        #region Field Region

        private PictureBox backgroundImage;
        private PictureBox arrowImage;
        private LinkLabel tackleHit;
        private LinkLabel legsMagicHit;
        private LinkLabel fleeHit;
        private Song song;
        private float maxItemWidth = 0f;
        private int heroHealth =15;
        private int villainHealth = 10;
        private List<PictureBox> healthBars;

        #endregion

        #region Constructor Region

        public BattleScreen(Game game, GameStateManager manager)
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
            //Music menu = new Music("Music/Boss_Fight", this.song);

            this.backgroundImage = new PictureBox(
                content.Load<Texture2D>("Backgrounds/battlescreen_layout"),
                GameRef.ScreenRectangle);

            ControlManager.Add(this.backgroundImage);

            Texture2D arrowTexture = content.Load<Texture2D>("GUI/LeftArrowUp");

            this.arrowImage = new PictureBox(
                arrowTexture,
                new Rectangle(0, 0, arrowTexture.Width, arrowTexture.Height));

            ControlManager.Add(this.arrowImage);

            this.tackleHit = new LinkLabel();
            this.tackleHit.Text = "Tackle";
            this.tackleHit.Size = this.tackleHit.SpriteFont.MeasureString(this.tackleHit.Text);
            this.tackleHit.Selected += new EventHandler(this.MenuItem_Selected);

            ControlManager.Add(this.tackleHit);

            this.legsMagicHit = new LinkLabel();
            this.legsMagicHit.Text = "Leg Magic";
            this.legsMagicHit.Size = this.legsMagicHit.SpriteFont.MeasureString(this.legsMagicHit.Text);
            this.legsMagicHit.Selected += this.MenuItem_Selected;

            ControlManager.Add(this.legsMagicHit);

            this.fleeHit = new LinkLabel();
            this.fleeHit.Text = "Flee";
            this.fleeHit.Size = this.fleeHit.SpriteFont.MeasureString(this.fleeHit.Text);
            this.fleeHit.Selected += this.MenuItem_Selected;

            ControlManager.Add(this.fleeHit);

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

            this.ControlManager_FocusChanged(this.tackleHit, null);
        }

        private void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + this.maxItemWidth + 10f, control.Position.Y);
            this.arrowImage.SetPosition(position);
        }

        private void MenuItem_Selected(object sender, EventArgs e)
        {
            if (sender == this.tackleHit)
            {
                if (villainHealth != 0)
                {
                    villainHealth -= 2;
                }
                else if (heroHealth <= 0) 
                {
                    GameRef.Exit();
                }
                else
                {
                    StateManager.PopState();
                    Music menu = new Music("Music/MENU", this.song);
                    villainHealth = 10;
                    heroHealth = 15;
                }
                
            }

            if (sender == this.legsMagicHit)
            {
                if (villainHealth != 0)
                {
                    villainHealth -= 3;
                }
                else if (heroHealth <= 0)
                {
                    GameRef.Exit();
                }
                else
                {
                    StateManager.PopState();
                    Music menu = new Music("Music/MENU", this.song);
                    villainHealth = 10;
                    heroHealth = 15;
                }
            }

            if (sender == this.fleeHit)
            {
                Random rand = new Random();
                int randd = rand.Next(1, 100);
                if (randd <= 50)
                {
                    heroHealth -= 2;
                    if (heroHealth <= 0) { GameRef.Exit(); }
                }
                else StateManager.PopState();
                Music menu = new Music("Music/MENU", this.song);
                heroHealth = 15;
            }
        }
        #endregion

        #region Game State Method Region
        #endregion
    }
}