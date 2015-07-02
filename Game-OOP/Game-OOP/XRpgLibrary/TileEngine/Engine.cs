namespace XRpgLibrary.TileEngine
{
    using Microsoft.Xna.Framework;

    public class Engine
    {
        #region Field Region

        #endregion

        #region Constructors

        public Engine(int tileWidth, int tileHeight)
        {
            Engine.TileWidth = tileWidth;
            Engine.TileHeight = tileHeight;
        }

        #endregion

        #region Property Region

        public static int TileWidth { get; private set; }

        public static int TileHeight { get; private set; }

        #endregion

        #region Methods

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / TileWidth, (int)position.Y / TileHeight);
        }

        #endregion
    }
}