using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// Show instruction for players.
    /// </summary>
    static class TutorialController
    {
        private static readonly string[] _content = new string[]
        {
            "Press between <1> and <7> for ",
            "swapping gun",
            "Press <W> <A> <S> <D> to move",
            "Press L to shoot"
        };

        private const int _xPosition = 150;

        private static int[] _yPosition = { 220, 280, 340, 400 };

        /// <summary>
        /// Draw tutorial
        /// </summary>
        public static void DrawTutorial()
        {
            for (int i = 0; i < _content.Length; i++)
                SwinGame.DrawText(_content[i], Color.Black, SwinGame.LoadFont("Galaxy", 35), _xPosition, _yPosition[i]);
        }

        /// <summary>
        /// Handle user input in tutorial state
        /// </summary>
        public static void UserInputTutorial()
        {
            if (SwinGame.KeyTyped(KeyCode.SpaceKey) || SwinGame.KeyTyped(KeyCode.EscapeKey) || SwinGame.MouseClicked(MouseButton.LeftButton))
                GameController.EndCurrentState();
        }
    }
}
