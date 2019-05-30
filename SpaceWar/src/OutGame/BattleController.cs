using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.Diagnostics;

namespace SpaceWar
{
    /// <summary>
    /// This class controls the battle phrase
    /// </summary>
    static class BattleController
    {

        private static int _score;
        //Use for highscore
        public static int Score { get => _score; set => _score = value; }

        private static int _standardScore;
        private static int _difficulty;

        private const int _amountOfEnemy = 15;

        public static List<GameObject> Barriers = new List<GameObject>();
        public static List<GameObject> ItemList = new List<GameObject>();
        public static List<GameObject> EnemyGuns = new List<GameObject>();
        public static List<GameObject> PlayerBullets = new List<GameObject>();
        public static List<GameObject> EnemyBullets = new List<GameObject>();

        private static Player _newplayer = new Player("Ship", new Point2D() { X = 350, Y = 500 }, 8);
        internal static Player NewPlayer { get => _newplayer; set => _newplayer = value; }

        public static DateTime TimeCreated;
        private const float _delaytime = 3;

        /// <summary>
        /// Check whether it is ready
        /// </summary>
        /// <returns></returns>
        private static bool IsReady()
        {
            return DateTime.Now > TimeCreated.AddSeconds(_delaytime);
        }

        /// <summary>
        /// Countdown before playing game
        /// </summary>
        private static void ImplementReady()
        {
            DateTime onesec = TimeCreated.AddSeconds(1);
            DateTime twosec = TimeCreated.AddSeconds(2);
            DateTime threesec = TimeCreated.AddSeconds(3);

            if (DateTime.Now <= threesec && DateTime.Now > twosec)
            {
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("Numeral1"), 375, 250);
            }
            else if (DateTime.Now <= twosec && DateTime.Now > onesec)
            {
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("Numeral2"), 375, 250);
            }
            else if (DateTime.Now <= onesec)
            {
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("Numeral3"), 375, 250);
            }
        }


        /// <summary>
        /// Launching Battle
        /// </summary>
        public static void LaunchBattle()
        {
            //_timecreated = DateTime.Now;
            SwinGame.DrawText("Score: " + Score, Color.GreenYellow, 5, 5);
            SwinGame.DrawText("Difficulty: " + _difficulty, Color.GreenYellow, 5, 15);
            SwinGame.DrawText("Life: " + NewPlayer.Lives, Color.GreenYellow, 5, 25);
            SwinGame.DrawText("Weapon: " + NewPlayer.CurrentGun.Name, Color.GreenYellow, 5, 35);
            SwinGame.DrawText("Cooldown: " + NewPlayer.CurrentGun.CoolDown + "s", Color.GreenYellow, 5, 45);


            //Delay Time
            if (IsReady())
            {
                //Hide Player if Player died
                if (NewPlayer.IsVisible)
                {
                    NewPlayer.Draw();
                    NewPlayer.Update();
                }
                else
                {
                    NewPlayer.Position.Y = -100;
                }
                Update();
            }
            else
                ImplementReady();
        }

        /// <summary>
        /// Update every frame
        /// </summary>
        private static void Update()
        {
            //Check difficulty
            IncreaseDifficulty();
            //Create Enemies(strong barrieres) and Barriers
            if (Barriers.Count <= _difficulty)
            {
                for (int i = 0; i < SwinGame.Rnd() * _amountOfEnemy; i++)
                {
                    GameObject ba = null;
                    //Generate enemies (strong Barriers) and barriers randomly
                    BarriersKind bk = (BarriersKind)SwinGame.Rnd(11);
                    if (bk == BarriersKind.SmallMeteor1 || bk == BarriersKind.SmallMeteor2 ||
                        bk == BarriersKind.SmallMeteor3 || bk == BarriersKind.SmallMeteor4 || bk == BarriersKind.SmallMeteor5)
                    {
                        ba = new Barriers(bk.ToString(), new Point2D() { X = SwinGame.Rnd() * 600, Y = 0 }, 3 + SwinGame.Rnd() * 2);
                    }
                    else if (bk == BarriersKind.EnemyBlack)
                    {
                        ba = new HealthyBarrier(bk.ToString(), new Point2D() { X = SwinGame.Rnd() * 600, Y = 0 }, SwinGame.Rnd() * 3, ItemList);
                    }
                    else if (bk == BarriersKind.EnemyRed)
                    {
                        ba = new RichBarrier(bk.ToString(), new Point2D() { X = SwinGame.Rnd() * 600, Y = 0 }, SwinGame.Rnd() * 3, ItemList);
                    }
                    else
                    {
                        ba = new StrongBarriers(bk.ToString(), new Point2D() { X = SwinGame.Rnd() * 600, Y = 0 }, SwinGame.Rnd() * 3);
                    }
                    //Add to barries list
                    Barriers.Add(ba);
                }
            }
            //Create and Update Game Objects
            if (ItemList != null)
                Manager.UpdateAndDrawGameObjectInList(ItemList);
            Manager.UpdateAndDrawGameObjectInList(Barriers);
            Manager.UpdateAndDrawGameObjectInList(PlayerBullets);
            Manager.UpdateAndDrawGameObjectInList(EnemyBullets);

            OffScreen();

            CheckColiision();


        }

        /// <summary>
        /// Remove objects that go off the screen
        /// </summary>
        private static void OffScreen()
        {
            Manager.OffScreen(PlayerBullets);
            Manager.OffScreen(Barriers);
            Manager.OffScreen(EnemyBullets);
            Manager.OffScreen(EnemyGuns);
            Manager.OffScreen(ItemList);
        }

        /// <summary>
        /// Check Collsion
        /// </summary>
        private static void CheckColiision()
        {
            List<GameObject> BarriersToRemove = new List<GameObject>();
            List<GameObject> PlayerBulletsToRemove = new List<GameObject>();
            List<GameObject> EnemyBulletsToRemove = new List<GameObject>();
            List<GameObject> ItemListToRemove = new List<GameObject>();
            int scoreDiff = 1;
            //Barriers vs Player
            foreach (GameObject go in Barriers)
            {
                if (Manager.IsCollision(NewPlayer.Position.X, NewPlayer.Position.Y, NewPlayer.Sprite.Height, NewPlayer.Sprite.Width,
                                                   go.Position.X, go.Position.Y, go.Sprite.Height, go.Sprite.Width))
                {
                    BarriersToRemove.Add(go);
                    NewPlayer.IsExplosion();
                }
            }
            //Item vs Player
            foreach (GameObject go in ItemList)
            {
                if (Manager.IsCollision(NewPlayer.Position.X, NewPlayer.Position.Y, NewPlayer.Sprite.Height, NewPlayer.Sprite.Width,
                                                   go.Position.X, go.Position.Y, go.Sprite.Height, go.Sprite.Width))
                {
                    //Hit effect
                    go.IsExplosion();
                    ItemListToRemove.Add(go);
                }
            }

            //Enemy Bullets vs Player
            foreach (GameObject go in EnemyBullets)
            {
                if (Manager.IsCollision(NewPlayer.Position.X, NewPlayer.Position.Y, NewPlayer.Sprite.Height, NewPlayer.Sprite.Width,
                                                   go.Position.X, go.Position.Y, go.Sprite.Height, go.Sprite.Width))
                {
                    //Hit effect
                    go.IsExplosion();
                    EnemyBulletsToRemove.Add(go);
                    NewPlayer.IsExplosion();
                }
            }

            //Enemy Bullets vs Player Bullets
            foreach (GameObject go1 in PlayerBullets)
            {
                foreach (GameObject go2 in EnemyBullets)
                    if (Manager.IsCollision(go1.Position.X, go1.Position.Y, go1.Sprite.Height, go1.Sprite.Width,
                                                        go2.Position.X, go2.Position.Y, go2.Sprite.Height, go2.Sprite.Width))
                    {
                        //Hit effect
                        go1.IsExplosion();
                        //hit sound effect
                        SwinGame.PlaySoundEffect("HitBullet");
                        PlayerBulletsToRemove.Add(go1);
                        EnemyBulletsToRemove.Add(go2);
                    }
            }

            //Barriers vs Player Bullets
            foreach (GameObject go1 in PlayerBullets)
            {
                foreach (GameObject go2 in Barriers)
                    if (Manager.IsCollision(go1.Position.X, go1.Position.Y, go1.Sprite.Height, go1.Sprite.Width,
                                                        go2.Position.X, go2.Position.Y, go2.Sprite.Height, go2.Sprite.Width))
                    {
                        //Hit effect
                        go1.IsExplosion();
                        PlayerBulletsToRemove.Add(go1);
                        if (go2.IsExplosion())
                        {
                            BarriersToRemove.Add(go2);
                        }
                    }
            }
            scoreDiff *= BarriersToRemove.Count;
            Manager.FreeAndRemoveSprite(PlayerBulletsToRemove, PlayerBullets);
            Manager.FreeAndRemoveSprite(BarriersToRemove, Barriers);
            Manager.FreeAndRemoveSprite(EnemyBulletsToRemove, EnemyBullets);
            Manager.FreeAndRemoveSprite(ItemListToRemove, ItemList);
            Score += scoreDiff;
        }


        /// <summary> 
        /// Control the difficulty
        /// </summary>
        public static void IncreaseDifficulty()
        {
            //Increase Diff from every standardScore
            if (Score > _standardScore)
            {
                _difficulty++;
                _standardScore += 50;
            }
            //Max of diff is 7
            if (_difficulty >= 7)
                _difficulty = 7;
        }

        /// <summary>
        /// Reset the game 
        /// </summary>
        public static void ResetGame()
        {
            Score = 0;
            _standardScore = 50;
            _difficulty = 0;

            NewPlayer.IsVisible = true;
            NewPlayer.Lives = 3;
            NewPlayer.Position.X = 350;
            NewPlayer.Position.Y = 500;
            NewPlayer.CurrentGun.Position.Y = NewPlayer.Position.Y;
            NewPlayer.CurrentGun.Position.X = NewPlayer.Position.X + 47;

            Barriers.Clear();
            EnemyGuns.Clear();
            PlayerBullets.Clear();
            EnemyBullets.Clear();
            ItemList.Clear();
        }

        /// <summary>
        /// Handling user input
        /// </summary>
        public static void UserInput()
        {
            if (SwinGame.KeyTyped(KeyCode.EscapeKey))
            {
                GameController.AddState(GameState.GameMenuPaused);
                SwinGame.PlaySoundEffect("Pause");
            }
            if (NewPlayer.Lives <= 0)
                GameController.SwitchState(GameState.Ending);
        }
    }
}
