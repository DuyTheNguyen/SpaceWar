using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class is responsible for object that can move and have speed
    /// </summary>
    public abstract class MoveableObject : GameObject
    {
        private float _speed;

        /// <summary>
        /// Moveable object has speed.
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Constructor of the Moveableobject
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        public MoveableObject(string sprite, Point2D position, float speed) : base(sprite, position)
        {
            Speed = speed;
        }

        /// <summary>
        /// controlling the movement of the object
        /// </summary>
        public abstract void Move();
    }
}
