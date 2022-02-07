using _2._2._1._GAME.Entities.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Interfaces
{
    public interface IAttack
    {
        public abstract void Attack(ref MovableGameObject movable);
    }
}
