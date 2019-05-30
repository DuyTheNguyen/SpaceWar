using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// Control the state of the game
    /// </summary>
    public static class GameController
    {
        /// <summary>
        /// Store the states of the game, FIFO
        /// </summary>
        private static Stack<GameState> _state = new Stack<GameState>();

        /// <summary>
        /// Get the current state which is in the top of the stack
        /// </summary>
        public static GameState CurrentState
        {
            get { return _state.Peek(); }
        }

        /// <summary>
        /// add the state to the top of the stack
        /// </summary>
        /// <param name="state"></param>
        public static void AddState(GameState state)
        {
            _state.Push(state);
        }

        /// <summary>
        /// Remove the top state of the stack
        /// </summary>
        public static void EndCurrentState()
        {
            _state.Pop();
        }

        /// <summary>
        /// End current state and add new state
        /// </summary>
        /// <param name="state"></param>
        public static void SwitchState(GameState state)
        {
            EndCurrentState();
            AddState(state);
        }

        static GameController()
        {
            //Play Background Music
            SwinGame.PlayMusic("BackgroundMusic");
            //Quitting state at the bottom of the stack
            _state.Push(GameState.Quiting);
            //Allow player to see the menu
            _state.Push(GameState.GameMenu);
        }

        /// <summary>
        /// Handle user input. The way that user can go to each state
        /// </summary>
        public static void UserInput()
        {
            switch (CurrentState)
            {
                case GameState.GameMenu:
                    MenuController.UserInputGameMenu();
                    break;
                case GameState.BattlePhrase:
                    BattleController.UserInput();
                    break;
                case GameState.Tutorial:
                    TutorialController.UserInputTutorial();
                    break;
                case GameState.GameMenuPaused:
                    MenuController.UserInputGameMenuPause();
                    break;
                case GameState.HighScore:
                    HighscoreController.UserInputHighscore();
                    break;
                case GameState.Ending:
                    EndingGameController.UserInputEnding();
                    break;
            }
        }

        /// <summary>
        /// Draw the current state to the screen
        /// </summary>
        public static void Draw()
        {
            //Draw background for each state
            Manager.DrawBackground();
            switch (CurrentState)
            {
                case GameState.GameMenu:
                    MenuController.DrawGameMenu();
                    break;
                case GameState.BattlePhrase:
                    BattleController.LaunchBattle();
                    break;
                case GameState.Tutorial:
                    TutorialController.DrawTutorial();
                    break;
                case GameState.GameMenuPaused:
                    //Stop the music
                    SwinGame.PauseMusic();
                    MenuController.DrawGameMenuPause();
                    break;
                case GameState.HighScore:
                    HighscoreController.DrawHighscore();
                    break;
                case GameState.Ending:
                    EndingGameController.DrawEnding();
                    break;
            }
        }
    }
}
