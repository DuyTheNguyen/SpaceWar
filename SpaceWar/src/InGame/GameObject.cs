using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class is responsible for every object in Game
    /// </summary>
    public abstract class GameObject
    {
        private Sprite _sprite;
        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        /// <summary>
        /// Every ojbject has lives, adnd effect when they die
        /// For Battlecontroller, strong barriers and player
        /// </summary>
        private int _lives;
        public int Lives { get => _lives; set => _lives = value; }

        public Point2D Position;

        private string _spriteName;
        public string SpriteName
        {
            get { return _spriteName; }
            set { _spriteName = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sprite"> name of sprite </param>
        /// <param name="position"> position of it</param>
        public GameObject(string sprite, Point2D position)
        {
            Position = position;
            SpriteName = sprite;
            Sprite = new Sprite(SwinGame.BitmapNamed(SpriteName));
            
        }

        /// <summary>
        /// Update object every frame
        /// </summary>
        public virtual void Update()
        {
        }

        /// <summary>
        /// Draw Game Object
        /// </summary>
        public virtual void Draw()
        {
            SwinGame.DrawSprite(Sprite, Position);
        }

        /// <summary>
        /// Every object can be explosed  
        /// </summary>
        /// <returns></returns>
        public abstract bool IsExplosion();
    }
}
