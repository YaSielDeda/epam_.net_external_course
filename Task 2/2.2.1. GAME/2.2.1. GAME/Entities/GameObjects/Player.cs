using _2._2._1._GAME.Entities.GameObjects;
using _2._2._1._GAME.Logic.Handling;
using _2._2._1._GAME.Logic.Handling.ControlHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Entities
{
    public class Player : MovableGameObject
    {
        public void Take(ref Bonus bonus)
        {
            bonus.location = null;
        }
        public override string ToString()
        {
            return $"P";
        }
    }
}
