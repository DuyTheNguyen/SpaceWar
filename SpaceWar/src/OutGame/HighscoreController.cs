using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace SpaceWar
{
    /// <summary>
    /// Responsible for loading and saving scores and drawing scores to the screen
    /// </summary>
    static class HighscoreController
    {
        /// <summary>
        /// Struct score contain name and score
        /// </summary>
        private struct Score
        {
            public string Name;
            public int score;
        }

        private static List<Score> _listofScore = new List<Score>();
        /// <summary>
        /// maximum of name is 15
        /// </summary>
        private static int _nameLength = 15;
        /// <summary>
        /// Load score from flie
        /// </summary>
        private static void Load()
        {
            string filename = "";
            filename = SwinGame.PathToResource("highscore.txt");
            StreamReader reader = new StreamReader(filename);

            int fileLength = 0;

            //Read the total score (10)
            fileLength = Convert.ToInt32(reader.ReadLine());


            _listofScore.Clear();

            for (int i = 0; i < fileLength; i++)
            {
                Score s = new Score();
                string file = "Im handsome";
                //Read the whole line
                file = reader.ReadLine();

                //Substring
                //Read name from the beginning to the _nameLength (15))
                s.Name = file.Substring(0, _nameLength);

                //Continue reading char from index = 15 and convert to Integer
                s.score = Convert.ToInt32(file.Substring(_nameLength));
                _listofScore.Add(s);
            }
            reader.Close();
        }
        /// <summary>
        /// Save the score to the file
        /// </summary>
        public static void Save()
        {
            string filename = "";
            filename = SwinGame.PathToResource("highscore.txt");
            StreamWriter writer = new StreamWriter(filename);

            //Wirte the total score (10)
            writer.WriteLine(_listofScore.Count);
            //Write scores to file
            foreach (Score s in _listofScore)
                writer.WriteLine(s.Name + s.score);
            writer.Close();
        }

        /// <summary>
        /// Read score if it fulfil the requiremet (the new score  is higher than the smallest score in the list.) and sort score from the list
        /// </summary>
        /// <param name="Score"></param>
        public static void ManageScore(int Score)
        {
            GameController.AddState(GameState.HighScore);
            if (_listofScore.Count == 0)
                Load();

            // is the new score higher than the smallest score in the list.
            if (Score > _listofScore[_listofScore.Count - 1].score)//index starts from 0
            {
                Score s = new Score();
                s.score = Score;

                SwinGame.StartReadingText(Color.White, _nameLength, SwinGame.LoadFont("Arial", 20), 100, 500);

                while (SwinGame.ReadingText())
                {
                    //Fetch the next batch of UI interaction
                    SwinGame.ProcessEvents();
                    Manager.DrawBackground();
                    DrawHighscore();
                    //SwinGame.DrawRectangle(Color.White, 35, 495, 275, 30);
                    SwinGame.DrawText("Name: ", Color.White, SwinGame.LoadFont("Arial", 20), 40, 500);
                    SwinGame.DrawText("Score: ", Color.White, SwinGame.LoadFont("Arial", 20), 40, 525);
                    SwinGame.DrawText(Score.ToString(), Color.White, SwinGame.LoadFont("Arial", 20), 100, 525);
                    SwinGame.RefreshScreen();

                }
                s.Name = SwinGame.TextReadAsASCII();
                //Fill the name with space if its length is smaller than _nameLength
                if (s.Name.Length < _nameLength)
                {
                    s.Name = s.Name + new string(Convert.ToChar(" "), _nameLength - s.Name.Length);
                }
                //Remove the current smallest score
                _listofScore.RemoveAt(_listofScore.Count - 1);
                //Add new score to the list
                _listofScore.Add(s);


            }
            //using Linq to sort elements in _listofScore https://www.dotnetperls.com/sort-list
            var result = from element in _listofScore orderby element.score descending select element;
            _listofScore = result.ToList();
            Save();
            // End HighScore State and go back to Endding State
            GameController.EndCurrentState();
        }
        /// <summary>
        /// Draw list of highscore to the screen
        /// </summary>
        public static void DrawHighscore()
        {
            if (_listofScore.Count == 0)
                Load();
            SwinGame.DrawText("  HighScore  ", Color.NavajoWhite, SwinGame.LoadFont("Courb", 45), 220, 150);

            int j = 200;

            for (int i = 0; i < _listofScore.Count; i++)
            {
                Score s;
                s = _listofScore[i];
                SwinGame.DrawText((i + 1) + " : " + s.Name + s.score, Color.NavajoWhite, SwinGame.LoadFont("Courb", 30), 200, j);
                j += 40;
            }
        }
        /// <summary>
        /// Handle User Input when in HighScore state
        /// </summary>
        public static void UserInputHighscore()
        {
            if (SwinGame.KeyTyped(KeyCode.SpaceKey) || SwinGame.KeyTyped(KeyCode.EscapeKey) || SwinGame.MouseClicked(MouseButton.LeftButton))
                GameController.EndCurrentState();
        }
    }
}




