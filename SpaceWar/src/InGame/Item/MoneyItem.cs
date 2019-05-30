using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This Item will increase the score for the player
    /// </summary>
    class MoneyItem : Item
    {
        private int _value;

        /// <summary>
        /// Constructor of the money item
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public MoneyItem(string sprite, Point2D position) : base(sprite, position)
        {
            _lifespan = 2.5f;
            _value = 5;
        }

        public override void Effect()
        {
            BattleController.Score += _value;
        }

        public override bool IsExplosion()
        {
            Effect();
            SwinGame.PlaySoundEffect("MoneySnd");
            return true;
        }
    }
}
