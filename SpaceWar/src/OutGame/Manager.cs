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
    /// Control some fields that are applied in the game
    /// </summary>
    static class Manager
    {
        /// <summary>
        /// Checking collision
        /// </summary>
        /// <param name="s1_X"></param>       X poisition of s1 
        /// <param name="s1_Y"></param>       Y poisition of s1
        /// <param name="s1_Height"></param>  s1's Height
        /// <param name="s1_Width"></param>   s1's Width
        /// <param name="s2_X"></param>       X poisition of s2
        /// <param name="s2_Y"></param>       Y poisition of s2
        /// <param name="s2_Height"></param>  s2's Height
        /// <param name="s2_Width"></param>   s2's Width
        /// <returns></returns>
        public static bool IsCollision(float s1_X, float s1_Y, float s1_Height, float s1_Width,
                                       float s2_X, float s2_Y, float s2_Height, float s2_Width)
        {
            bool condition = false;
            if (s1_X + s1_Width >= s2_X && s1_X <= s2_X + s2_Width && s1_Y + s1_Height >= s2_Y && s1_Y <= s2_Y + s2_Height)
                condition = true;
            return condition;
        }

        /// <summary>
        /// Remove objects that are out of the screen
        /// </summary>
        /// <param name="gos"></param> list of game object
        public static void OffScreen(List<GameObject> gos)
        {
            List<GameObject> toRemove = new List<GameObject>();
            foreach (GameObject go in gos)
            {
                if (go.Position.Y < -10 || go.Position.Y > 590 || go.Position.X < -20 || go.Position.X > 820)
                    toRemove.Add(go);
            }

            foreach (GameObject go in toRemove)
            {
                SwinGame.FreeSprite(go.Sprite);
                gos.Remove(go);
            }
        }

        /// <summary>
        /// Remove and free Sprite
        /// </summary>
        /// <param name="toRemove"></param> Remove list
        /// <param name="objectList"></param> Object list
        public static void FreeAndRemoveSprite(List<GameObject> toRemove, List<GameObject> objectList)
        {
            foreach (GameObject go in toRemove)
            {
                SwinGame.FreeSprite(go.Sprite);
                objectList.Remove(go);
            }
        }

        /// <summary>
        /// Update and Draw Gameobjects in the list
        /// </summary>
        /// <param name="listofgo"></param> list of game object
        public static void UpdateAndDrawGameObjectInList(List<GameObject> listofgo)
        {
            foreach (GameObject go in listofgo)
            {
                go.Draw();
                go.Update();
            }
        }

        /// <summary>
        /// Check whether pt is inside rectangle
        /// </summary>
        /// <param name="pt"></param> Mouse position
        /// <param name="x"></param>  rectangle x position
        /// <param name="y"></param>  rectangle y position
        /// <param name="w"></param>  rectangle width
        /// <param name="h"></param>  rectangle height
        public static bool IsAtRectangle(Point2D pt, int x, int y, int w, int h)
        {
            return pt.X >= x && pt.X < x + w && pt.Y >= y && pt.Y < y + h;
        }

        /// <summary>
        /// Draw background for specific state
        /// </summary>
        public static void DrawBackground()
        {
            switch (GameController.CurrentState)
            {
                case GameState.GameMenu:
                case GameState.GameMenuPaused:
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("MenuBG"), 0, 0);
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("SpaceWar"), 150, 60);
                    break;
                case GameState.Tutorial:
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("TutorialBG"), 0, 0);
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("SpaceWar"), 150, 60);
                    break;
                case GameState.HighScore:
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("HighscoreBG"), 0, 0);
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("SpaceWar"), 150, 60);
                    break;
                case GameState.BattlePhrase:
                case GameState.Ending:
                    SwinGame.DrawBitmap(SwinGame.BitmapNamed("BattleBG"), 0, 0);
                    break;
            }
        }

        /// <summary>
        /// Back button !!!Havent Implement yet!!!
        /// </summary>
        public static void BackButton()
        {
            int xPosition = 100;
            int yPosition = 70;
            int buttonwidth = 50;
            int buttonheight = 50;
            if (IsAtRectangle(SwinGame.MousePosition(), xPosition, yPosition, buttonwidth, buttonheight))
            {
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("BackButton"), xPosition, yPosition);
                SwinGame.FillRectangle(Color.Red, xPosition, yPosition, buttonwidth, buttonheight);
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                    GameController.EndCurrentState();
            }
            else
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("BackButton"), xPosition, yPosition);
        }
    }
}
