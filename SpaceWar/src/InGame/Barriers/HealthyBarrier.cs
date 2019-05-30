using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This barrier will produce player's life when dead
    /// </summary>
    class HealthyBarrier : SpecialBarrier
    {
        /// <summary>
        /// Constructor of the healthy barrier
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="listofItem"></param>
        public HealthyBarrier(string sprite, Point2D position, float speed, List<GameObject> listofItem) : base(sprite, position, speed, listofItem)
        {
        }

        public override void Herritage()
        {
            SwinGame.PlaySoundEffect("LiveUpAppears");
            this._item = new LiveUpItem("PlayerLife", new Point2D() { X = this.Position.X + this.Sprite.Width / 2, Y = this.Position.Y + this.Sprite.Height / 2 });
            _listofItem.Add(_item);
        }
    }
}
