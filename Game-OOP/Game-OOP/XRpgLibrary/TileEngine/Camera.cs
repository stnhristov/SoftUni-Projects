namespace XRpgLibrary.TileEngine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using SpriteClasses;

    public class Camera
    {
        #region Field Region

        private Vector2 position;
        private float speed;
        private float zoom;
        private Rectangle viewportRectangle;

        #endregion

        #region Constructor Region

        public Camera(Rectangle viewportRect)
        {
            this.Speed = this.speed;
            this.Zoom = this.zoom;
            this.viewportRectangle = viewportRect;
            CameraMode = CameraMode.Follow;
        }

        public Camera(Rectangle viewportRectangle, Vector2 position)
        {
            this.Speed = this.speed;
            this.Zoom = this.zoom;
            this.ViewportRectangle = viewportRectangle;
            this.Position = position;
            CameraMode = CameraMode.Follow;
        }

        #endregion

        #region Property Region

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            private set
            {
                this.position = value;
            }
        }

        public float Speed
        {
            get
            {
                return this.speed;
            }

            set
            {
                this.speed = (float)MathHelper.Clamp(this.speed, 1f, 16f);
            }
        }

        public float Zoom
        {
            get
            {
                return this.zoom;
            }

            set
            {
                this.zoom = 1f;
            }
        }

        public CameraMode CameraMode { get; private set; }

        public Rectangle ViewportRectangle { get; set; }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            if (CameraMode == CameraMode.Follow)
            {
                return;
            }

            Vector2 motion = Vector2.Zero;

            if (InputHandler.KeyDown(Keys.Left))
            {
                motion.X = -this.speed;
            }
            else if (InputHandler.KeyDown(Keys.Right))
            {
                motion.X = this.speed;
            }

            if (InputHandler.KeyDown(Keys.Up))
            {
                motion.Y = -this.speed;
            }
            else if (InputHandler.KeyDown(Keys.Down))
            {
                motion.Y = this.speed;
            }

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
                this.position += motion * this.speed;
                this.LockCamera();
            }
        }

        public void LockToSprite(AnimatedSprite sprite)
        {
            this.position.X = sprite.Position.X + (sprite.Width / 2) - (this.viewportRectangle.Width / 2);
            this.position.Y = sprite.Position.Y + (sprite.Height / 2) - (this.viewportRectangle.Height / 2);

            this.LockCamera();
        }

        public void ToggleCameraMode()
        {
            if (CameraMode == CameraMode.Follow)
            {
                CameraMode = CameraMode.Free;
            }
            else if (CameraMode == CameraMode.Free)
            {
                CameraMode = CameraMode.Follow;
            }
        }

        private void LockCamera()
        {
            this.position.X = MathHelper.Clamp(this.position.X, 0, TileMap.WidthInPixels - this.viewportRectangle.Width);
            this.position.Y = MathHelper.Clamp(this.position.Y, 0, TileMap.HeightInPixels - this.viewportRectangle.Height);
        }
        #endregion
    }
}