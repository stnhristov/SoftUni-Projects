namespace XRpgLibrary.Controls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class LinkLabel : Control
    {
        #region Fields

        private Color selectedColor = Color.Black;

        #endregion

        #region Constructor Region

        public LinkLabel()
        {
            this.TabStop = true;
            this.HasFocus = false;
            this.Position = Vector2.Zero;
        }
        #endregion

        #region Properties

        public Color SelectedColor
        {
            get { return this.selectedColor; }
            set { this.selectedColor = value; }
        }

        #endregion

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.HasFocus)
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.selectedColor);
            }
            else
            {
                spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!this.HasFocus)
            {
                return;
            }

            if (InputHandler.KeyReleased(Keys.Enter) ||
                InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                this.OnSelected(null);
            }
        }

        #endregion
    }
}