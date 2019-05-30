using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This gun creates a ring of bullets everytime it shoots
    /// </summary>
    class CatastrophicGun : Gun
    {
        /// <summary>
        /// Constructor of the Catastrophic Gun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public CatastrophicGun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(name, sprite, position, gunSound, gunPower, storingList)
        {
            CoolDown = 2f;
            _fireRate = 2f;
        }

        public override void CreateBullet()
        {

            for (int i = 0; i <= 360; i += 20)
            {
                _dx = SwinGame.Sine(i);
                _dy = SwinGame.Cosine(i);

                //_dx = SwinGame.Tangent(i);
                //_dy = SwinGame.Sine(i);

                //_dx = SwinGame.Tangent(i);
                //_dy = SwinGame.Cosine(i);

                //_dx = SwinGame.Sine(i);
                //_dy = SwinGame.Tangent(i);

                //_dy = 1;
                //_dx = SwinGame.Cosine(i);
                //_dy += 0.5f;

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
