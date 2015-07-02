namespace XRpgLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public abstract partial class GameState : DrawableGameComponent
    {
        #region Fields

        private readonly List<GameComponent> childComponents;
        private readonly GameState tag;

        #endregion

        #region Constructor Region

        protected GameState(Game game, GameStateManager manager)
            : base(game)
        {
            this.StateManager = manager;
            this.childComponents = new List<GameComponent>();
            this.tag = this;
        }

        #endregion

        #region Properties

        public GameStateManager StateManager { get; set; }

        public List<GameComponent> Components
        {
            get { return this.childComponents; }
        }

        public GameState Tag
        {
            get { return this.tag; }
        }

        #endregion

        #region XNA Drawable Game Component Methods

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent component in this.childComponents.Where(component => component.Enabled))
            {
                component.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (DrawableGameComponent drawComponent in this.childComponents.OfType<DrawableGameComponent>().Where(drawComponent => drawComponent.Visible))
            {
                drawComponent.Draw(gameTime);
            }

            base.Draw(gameTime);
        }

        #endregion

        #region GameState Method Region

        protected internal virtual void StateChange(object sender, EventArgs e)
        {
            if (this.StateManager.CurrentState == this.Tag)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }

        protected virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;

            foreach (GameComponent component in this.childComponents)
            {
                component.Enabled = true;

                var gameComponent = component as DrawableGameComponent;

                if (gameComponent != null)
                {
                    gameComponent.Visible = true;
                }
            }
        }

        protected virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;

            foreach (GameComponent component in this.childComponents)
            {
                component.Enabled = false;

                var gameComponent = component as DrawableGameComponent;

                if (gameComponent != null)
                {
                    gameComponent.Visible = false;
                }
            }
        }
        #endregion
    }
}