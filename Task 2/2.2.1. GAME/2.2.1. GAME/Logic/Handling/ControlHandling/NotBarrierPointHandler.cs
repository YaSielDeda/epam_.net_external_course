using _2._2._1._GAME.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace _2._2._1._GAME.Logic.Handling.ControlHandling
{
    /// <summary>
    /// Checks if some GameObject are located in provided Point
    /// </summary>
    class NotBarrierPointHandler : Handler
    {
        private Point _potentialLocation;
        private List<GameObject> _gameObjects;
        public bool IsNotEmpty { get; private set; }
        public NotBarrierPointHandler(Point point, List<GameObject> gameObjects)
        {
            _potentialLocation = point;
            _gameObjects = gameObjects;
        }
        public override void HandleRequest()
        {
            var obj = _gameObjects.Where(x => x.location.X == _potentialLocation.X && x.location.Y == _potentialLocation.Y && x.GetType().FullName.Contains("Barriers")).FirstOrDefault();

            if (obj == null)
            {
                Successor.HandleRequest();
            }
            else
                IsNotEmpty = true;
        }
    }
}
