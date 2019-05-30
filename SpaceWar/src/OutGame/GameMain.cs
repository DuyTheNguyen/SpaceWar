using System;
using SwinGameSDK;

namespace SpaceWar
{
    public class GameMain
    {
        public static void Main()
        {

            //Open the game window
            SwinGame.OpenGraphicsWindow("Space War", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            //Load Resources
            GameResources.LoadResources();

            //Run the game loop
            do
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                GameController.UserInput();
                GameController.Draw();
                SwinGame.DrawFramerate(615, 590);

                //Draw onto the screen
                SwinGame.RefreshScreen(60);
            } while (!(SwinGame.WindowCloseRequested() == true || GameController.CurrentState == GameState.Quiting)) ;

            SwinGame.StopMusic();

            //Free Resources and Close Audio, to end the program.
            GameResources.FreeResources();
        }
    }
}