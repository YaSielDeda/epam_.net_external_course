using _2._2._1._GAME.Entities;
using _2._2._1._GAME.Entities.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Logic.Handling.ControlHandling
{
    /// <summary>
    /// Handle movable object behavior relatively provided GameObject
    /// </summary>
    public class ObjectInteractionHandler : Handler
    {
        private MovableGameObject _movableObject;
        private GameObject _gameObject;
        public ObjectInteractionHandler(MovableGameObject movable, GameObject gameObject)
        {
            _movableObject = movable;
            _gameObject = gameObject;
        }
        public override void HandleRequest()
        {
            Type type = _movableObject.GetType();

            string fullName = type.FullName;

            if (fullName.Contains("Monsters"))
            {
                var monster = _movableObject as Monster;
                MovableGameObject targetMovableObject = _gameObject as MovableGameObject;
                monster.Attack(ref targetMovableObject);
            }
            //player case
            else
            {
                var player = _movableObject as Player;
            }
        }
    }
}
