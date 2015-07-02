namespace XRpgLibrary.TileEngine
{
    public class Tile
    {
        #region Constructor Region

        public Tile(int tileIndex, int tileset)
        {
            this.TileIndex = tileIndex;
            this.TileSet = tileset;
        }

        #endregion

        #region Property Region

        public int TileIndex { get; private set; }

        public int TileSet { get; private set; }

        #endregion
    }
}