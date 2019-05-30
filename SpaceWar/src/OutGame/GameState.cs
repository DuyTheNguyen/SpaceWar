using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceWar
{
    /// <summary>
    /// The state of the game
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// Viewing GameMenu
        /// </summary>
        GameMenu,
        /// <summary>
        /// View GameMenu while in game
        /// </summary>
        GameMenuPaused,
        /// <summary>
        /// View Tutorial
        /// </summary>
        Tutorial,
        /// <summary>
        /// Battle phrase
        /// </summary>
        BattlePhrase,
        /// <summary>
        /// Viewing Score
        /// </summary>
        HighScore,
        /// <summary>
        /// Ending phrase
        /// </summary>
        Ending,
        /// <summary>
        /// Quit the game
        /// </summary>
        Quiting
    }
}
