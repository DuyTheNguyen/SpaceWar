using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// The gun will produce the X bullets everytime it shoots
    /// </summary>
    class XGun : Gun
    {
        /// <summary>
        /// Constructor of the XGun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public XGun(string name, string sprite, Point2D position,  string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 1.5f;
            _fireRate = 2f;
        }

        public override void CreateBullet()
        {
            for (int i = 0; i <= 360; i += 30)
            {
                _dx = SwinGame.Tangent(i);
                _dy = SwinGame.Sine(i);

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
