using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This gun creates 2 bullets at the same time everytime it shoots
    /// </summary>
    class DoubleLaserGun : Gun
    {
        /// <summary>
        /// Constructor of the double laser gun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public DoubleLaserGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 1.5f;
            _fireRate = 10f;
        }

        public override void CreateBullet()
        {
            for (float i = 2; i <= 4; i++)
            {
                _dx = 0;
                _dy = i;

                _storingList.Add(new Bullet(_gunPower, this.Position, _fireRate, _dx, _dy));
                SwinGame.PlaySoundEffect(_gunSound);
            }
        }

        public override bool IsExplosion()
        {
            throw new NotImplementedException();
        }
    }
}
