using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This gun creates Sine Bullet everytime it shoots
    /// </summary>
    class SineGun : Gun
    {
        /// <summary>
        /// Constructor of the Sine Gun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public SineGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 2.5f;
            _fireRate = 0.5f;
        }

        public override void CreateBullet()
        {
            _dy = 1;
            for (int i = 0; i <= 720; i += 20)
            {
                _dx = SwinGame.Cosine(i);
                _dy += 0.5f;

                _storingList.Add(new SprayBullet(_gunPower, this.Position, _fireRate, _dx, _dy));

                SwinGame.PlaySoundEffect(_gunSound);
            }
        }

        public override bool IsExplosion()
        {
            throw new NotImplementedException();
        }
    }
}
