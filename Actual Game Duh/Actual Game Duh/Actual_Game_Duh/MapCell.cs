using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actual_Game_Duh
{
    class MapCell
    {
        #region Properties
        public int TileID
        {
            get;
            set;
        }
        public int CollisionID
        {
            get;
            set;
        }
        #endregion
        public MapCell(int tileID, int collisionID) 
        {
            TileID = tileID;
            CollisionID = collisionID;
        }
    }
}
