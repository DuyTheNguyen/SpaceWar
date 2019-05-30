using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This Item increases the player's life by one
    /// </summary>
    class LiveUpItem : Item
    {
        private int _liveValue;

        /// <summary>
        /// Constructor of the live up item
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public LiveUpItem(string sprite, Point2D position) : base(sprite, position)
        {
            _liveValue = 1;
            _lifespan = 1.5f;
        }

        public override void Effect()
        {
            BattleController.NewPlayer.Lives += _liveValue;
        }

        public override bool IsExplosion()
        {
            Effect();
            SwinGame.PlaySoundEffect("LiveUpSnd");
            return true;
        }
    }
}
