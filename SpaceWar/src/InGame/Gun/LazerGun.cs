using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// The gun create one single bullet everytime it shoots
    /// </summary>
    class LazerGun : Gun
    {
        /// <summary>
        /// Constructor of the lazergun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public LazerGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 0.2f;
            _fireRate = 25;
        }

        public override void CreateBullet()
        {
            _dx = 0;
            _dy = 1;
            _storingList.Add(new Bullet(_gunPower, this.Position, _fireRate, _dx, _dy));
            SwinGame.PlaySoundEffect(_gunSound);
        }

        public override bool IsExplosion()
        {
            throw new NotImplementedException();
        }
    }
}
