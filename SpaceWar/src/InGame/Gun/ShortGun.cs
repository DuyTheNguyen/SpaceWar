using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This gun create a bunch of bullet at the same time everytime it shoots
    /// </summary>
    class ShortGun : Gun
    {
        /// <summary>
        /// Constructor of the shortgun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public ShortGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 1f;
            _fireRate = 15f;
        }

        public override void CreateBullet()
        {
            _dx = 1;
            _dy = 1;
            for (float i = -1; i <= 1; i += 0.3f)
            {
                _dx = i;

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
