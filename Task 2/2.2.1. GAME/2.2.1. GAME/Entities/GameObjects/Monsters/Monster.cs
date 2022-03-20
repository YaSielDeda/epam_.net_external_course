using _2._2._1._GAME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Entities.GameObjects
{
    /// <summary>
    /// Class, representing kind of movable hostile to player game objects
    /// </summary>
    public abstract class Monster : MovableGameObject, IAttack
    {
        public virtual void Attack(ref MovableGameObject movable)
        {
            movable.location = null;
        }
        /// <summary>
        /// Primitive step calculation logic with which the player is unlikely to win
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public Point NextStepCalculation(Player player)
        {
            Point destination = location.Clone() as Point;

            if (player.location.X > location.X)
                destination.X++;
            else if (player.location.X < location.X)
                destination.X--;

            if (player.location.Y > location.Y)
                destination.Y++;
            else if (player.location.Y < location.Y)
                destination.Y--;

            return destination;
        }
    }
}
