using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This gun creates bullets from 1 to 360 degree angle everytime it shoots
    /// </summary>
    class _360DegreeGun : Gun
    {
        /// <summary>
        /// Constructor of the 360DegreeGun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public _360DegreeGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 1.7f;
            _fireRate = 10f;
        }

        public override void CreateBullet()
        {
            for (int i = 0; i <= 360; i += 15)
            {
                _dx = SwinGame.Cosine(i);
                _dy = SwinGame.Sine(i);

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
