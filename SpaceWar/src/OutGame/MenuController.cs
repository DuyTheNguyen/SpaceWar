using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// Controler the menu of the game
    /// </summary>
    static class MenuController
    {
        private static readonly string[][] _menu2DArray =
        {
            new string[]
            {
                "Play",
                "Help",
                "Score",
                "Quit"
            },
            new string[]
            {
                "Back",
                "Help",
                "Menu",
                "Quit"
            }
        };

        //Button properties
        private const int _xPosition = 325;
        private static int[] _yPosition = { 220, 280, 340, 400 };
        private const int _buttonWidth = 150;
        private const int _buttonHeight = 30;

        //for switch
        private const int _gameMenu = 0;

        private const int _gameMenu_Play = 0;
        private const int _gameMenu_Help = 1;
        private const int _gameMenu_Score = 2;
        private const int _gameMenu_Quit = 3;

        //for switch
        private const int _gameMenuPause = 1;

        private const int _gameMenuPause_Back = 0;
        private const int _gameMenuPause_Help = 1;
        private const int _gameMenuPause_MainMenu = 2;
        private const int _gameMenuPause_Quit = 3;


        /// <summary>
        /// For user handle input
        /// </summary>
        private static void UserInput(int menu)
        {
            if (GameController.CurrentState == GameState.GameMenuPaused)
                SwinGame.ResumeMusic();
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
                GameController.EndCurrentState();
            if (SwinGame.KeyTyped(KeyCode.SKey))
                GameController.AddState(GameState.BattlePhrase);
            if (SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                for (int i = 0; i < _menu2DArray[menu].Length; i++)
                {
                    if (Manager.IsAtRectangle(SwinGame.MousePosition(), _xPosition, _yPosition[i], _buttonWidth, _buttonHeight))
                        ImplementMenuAction(menu, i);
                }
            }
        }

        /// <summary>
        /// User can play, view highscore and quit in this state
        /// </summary>
        public static void UserInputGameMenu()
        {
            UserInput(_gameMenu);
        }

        /// <summary>
        /// User can return, return to main menu or quit
        /// </summary>
        public static void UserInputGameMenuPause()
        {
            UserInput(_gameMenuPause);
        }




        /// <summary>
        /// Handle button
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="button"></param>
        private static void ImplementMenuAction(int menu, int button)
        {
            switch (menu)
            {
                case _gameMenu:
                    ImplementGameMenuAction(button);
                    break;
                case _gameMenuPause:
                    ImplementGameMenuPauseAction(button);
                    break;
            }
        }

        /// <summary>
        /// Handle button in game menu
        /// </summary>
        /// <param name="button"></param>
        private static void ImplementGameMenuAction(int button)
        {
            switch (button)
            {
                case _gameMenu_Play:
                    {
                        SwinGame.PlayMusic("BattleMusic");
                        GameController.AddState(GameState.BattlePhrase);
                        BattleController.TimeCreated = DateTime.Now;
                        break;
                    }
                case _gameMenu_Help:
                    GameController.AddState(GameState.Tutorial);
                    break;
                case _gameMenu_Score:
                    GameController.AddState(GameState.HighScore);
                    break;
                case _gameMenu_Quit:
                    GameController.EndCurrentState();
                    break;
            }
        }

        /// <summary>
        /// Handle button in game menu pause
        /// </summary>
        /// <param name="button"></param>
        private static void ImplementGameMenuPauseAction(int button)
        {
            switch (button)
            {
                case _gameMenuPause_Back:
                    SwinGame.ResumeMusic();
                    GameController.EndCurrentState();
                    break;
                case _gameMenuPause_Help:
                    //only Pause music when in pause menu
                    SwinGame.PauseMusic();
                    GameController.AddState(GameState.Tutorial);
                    break;
                case _gameMenuPause_MainMenu:
                    {
                        SwinGame.PlayMusic("BackgroundMusic");
                        ///End pause Menu
                        GameController.EndCurrentState();
                        //End game
                        GameController.EndCurrentState();
                        //Reset game for starting a new game
                        BattleController.ResetGame();
                        break;
                    }
                case _gameMenuPause_Quit:
                    GameController.AddState(GameState.Quiting);
                    break;
            }
        }




        /// <summary>
        /// Draw Game Menu to the screen
        /// </summary>
        public static void DrawGameMenu()
        {
            DrawButton(_gameMenu);
        }

        /// <summary>
        /// Draw Game Menu Pause to the screen
        /// </summary>
        public static void DrawGameMenuPause()
        {
            DrawButton(_gameMenuPause);
        }

        /// <summary>
        /// Draw button
        /// </summary>
        /// <param name="menu"></param>
        private static void DrawButton(int menu)
        {

            for (int i = 0; i < _menu2DArray[menu].Length; i++)
            {
                //SwinGame.DrawRectangle(Color.White, _xPosition, _yPosition[i], _buttonWidth, _buttonHeight);
                if (Manager.IsAtRectangle(SwinGame.MousePosition(), _xPosition, _yPosition[i], _buttonWidth, _buttonHeight))
                    SwinGame.DrawText(_menu2DArray[menu][i], Color.DarkRed, SwinGame.LoadFont("Galaxy", 40), _xPosition, _yPosition[i]);
                else
                    SwinGame.DrawText(_menu2DArray[menu][i], Color.DimGray, SwinGame.LoadFont("Galaxy", 40), _xPosition, _yPosition[i]);
            }
        }
    }
}
