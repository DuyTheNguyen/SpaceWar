using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;

namespace SpaceWar
{
    /// <summary>
    /// This class is responsible that object that can shoot and create bullet
    /// </summary>
    public abstract class Gun : GameObject
    {
        /// <summary>
        /// whether the gun can shoot
        /// </summary>
        private bool _canShoot;

        /// <summary>
        /// Time that the gun shot
        /// </summary>
        private DateTime _shootTime;

        /// <summary>
        /// Cooldown time
        /// </summary>
        private float _coolDown;

        private string _name;

        /// <summary>
        /// Sound effect when shooting
        /// </summary>
        protected string _gunSound;

        /// <summary>
        /// Image effect when shooting
        /// </summary>
        protected string _gunPower;

        /// <summary>
        /// Fire rate of the gun
        /// </summary>
        protected float _fireRate;

        /// <summary>
        /// use for directing the bullet
        /// </summary>
        protected float _dx;

        /// <summary>
        /// use for directing the bullet
        /// </summary>
        protected float _dy;

        /// <summary>
        /// For battle controller
        /// </summary>
        protected List<GameObject> _storingList;

        public string Name { get => _name; set => _name = value; }
        //for drawing on text
        public float CoolDown { get => _coolDown; set => _coolDown = value; }
        /// <summary>
        /// Constructor of the gun
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sprite"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="gunSound"></param>
        /// <param name="gunPower"></param>
        /// <param name="storingList"></param>
        public Gun(string name, string sprite, Point2D position, string gunSound, string gunPower, List<GameObject> storingList) : base(sprite, position)
        {
            Name = name;
            _gunSound = gunSound;
            _gunPower = gunPower;
            _storingList = storingList;
        }

        /// <summary>
        /// Shoot function
        /// </summary>
        public virtual void Shoot()
        {
            if (_canShoot)
            {
                _shootTime = DateTime.Now;
                _canShoot = false;
                CreateBullet();
            }

            ShootCooldown();
        }

        /// <summary>
        /// Cooldown checking function
        /// </summary>
        public virtual void ShootCooldown()
        {
            if (!_canShoot && DateTime.Now > _shootTime.AddSeconds(CoolDown))
                _canShoot = true;
        }

        /// <summary>
        /// Can create bullet
        /// </summary>
        public abstract void CreateBullet();
    }
}
