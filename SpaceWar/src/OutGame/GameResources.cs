using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// Store all the resoureces of the game
    /// </summary>
    static class GameResources
    {
        /// <summary>
        /// Load resources
        /// </summary>
        public static void LoadResources()
        {
            LoadImage();

            LoadMusic();

            LoadAudio();

            LoadFonts();
       
        }

        


        ///Images
        private static void LoadImage()
        {
            SwinGame.LoadBitmapNamed("Menu", "moon.jpg");

            SwinGame.LoadBitmapNamed("MenuBG", "home1.jpg");
            SwinGame.LoadBitmapNamed("HighscoreBG", "home2.jpg");
            SwinGame.LoadBitmapNamed("BattleBG", "home3.jpg");
            SwinGame.LoadBitmapNamed("TutorialBG", "home4.jpg");
            SwinGame.LoadBitmapNamed("BackButton", "backbutton.png");




            SwinGame.LoadBitmapNamed("SpaceWar", "textHome.png");
            SwinGame.LoadBitmapNamed("GameOver", "gameover.png");

            SwinGame.LoadBitmapNamed("Ship", "red-ship.png");
            SwinGame.LoadBitmapNamed("LaserRed", "laserRed.png");
            SwinGame.LoadBitmapNamed("LaserGreen", "laserGreen.png");
            SwinGame.LoadBitmapNamed("LaserRedShot", "laserRedShot.png");
            SwinGame.LoadBitmapNamed("LaserGreenShot", "laserGreenShot.png");
            SwinGame.LoadBitmapNamed("LaserRedShot1", "laserRed08.png");
            SwinGame.LoadBitmapNamed("PlayerLife", "life.png");
            SwinGame.LoadBitmapNamed("PlayerDamaged", "playerDamaged.png");
            SwinGame.LoadBitmapNamed("Shield", "shield3.png");
            SwinGame.LoadBitmapNamed("EnemyShield1", "enemyshield1.png");
            SwinGame.LoadBitmapNamed("EnemyShield2", "enemyshield2.png");

            SwinGame.LoadBitmapNamed("EnemyShip", "enemyShip.png");

            SwinGame.LoadBitmapNamed("BigMeteor", "meteorBig.png");
            SwinGame.LoadBitmapNamed("SmallMeteor1", "meteorSmall.png");
            SwinGame.LoadBitmapNamed("SmallMeteor2", "meteorBrown_med1.png");
            SwinGame.LoadBitmapNamed("SmallMeteor3", "meteorBrown_med3.png");
            SwinGame.LoadBitmapNamed("SmallMeteor4", "meteorBrown_small1.png");
            SwinGame.LoadBitmapNamed("SmallMeteor5", "meteorBrown_small2.png");

            SwinGame.LoadBitmapNamed("UFOBlue", "ufoBlue.png");
            SwinGame.LoadBitmapNamed("UFOGreen", "ufoGreen.png");
            SwinGame.LoadBitmapNamed("UFORed", "ufoRed.png");
            SwinGame.LoadBitmapNamed("UFOYellow", "ufoYellow.png");
            SwinGame.LoadBitmapNamed("EnemyBlack", "enemyBlack4.png");
            SwinGame.LoadBitmapNamed("EnemyRed", "enemyRed1.png");

            SwinGame.LoadBitmapNamed("LiveUpImg", "powerup1.png");
            SwinGame.LoadBitmapNamed("MoneyImg", "powerup2.png");

            SwinGame.LoadBitmapNamed("Numeral1", "numeral1.png");
            SwinGame.LoadBitmapNamed("Numeral2", "numeral2.png");
            SwinGame.LoadBitmapNamed("Numeral3", "numeral3.png");
        }

        ///Load Music
        private static void LoadMusic()
        {
            ///Audio and Music
            SwinGame.LoadMusicNamed("BackgroundMusic", "StarWars.wav");
            SwinGame.LoadMusicNamed("BattleMusic", "battlemusic.wav");
        }

        ///Load audio
        private static void LoadAudio()
        {
          
            SwinGame.LoadSoundEffectNamed("GameOver", "gameover.wav");
            SwinGame.LoadSoundEffectNamed("ExplosionPlayer", "explosion_player.wav");
            SwinGame.LoadSoundEffectNamed("ExplosionOther", "explosion_asteroid.wav");
            SwinGame.LoadSoundEffectNamed("ExplosionEnemy", "explosion_enemy.wav");
            SwinGame.LoadSoundEffectNamed("PlayerWeapon", "weapon_player.wav");
            SwinGame.LoadSoundEffectNamed("PlayerDie", "PlayerDie.wav");
            SwinGame.LoadSoundEffectNamed("EnemyWeapon", "weapon_enemy.wav");
            SwinGame.LoadSoundEffectNamed("Hit", "hit.wav");
            SwinGame.LoadSoundEffectNamed("HitPlayer", "hitPlayer.wav");
            SwinGame.LoadSoundEffectNamed("HitBullet", "bullet_hit.wav");
            SwinGame.LoadSoundEffectNamed("ShieldDown", "shieldDown.wav");
            SwinGame.LoadSoundEffectNamed("SwapGun", "swapgun.wav");
            SwinGame.LoadSoundEffectNamed("Pause", "pause.wav");
            SwinGame.LoadSoundEffectNamed("LiveUpSnd", "liveup.wav");
            SwinGame.LoadSoundEffectNamed("LiveUpAppears", "powerupappears.wav");
            SwinGame.LoadSoundEffectNamed("MoneySnd", "coin.wav");

            SwinGame.LoadSoundEffectNamed("Beep", "beep.wav");
            SwinGame.LoadSoundEffectNamed("FinalBeep", "finalbeep.wav");
        }

        /// <summary>
        /// Font
        /// </summary>
        private static void LoadFonts()
        {
            ///Font
            SwinGame.LoadFontNamed("Arial", "arial.ttf", 20);
            SwinGame.LoadFontNamed("Cour", "cour.ttf", 15);
            SwinGame.LoadFontNamed("Courb", "courb.ttf", 15);
            SwinGame.LoadFontNamed("Maven", "maven_pro_regular.ttf", 15);
            SwinGame.LoadFontNamed("Cramps", "cramps.ttf", 15);
            SwinGame.LoadFontNamed("Spacedock", "spacedockstencil.ttf", 15);
            SwinGame.LoadFontNamed("DeathStar", "deathstar.otf", 15);
            SwinGame.LoadFontNamed("Galaxy", "galaxy.ttf", 15);
            SwinGame.LoadFontNamed("StarJedi", "starjedi.ttf", 15);
        }

        /// <summary>
        /// Free Images
        /// </summary>
        private static void FreeImages()
        {
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("Menu"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("MenuBG"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("HighscoreBG"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("BattleBG"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("TutorialBG"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("BackButton"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("SpaceWar"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("GameOver"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("Ship"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("LaserRed"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("LaserGreen"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("LaserRedShot"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("LaserGreenShot"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("LaserRedShot1"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("PlayerLife"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("PlayerDamaged"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("Shield"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("EnemyShield1"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("EnemyShield2"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("EnemyShip"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("BigMeteor"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("SmallMeteor1"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("SmallMeteor2"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("SmallMeteor3"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("SmallMeteor4"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("SmallMeteor5"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("UFOBlue"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("UFOGreen"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("UFORed"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("UFOYellow"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("EnemyBlack"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("EnemyRed"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("LiveUpImg"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("MoneyImg"));

            SwinGame.FreeBitmap(SwinGame.BitmapNamed("Numeral1"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("Numeral2"));
            SwinGame.FreeBitmap(SwinGame.BitmapNamed("Numeral3"));

        }
        /// <summary>
        /// Free music
        /// </summary>
        private static void FreeMusic()
        {
            SwinGame.FreeMusic(SwinGame.LoadMusic("BackgroundMusic"));
            SwinGame.FreeMusic(SwinGame.LoadMusic("BattleMusic"));
        }

       /// <summary>
       /// Free audios 
       /// </summary>
       private static void FreeAudio()
       {
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("GameOver"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("ExplosionPlayer"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("ExplosionOther"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("ExplosionEnemy"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("PlayerWeapon"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("PlayerDie"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("EnemyWeapon"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("Hit"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("HitPlayer"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("HitBullet"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("ShieldDown"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("SwapGun"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("Pause"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("LiveUpSnd"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("LiveUpAppears"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("MoneySnd"));

            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("Beep"));
            SwinGame.FreeSoundEffect(SwinGame.LoadSoundEffect("FinalBeep"));
        }

        /// <summary>
        /// Free fonts
        /// </summary>
        private static void FreeFonts()
        {
            SwinGame.FreeFont(SwinGame.LoadFont("Arial",20));
            SwinGame.FreeFont(SwinGame.LoadFont("Cour", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("Courb", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("Maven", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("Cramps", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("Spacedock", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("DeathStar", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("Galaxy", 15));
            SwinGame.FreeFont(SwinGame.LoadFont("StarJedi", 15));
        }



        public static void FreeResources()
        {
            FreeImages();
            FreeMusic();
            //FreeAudio();
            FreeFonts();
            SwinGame.ProcessEvents();
        }

    }
}
