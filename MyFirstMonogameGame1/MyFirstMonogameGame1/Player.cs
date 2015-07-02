using System;
using Microsoft.Xna.Framework;
using  Microsoft.Xna.Framework.Graphics;



namespace MyFirstMonogameGame1
{
    class Player
    {
        private Texture2D playerTexture2D;

        private Vector2 positionVector2;

        public bool active;
        public int health;


        public int Width
        {
            get { return this.playerTexture2D.Width; }
        }

        public int Height
        {
            get { return this.playerTexture2D.Height; }
        }


        public void Initialize(Texture2D texture,Vector2 vector)
        {
            playerTexture2D = texture;
            positionVector2 = vector;
            active = true;
            health = 100;
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(playerTexture2D,positionVector2,null,Color.AntiqueWhite,0f,positionVector2,1f,
                SpriteEffects.None, 0f);
        }
    }
}
