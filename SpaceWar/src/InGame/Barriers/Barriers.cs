using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class will create barriers that player will face
    /// </summary>
    class Barriers : MoveableObject
    {
        /// <summary>
        /// Constructor of the barriers
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public Barriers(string sprite, Point2D position, float speed) : base(sprite, position, speed)
        {
        }

        public override void Update()
        {
            Move();
        }

        public override void Move()
        {
            Position.Y += Speed;
          
        }

        public override bool IsExplosion()
        {
            SwinGame.PlaySoundEffect("ExplosionOther");
            return true;
        }
    }

}
