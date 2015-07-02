namespace XRpgLibrary.Controls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Label : Control
    {
        #region Constructor Region

        public Label()
        {
            this.TabStop = false;
        }

        #endregion

        #region Abstract Methods

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.SpriteFont, this.Text, this.Position, this.Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
        }

        #endregion
    }
}