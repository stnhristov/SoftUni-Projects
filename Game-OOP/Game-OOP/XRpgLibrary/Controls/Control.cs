namespace XRpgLibrary.Controls
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class Control
    {
        #region Field Region

        private Vector2 position;

        #endregion

        #region Constructor Region
        protected Control()
        {
            Color = Color.White;
            this.Enabled = true;
            this.Visible = true;
            SpriteFont = ControlManager.SpriteFont;
        }
        #endregion

        #region Event Region

        public event EventHandler Selected;

        #endregion

        #region Property Region

        public string Name { get; set; }

        public string Text { get; set; }

        public Vector2 Size { get; set; }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.position = value;
                this.position.Y = (int)this.position.Y;
            }
        }

        public object Value { get; set; }

        public bool HasFocus { get; set; }

        public bool Enabled { get; set; }

        public bool Visible { get; set; }

        public bool TabStop { get; set; }

        public SpriteFont SpriteFont { get; set; }

        public Color Color { get; set; }

        public string Type { get; set; }

        #endregion

        #region Abstract Methods

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void HandleInput(PlayerIndex playerIndex);

        #endregion

        #region Virtual Methods

        protected virtual void OnSelected(EventArgs e)
        {
            if (this.Selected != null)
            {
                this.Selected(this, e);
            }
        }

        #endregion
    }
}