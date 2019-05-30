using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This abstract class is responsible for strong barriers that have item
    /// </summary>
    abstract class SpecialBarrier : StrongBarriers
    {
        /// <summary>
        /// Item it has
        /// </summary>
        protected Item _item;

        /// <summary>
        /// For the battle controller
        /// </summary>
        protected List<GameObject> _listofItem;

        /// <summary>
        /// Constructor of the special barrier
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="listofItem"></param>
        public SpecialBarrier(string sprite, Point2D position, float speed, List<GameObject> listofItem) : base(sprite, position, speed)
        {
            _listofItem = listofItem;
        }

        public override bool IsExplosion()
        {
            Lives--;
            if (Lives <= 0)
            {
                //Explosion effect
                SwinGame.PlaySoundEffect("ExplosionEnemy");
                Herritage();
            }
            else
                //Player hit sound effect
                SwinGame.PlaySoundEffect("Hit");

            return (Lives <= 0);
        }

        /// <summary>
        /// It will leave item when it dies
        /// </summary>
        public abstract void Herritage();
    }
}
