using _2._2._1._GAME.Logic.Handling;
using _2._2._1._GAME.Logic.Handling.ControlHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Entities.GameObjects
{
    public class MovableGameObject : GameObject
    {
        public void MoveTo(Point destination, List<GameObject> gameObjects)
        {
            Handler InFieldHandle = new NotInFieldHandler(destination);
            NotBarrierPointHandler NotFreePointHandle = new NotBarrierPointHandler(destination, gameObjects);
            MoveHandler MoveHandle = new MoveHandler();

            InFieldHandle.Successor = NotFreePointHandle;
            NotFreePointHandle.Successor = MoveHandle;

            InFieldHandle.HandleRequest();

            if (MoveHandle.DoMove)
                location = destination;
        }
    }
}
