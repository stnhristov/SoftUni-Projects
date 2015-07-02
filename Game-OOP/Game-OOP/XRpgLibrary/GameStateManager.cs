namespace XRpgLibrary
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    public class GameStateManager : GameComponent
    {
        #region Fields Region

        private const int StartDrawOrder = 5000;
        private const int DrawOrderInc = 100;
        private readonly Stack<GameState> gameStates = new Stack<GameState>();
        private int drawOrder;

        #endregion

        #region Constructor Region

        public GameStateManager(Game game)
            : base(game)
        {
            this.drawOrder = StartDrawOrder;
        }

        #endregion

        #region Event Region

        public event EventHandler OnStateChange;

        #endregion

        public GameState CurrentState
        {
            get { return this.gameStates.Peek(); }
        }

        #region Properties

        #endregion

        #region Methods Region

        public void PopState()
        {
            if (this.gameStates.Count > 0)
            {
                this.RemoveState();
                this.drawOrder -= DrawOrderInc;
                if (this.OnStateChange != null)
                {
                    this.OnStateChange(this, null);
                }
            }
        }

        public void PushState(GameState newState)
        {
            this.drawOrder += DrawOrderInc;
            newState.DrawOrder = this.drawOrder;
            this.AddState(newState);

            if (this.OnStateChange != null)
            {
                this.OnStateChange(this, null);
            }
        }

        public void ChangeState(GameState newState)
        {
            while (this.gameStates.Count > 0)
            {
                this.RemoveState();
            }

            newState.DrawOrder = StartDrawOrder;
            this.AddState(newState);
            if (this.OnStateChange != null)
            {
                this.OnStateChange(this, null);
            }
        }

        private void AddState(GameState newState)
        {
            this.gameStates.Push(newState);
            Game.Components.Add(newState);
            this.OnStateChange += newState.StateChange;
        }

        private void RemoveState()
        {
            GameState state = this.gameStates.Peek();
            this.OnStateChange -= state.StateChange;
            Game.Components.Remove(state);
            this.gameStates.Pop();
        }

        #endregion
    }
}