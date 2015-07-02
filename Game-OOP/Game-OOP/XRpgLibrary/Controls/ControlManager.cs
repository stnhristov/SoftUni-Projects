namespace XRpgLibrary.Controls
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class ControlManager : List<Control>
    {
        #region Fields

        private static SpriteFont spriteFont;

        private int selectedControl = 0;

        #endregion

        #region Constructors

        public ControlManager(SpriteFont spriteFont)
            : base()
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity)
            : base(capacity)
        {
            ControlManager.spriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection)
            : base(collection)
        {
            ControlManager.spriteFont = spriteFont;
        }

        #endregion

        #region Event Region
        public event EventHandler FocusChanged;
        #endregion

        #region Properies
        public static SpriteFont SpriteFont
        {
            get { return spriteFont; }
        }
        #endregion

        #region Methods

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (this.Count == 0)
            {
                return;
            }

            foreach (Control c in this)
            {
                if (c.Enabled)
                {
                    c.Update(gameTime);
                }

                if (c.HasFocus)
                {
                    c.HandleInput(playerIndex);
                }
            }

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) ||
                InputHandler.KeyPressed(Keys.Up))
            {
                this.PreviousControl();
            }

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
                InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) ||
                InputHandler.KeyPressed(Keys.Down))
            {
                this.NextControl();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Control c in this)
            {
                if (c.Visible)
                {
                    c.Draw(spriteBatch);
                }
            }
        }

        public void NextControl()
        {
            if (this.Count == 0)
            {
                return;
            }

            int currentControl = this.selectedControl;

            this[this.selectedControl].HasFocus = false;

            do
            {
                this.selectedControl++;
                if (this.selectedControl == this.Count)
                {
                    this.selectedControl = 0;
                }

                if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                {
                    if (this.FocusChanged != null)
                    {
                        this.FocusChanged(this[this.selectedControl], null);
                    }

                    break;
                }
            }
            while (currentControl != this.selectedControl);

            this[this.selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (this.Count == 0)
            {
                return;
            }

            int currentControl = this.selectedControl;

            this[this.selectedControl].HasFocus = false;

            do
            {
                this.selectedControl--;

                if (this.selectedControl < 0)
                {
                    this.selectedControl = this.Count - 1;
                }

                if (this[this.selectedControl].TabStop && this[this.selectedControl].Enabled)
                {
                    if (this.FocusChanged != null)
                    {
                        this.FocusChanged(this[this.selectedControl], null);
                    }

                    break;
                }
            }
            while (currentControl != this.selectedControl);

            this[this.selectedControl].HasFocus = true;
        }

        #endregion
    }
}