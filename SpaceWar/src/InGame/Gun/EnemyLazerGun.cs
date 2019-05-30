using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This is an enemy gun that will create one bullet everytime it shoots
    /// </summary>
    class EnemyLazerGun : LazerGun
    {
        /// <summary>
        /// Constructor of the enemy lazer gun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public EnemyLazerGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 2f;
            _fireRate = 5;
        }

        public override void CreateBullet()
        {
            _dx = 0;
            _dy = -1;
            _storingList.Add(new Bullet(_gunPower, new Point2D() { X = this.Position.X, Y = this.Position.Y + 91 }, _fireRate, _dx, _dy));
            SwinGame.PlaySoundEffect(_gunSound);
        }
    }
}
