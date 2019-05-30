using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// The object is a bullet that the gun will produce
    /// The Gun will direct the bullet by giving dx and dy value
    /// </summary>
    class Bullet : MoveableObject
    {
        private float _dx;
        private float _dy;


        public float Dy { get => _dy; set => _dy = value; }
        public float Dx { get => _dx; set => _dx = value; }

        /// <summary>
        /// Consstructor of the bullet
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="bulletSpeed"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public Bullet(string sprite, Point2D position, float bulletSpeed, float dx, float dy) : base(sprite, position, bulletSpeed)
        {
            Lives = 1;
            Dx = dx;
            Dy = dy;
        }

        public override void Update()
        {
            Move();
        }

        public override void Move()
        {
            Position.X -= ((Dx) * Speed);
            Position.Y -= ((Dy) * Speed);
        }

        public override bool IsExplosion()
        {
            Lives--;
            if (SpriteName == "LaserRed")
            {
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("LaserRedShot"), Position.X, Position.Y);
            }
            else if (SpriteName == "LaserGreen")
            {
                SwinGame.DrawBitmap(SwinGame.BitmapNamed("LaserGreenShot"), Position.X, Position.Y);
            }
            return (Lives <= 0);
        }
    }
}

