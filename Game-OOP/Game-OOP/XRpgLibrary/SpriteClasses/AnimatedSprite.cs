namespace XRpgLibrary.SpriteClasses
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using TileEngine;

    public class AnimatedSprite
    {
        #region Field Region

        private Dictionary<AnimationKey, Animation> animations;

        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float speed = 2.0f;

        #endregion

        #region Constructor Region

        public AnimatedSprite(Texture2D sprite, Dictionary<AnimationKey, Animation> animation)
        {
            this.texture = sprite;
            this.animations = new Dictionary<AnimationKey, Animation>();

            foreach (AnimationKey key in animation.Keys)
            {
                this.animations.Add(key, (Animation)animation[key].Clone());
            }
        }

        #endregion
        #region Property Region

        public AnimationKey CurrentAnimation { get; set; }

        public bool IsAnimating { get; set; }

        public int Width
        {
            get { return this.animations[this.CurrentAnimation].FrameWidth; }
        }

        public int Height
        {
            get { return this.animations[this.CurrentAnimation].FrameHeight; }
        }

        public float Speed
        {
            get { return this.speed; }

            set { this.speed = MathHelper.Clamp(this.speed, 1.0f, 16.0f); }
        }

        public Vector2 Position
        {
            get { return this.position; }

            set { this.position = value; }
        }

        public Vector2 Velocity
        {
            get
            {
                return this.velocity;
            }

            set
            {
                this.velocity = value;

                if (this.velocity != Vector2.Zero)
                {
                    this.velocity.Normalize();
                }
            }
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            if (this.IsAnimating)
            {
                this.animations[this.CurrentAnimation].Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(
                this.texture,
                this.position - camera.Position,
                this.animations[this.CurrentAnimation].CurrentFrameRect,
                Color.White);
        }

        public void LockToMap()
        {
            this.position.X = MathHelper.Clamp(this.position.X, 0, TileMap.WidthInPixels - this.Width);
            this.position.Y = MathHelper.Clamp(this.position.Y, 0, TileMap.HeightInPixels - this.Height);
        }

        #endregion
    }
}