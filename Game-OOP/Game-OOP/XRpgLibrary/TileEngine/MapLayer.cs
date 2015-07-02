namespace XRpgLibrary.TileEngine
{
    public class MapLayer
    {
        #region Field Region

        private readonly Tile[,] map;

        #endregion

        #region Constructor Region

        public MapLayer(Tile[,] map)
        {
            this.map = (Tile[,])map.Clone();
        }

        public MapLayer(int width, int height)
        {
            this.map = new Tile[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    this.map[y, x] = new Tile(0, 0);
                }
            }
        }

        #endregion

        #region Property Region

        public int Width
        {
            get { return this.map.GetLength(1); }
        }

        public int Height
        {
            get { return this.map.GetLength(0); }
        }

        #endregion

        #region Method Region

        public Tile GetTile(int x, int y)
        {
            return this.map[y, x];
        }

        public void SetTile(int x, int y, Tile tile)
        {
            this.map[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            this.map[y, x] = new Tile(tileIndex, tileset);
        }

        #endregion
    }
}