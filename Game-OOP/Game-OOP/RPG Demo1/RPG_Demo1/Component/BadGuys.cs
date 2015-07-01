using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RPG_Demo1.GameScreens;
using XRpgLibrary;
using XRpgLibrary.SpriteClasses;

namespace RPG_Demo1.Component
{
    public abstract class BadGuys:Animation
    {
        private List<SpriteBatch> badList;

        public BadGuys(int frameCount, int frameWidth, int frameHeight, int xOffset, int yOffset) : base(frameCount, frameWidth, frameHeight, xOffset, yOffset)
        {
            SpriteBatches = new List<SpriteBatch>();
        }

        public List<SpriteBatch> SpriteBatches { get;private set; }
    }
}

