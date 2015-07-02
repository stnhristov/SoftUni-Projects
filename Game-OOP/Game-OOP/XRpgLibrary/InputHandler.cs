namespace XRpgLibrary
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputHandler : GameComponent
    {
        #region Keyboard Field Region

        private static KeyboardState keyboardState;
        private static KeyboardState lastKeyboardState;

        #endregion

        #region Gamepad Field Region

        #endregion

        #region Constructor Region

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
            GamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                GamePadStates[(int)index] = GamePad.GetState(index);
            }
        }

        #endregion

        #region Keyboard Property Region

        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        #endregion

        #region GamePad Property Region

        public static GamePadState[] GamePadStates { get; private set; }

        public static GamePadState[] LastGamePadStates { get; private set; }

        #endregion

        #region GamePad Region

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonUp(button) && LastGamePadStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonDown(button) && LastGamePadStates[(int)index].IsButtonUp(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return GamePadStates[(int)index].IsButtonDown(button);
        }

        #endregion

        #region General Method Region

        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }

        #endregion

        #region Keyboard Region

        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) && lastKeyboardState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        #endregion

        #region XNA methods

        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            LastGamePadStates = (GamePadState[])GamePadStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                GamePadStates[(int)index] = GamePad.GetState(index);
            }

            base.Update(gameTime);
        }

        #endregion
    }
}