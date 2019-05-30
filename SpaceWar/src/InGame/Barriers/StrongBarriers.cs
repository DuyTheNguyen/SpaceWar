using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class will create strong barriers that have shield which can block player bullets and have gun 
    /// </summary>
    class StrongBarriers : Barriers
    {
        private Gun _currentgun;

        public Gun CurrentGun { get => _currentgun; set => _currentgun = value; }

        /// <summary>
        /// Constructor of the strong barrier
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public StrongBarriers(string sprite, Point2D position, float speed) : base(sprite, position, speed)
        {
            Lives = 3;
            //Add gun to enemy ship
            Equip(new EnemyLazerGun("EnemyLazerGun", "", new Point2D() { X = Position.X + Sprite.Width / 2, Y = Position.Y + Sprite.Height }, "EnemyWeapon", "LaserGreen", BattleController.EnemyBullets));
            //Add gun to enemy gun list
            BattleController.EnemyGuns.Add(CurrentGun);
        }

        public override void Update()
        {
            Move();
            _currentgun.Shoot();
        }

        public override void Draw()
        {
            switch (Lives)
            {
                case 3:
                    {
                        //SwinGame.DrawRectangle(Color.Red, this.Position.X, this.Position.Y, this.Sprite.Width, this.Sprite.Height);
                        SwinGame.DrawBitmap(SwinGame.BitmapNamed("EnemyShield1"), this.Position.X - 22, this.Position.Y - 22);
                        base.Draw();
                        break;
                    }
                case 2:
                    {
                        //SwinGame.DrawRectangle(Color.White, this.Position.X, this.Position.Y, this.Sprite.Width, this.Sprite.Height);
                        SwinGame.DrawBitmap(SwinGame.BitmapNamed("EnemyShield2"), this.Position.X - 22, this.Position.Y - 22);
                        base.Draw();
                        break;
                    }
                case 1:
                    {
                        base.Draw();
                        break;
                    }
            }
        }

        public override void Move()
        {
            base.Move();
            _currentgun.Position.Y = Position.Y;
        }

        public override bool IsExplosion()
        {
            Lives--;
            if (Lives <= 0)
            {
                //Explosion effect
                SwinGame.PlaySoundEffect("ExplosionEnemy");
            }
            else
                //Player hit sound effect
                SwinGame.PlaySoundEffect("Hit");

            return (Lives <= 0);
        }

        /// <summary>
        /// strong barriers has gun
        /// </summary>
        /// <param name="toequip"></param>
        public void Equip(Gun toequip)
        {
            _currentgun = toequip;
        }
    }
}
