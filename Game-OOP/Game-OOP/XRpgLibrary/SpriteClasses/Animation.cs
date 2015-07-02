namespace XRpgLibrary.SpriteClasses
{
    using System;
    using Microsoft.Xna.Framework;

    public class Animation : ICloneable
    {
        #region Field Region

        private readonly Rectangle[] frames;
        private int framesPerSecond;
        private TimeSpan frameLength;
        private TimeSpan frameTimer;
        private int currentFrame;
        private int frameWidth;
        private int frameHeight;

        #endregion

        #region Constructor Region

        public Animation(int frameCount, int frameWidth, int frameHeight, int offsetX, int offsetY)
        {
            this.frames = new Rectangle[frameCount];
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;

            for (int i = 0; i < frameCount; i++)
            {
                this.frames[i] = new Rectangle(
                    offsetX + (frameWidth * i),
                    offsetY,
                    frameWidth,
                    frameHeight);
            }

            this.FramesPerSecond = 5;
            this.Reset();
        }

        private Animation(Animation animation)
        {
            this.frames = animation.frames;
            this.FramesPerSecond = 5;
        }

        #endregion

        #region Property Region

        public int FramesPerSecond
        {
            get
            {
                return this.framesPerSecond;
            }

            set
            {
                if (value < 1)
                {
                    this.framesPerSecond = 1;
                }
                else if (value > 60)
                {
                    this.framesPerSecond = 60;
                }
                else
                {
                    this.framesPerSecond = value;
                }

                this.frameLength = TimeSpan.FromSeconds(1 / (double)this.framesPerSecond);
            }
        }

        public Rectangle CurrentFrameRect
        {
            get { return this.frames[this.currentFrame]; }
        }

        public int CurrentFrame
        {
            get
            {
                return this.currentFrame;
            }

            set
            {
                this.currentFrame = (int)MathHelper.Clamp(value, 0, this.frames.Length - 1);
            }
        }

        public int FrameWidth
        {
            get { return this.frameWidth; }
        }

        public int FrameHeight
        {
            get { return this.frameHeight; }
        }

        #endregion

        #region Method region

        public void Update(GameTime gameTime)
        {
            this.frameTimer += gameTime.ElapsedGameTime;

            if (this.frameTimer >= this.frameLength)
            {
                this.frameTimer = TimeSpan.Zero;
                this.currentFrame = (this.currentFrame + 1) % this.frames.Length;
            }
        }

        public void Reset()
        {
            this.currentFrame = 0;
            this.frameTimer = TimeSpan.Zero;
        }

        #endregion

        #region Interface Method Region

        public object Clone()
        {
            Animation animationClone = new Animation(this);

            animationClone.frameWidth = this.frameWidth;
            animationClone.frameHeight = this.frameHeight;
            animationClone.Reset();

            return animationClone;
        }

        #endregion
    }
}