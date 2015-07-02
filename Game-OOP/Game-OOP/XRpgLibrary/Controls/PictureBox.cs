namespace XRpgLibrary.Controls
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class PictureBox : Control
    {
        #region Constructors

        public PictureBox(Texture2D image, Rectangle destination)
        {
            this.Image = image;
            this.DestinationRectangle = destination;
            this.SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            this.Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            this.Image = image;
            this.DestinationRectangle = destination;
            this.SourceRectangle = source;
            this.Color = Color.White;
        }

        #endregion

        #region Property Region

        public Texture2D Image { get; protected set; }

        public Rectangle SourceRectangle { get; protected set; }

        public Rectangle DestinationRectangle { get; protected set; }

        #endregion

        #region Abstract Method Region

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.DestinationRectangle, this.SourceRectangle, this.Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
        }

        #endregion

        #region Picture Box Methods

        public void SetPosition(Vector2 newPosition)
        {
            this.DestinationRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, this.SourceRectangle.Width, this.SourceRectangle.Height);
        }

        #endregion
    }
}