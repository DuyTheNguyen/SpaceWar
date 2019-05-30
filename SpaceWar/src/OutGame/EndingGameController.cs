using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// Control the ending state when player dies
    /// </summary>
    static class EndingGameController
    {
        /// <summary>
        /// Handle user input
        /// </summary>
        public static void UserInputEnding()
        {
            if (SwinGame.KeyTyped(KeyCode.SpaceKey) || SwinGame.KeyTyped(KeyCode.EscapeKey) || SwinGame.MouseClicked(MouseButton.LeftButton))
            {
                //Go to manage score in HighController class
                HighscoreController.ManageScore(BattleController.Score);
                //Reset the game for preparing the new game
                BattleController.ResetGame();
                //End this state
                GameController.EndCurrentState();
                //Go back to background music
                SwinGame.PlayMusic("BackgroundMusic");
            }
        }
        /// <summary>
        /// Draw the current state
        /// </summary>
        public static void DrawEnding()
        {
            SwinGame.DrawBitmap(SwinGame.BitmapNamed("GameOver"), 100, 250);
        }
    }
}
