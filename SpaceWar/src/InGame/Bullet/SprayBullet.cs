using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This is a special bullet that is based in the original one
    /// </summary>
    class SprayBullet : Bullet
    {
        /// <summary>
        /// Constructor of the SprayBullets
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="bulletSpeed"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public SprayBullet(string sprite, Point2D position, float bulletSpeed, float dx, float dy) : base(sprite, position, bulletSpeed, dx, dy)
        {
        }

        public override void Move()
        {
            Dy += 0.08f;
            base.Move();
        }
    }
}
