namespace RPG_Demo1.Component
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using XRpgLibrary.TileEngine;

    public class Player
    {
        #region Field Region

        private Camera camera;
        private Game1 gameRef;

        #endregion

        #region Constructor Region

        public Player(Game game)
        {
            this.gameRef = (Game1)game;
            this.camera = new Camera(this.gameRef.ScreenRectangle);
        }

        #endregion

        #region Property Region

        public Camera Camera
        {
            get { return this.camera; }
            set { this.camera = value; }
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            this.camera.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        #endregion
    }
}