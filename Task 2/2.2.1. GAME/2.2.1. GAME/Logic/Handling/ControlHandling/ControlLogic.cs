using _2._2._1._GAME.Entities;
using _2._2._1._GAME.Entities.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._2._1._GAME.Logic
{
    public class ControlLogic
    {
        private readonly MovableGameObject _movableGameObject;
        private List<GameObject> _gameObjects;
        public ControlLogic(MovableGameObject movable, ref List<GameObject> gameObjects)
        {
            _movableGameObject = movable;
            _gameObjects = gameObjects;
        }

        public void PlayerMakeMove(ConsoleKeyInfo key)
        {
            var player = _movableGameObject as Player;
            Point destination = player.location.Clone() as Point;

            switch (key.Key.ToString())
            {
                case "W":
                    destination.Y--;
                    break;
                case "S":
                    destination.Y++;
                    break;
                case "A":
                    destination.X--;
                    break;
                case "D":
                    destination.X++;
                    break;
                default:
                    break;
            }

            player.MoveTo(destination, _gameObjects);
        }
        public void PlayerDoInteraction()
        {
            var player = _gameObjects.Where(x => x.ToString() == "P").FirstOrDefault() as Player;

            var bonus = _gameObjects.FirstOrDefault(x => x.location.X == player.location.X && x.location.Y == player.location.Y) as Bonus;

            if (bonus != null)
            {
                player.Take(ref bonus);
                DeletingNullLocationObjects();
            }
        }
        public void NPCMakeMove()
        {
            var monster = _movableGameObject as Monster;
            Point destination = monster.NextStepCalculation(_gameObjects.Where(x => x.ToString() == "P").FirstOrDefault() as Player);
            monster.MoveTo(destination, _gameObjects);
        }
        public void NPCMakeInteraction()
        {
            var monster = _movableGameObject as Monster;

            var movableObject = _gameObjects.Where(x => x.location.X == monster.location.X && x.location.Y == monster.location.Y).Where(x => x.ToString() == "P").FirstOrDefault() as MovableGameObject;

            if(movableObject != null)
            {
                monster.Attack(ref movableObject);
                DeletingNullLocationObjects();
            }
        }
        private void DeletingNullLocationObjects() => _gameObjects.RemoveAll(x => x.location == null);
    }
}
