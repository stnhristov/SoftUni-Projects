namespace XRpgLibrary.TileEngine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Tileset
    {
        #region Fields

        private readonly Rectangle[] sourceRectangles;

        #endregion

        #region Constructor Region

        public Tileset(Texture2D image, int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
        {
            this.Texture = image;
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
            this.TilesWide = tilesWide;
            this.TilesHigh = tilesHigh;

            int tiles = tilesWide * tilesHigh;

            this.sourceRectangles = new Rectangle[tiles];

            int tile = 0;

            for (int y = 0; y < tilesHigh; y++)
            {
                for (int x = 0; x < tilesWide; x++)
                {
                    this.sourceRectangles[tile] = new Rectangle(
                        x * tileWidth,
                        y * tileHeight,
                        tileWidth,
                        tileHeight);

                    tile++;
                }
            }
        }

        #endregion

        #region Property Region

        public Texture2D Texture { get; private set; }

        public int TileWidth { get; private set; }

        public int TileHeight { get; private set; }

        public int TilesWide { get; private set; }

        public int TilesHigh { get; private set; }

        public Rectangle[] SourceRectangles
        {
            get { return (Rectangle[])this.sourceRectangles.Clone(); }
        }

        #endregion
    }
}