using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class is responsible for object that have effect and have lifetime
    /// </summary>
    public abstract class Item : GameObject
    {
        /// <summary>
        /// The Created' s time of the item 
        /// </summary>
        private DateTime _timecreated;

        /// <summary>
        /// The duration of the item
        /// </summary>
        protected float _lifespan;

        /// <summary>
        /// Constructor of the item
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        public Item(string sprite, Point2D position) : base(sprite, position)
        {
            _timecreated = DateTime.Now;
            _lifespan = 0;
        }

        /// <summary>
        /// Check whether the item can be available
        /// </summary>
        /// <returns></returns>
        private bool IsAvailable()
        {
            return DateTime.Now > _timecreated.AddSeconds(_lifespan);
        }

        public override void Update()
        {
            if (IsAvailable())
                this.Position.Y = -50;
        }

        /// <summary>
        /// Every Item has effect
        /// </summary>
        public abstract void Effect();

        public override bool IsExplosion()
        {
            throw new NotImplementedException();
        }
    }
}
