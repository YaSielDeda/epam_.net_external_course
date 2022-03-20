using _2._2._1._GAME.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Logic.Handling.ControlHandling
{
    /// <summary>
    /// Checks if potential point are located into field range
    /// </summary>
    public class NotInFieldHandler : Handler
    {
        private readonly Point _potentialLocation;
        public NotInFieldHandler(Point point)
        {
            _potentialLocation = point;
        }

        public override void HandleRequest()
        {
            int.TryParse(ConfigurationManager.AppSettings["Width"], out int xTemp);
            int.TryParse(ConfigurationManager.AppSettings["Height"], out int yTemp);

            bool xCorrect = _potentialLocation.X >= 0 && _potentialLocation.X < xTemp;
            bool yCorrect = _potentialLocation.Y >= 0 && _potentialLocation.Y < yTemp;

            if (xCorrect && yCorrect && Successor != null)
            {
                Successor.HandleRequest();
            }
        }
    }
}
