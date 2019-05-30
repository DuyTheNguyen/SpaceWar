using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class is responsible for controlling the player
    /// </summary>
    class Player : MoveableObject
    {
        private float _gunPosX;

        private Gun _currentgun;
        //To store player Gun
        private List<Gun> _listofGuns = new List<Gun>();

        private bool _isvisible;
        public bool IsVisible
        {
            get { return _isvisible; }
            set { _isvisible = value; }
        }

        public Gun CurrentGun { get => _currentgun; set => _currentgun = value; }

        /// <summary>
        /// Constructor of player
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public Player(string sprite, Point2D position, float speed) : base(sprite, position, speed)
        {
            _isvisible = true;
            _gunPosX = 47;
            Lives = 3;
            this.Equip(new LazerGun("Lazer Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

            this.Equip(new ShortGun("Short Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

            this.Equip(new DoubleLaserGun("Double Laser Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

            this.Equip(new _360DegreeGun("360 Degree Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

            this.Equip(new CatastrophicGun("Catastrophic Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

            this.Equip(new XGun("X Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

            this.Equip(new SineGun("Sine Gun", "", new Point2D() { X = this.Position.X + 47, Y = this.Position.Y }, "PlayerWeapon", "LaserRed", BattleController.PlayerBullets));

        }


        public override void Move()
        {

            if (SwinGame.KeyDown(KeyCode.WKey))
                CurrentGun.Position.Y = Position.Y -= Speed;
            if (SwinGame.KeyDown(KeyCode.SKey))
                CurrentGun.Position.Y = Position.Y += Speed;
            if (SwinGame.KeyDown(KeyCode.AKey))
            {
                CurrentGun.Position.X = Position.X -= Speed;
                CurrentGun.Position.X += _gunPosX;
            }
            if (SwinGame.KeyDown(KeyCode.DKey))
            {
                CurrentGun.Position.X = Position.X += Speed;
                CurrentGun.Position.X += _gunPosX;
            }
            if (SwinGame.KeyDown(KeyCode.LKey))
                CurrentGun.Shoot();

            if (SwinGame.KeyTyped(KeyCode.Num1Key))
                ImplementGun(_listofGuns[0]);

            if (SwinGame.KeyTyped(KeyCode.Num2Key))
                ImplementGun(_listofGuns[1]);

            if (SwinGame.KeyTyped(KeyCode.Num3Key))
                ImplementGun(_listofGuns[2]);

            if (SwinGame.KeyTyped(KeyCode.Num4Key))
                ImplementGun(_listofGuns[3]);

            if (SwinGame.KeyTyped(KeyCode.Num5Key))
                ImplementGun(_listofGuns[4]);

            if (SwinGame.KeyTyped(KeyCode.Num6Key))
                ImplementGun(_listofGuns[5]);

            if (SwinGame.KeyTyped(KeyCode.Num7Key))
                ImplementGun(_listofGuns[6]);


        }

        public override void Update()
        {
            Move();
            ControlPlayer();
        }

        public override void Draw()
        {
            switch (Lives)
            {

                case 2:
                    {
                        //this.Sprite = SwinGame.CreateSprite(SwinGame.BitmapNamed("Ship"));
                        this.Sprite = SwinGame.CreateSprite(SwinGame.BitmapNamed("Ship"));
                        SwinGame.DrawSprite(Sprite, Position);
                        break;
                    }
                case 1:
                    {
                        //this.Sprite = SwinGame.CreateSprite(SwinGame.BitmapNamed("PlayerDamaged"));
                        this.Sprite = SwinGame.CreateSprite(SwinGame.BitmapNamed("PlayerDamaged"));
                        SwinGame.DrawSprite(Sprite, Position);
                        break;
                    }
                default:
                    {
                        //this.Sprite = SwinGame.CreateSprite(SwinGame.BitmapNamed("Ship"));
                        this.Sprite = SwinGame.CreateSprite(SwinGame.BitmapNamed("Ship"));
                        SwinGame.DrawBitmap(SwinGame.BitmapNamed("Shield"), this.Position.X - 25, this.Position.Y - 35);
                        base.Draw();
                        break;
                    }
            }
        }

        //Bool because for strong barriers.
        public override bool IsExplosion()
        {
            Lives--;
            if (Lives <= 0)
            {
                //Explosion effect
                IsVisible = false;
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("LaserRedShot1"), Position.X, Position.Y);
                SwinGame.PlaySoundEffect("ExplosionPlayer");
                SwinGame.StopMusic();
                SwinGame.PlaySoundEffect("PlayerDie");
            }
            else
                //Player hit sound effect
                SwinGame.PlaySoundEffect("HitPlayer");
            return (Lives <= 0);
        }

        /// <summary>
        /// Player can have gun
        /// </summary>
        /// <param name="toEquip"></param>
        public void Equip(Gun toEquip)
        {
            _listofGuns.Add(toEquip);
            CurrentGun = toEquip;
        }

        /// <summary>
        /// Control the player on screen
        /// </summary>
        private void ControlPlayer()
        {
            if (Position.X < 0 - Sprite.Width / 2)
            {
                Position.X = SwinGame.ScreenWidth() - Sprite.Width / 2;
            }

            if (Position.X > SwinGame.ScreenWidth() - Sprite.Width / 2)
            {
                Position.X = 0 - Sprite.Width / 2;
            }


            if (Position.Y < 0)
            {
                Position.Y = 0;
            }

            if (Position.Y > SwinGame.ScreenHeight() - Sprite.Height)
            {
                Position.Y = SwinGame.ScreenHeight() - Sprite.Height;
            }
        }

        /// <summary>
        /// Swapping the gun
        /// </summary>
        /// <param name="gun"></param>
        private void ImplementGun(Gun gun)
        {
            SwinGame.PlaySoundEffect("SwapGun");
            CurrentGun = gun;
            CurrentGun.Position.X = this.Position.X + (this.Sprite.Width / 2);
            CurrentGun.Position.Y = this.Position.Y;
        }
    }
}


