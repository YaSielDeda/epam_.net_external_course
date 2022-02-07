using _2._2._1._GAME.Entities;
using _2._2._1._GAME.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.UI
{
    /// <summary>
    /// Class, responsible for drawing all objects at the console
    /// </summary>
    public class Visualiser
    {
        private Field _field;
        private GameObjectGenerator _gObjGenerator;
        public Visualiser(GameObjectGenerator gogenerator)
        {
            int.TryParse(ConfigurationManager.AppSettings["Width"], out int width);
            int.TryParse(ConfigurationManager.AppSettings["Height"], out int height);

            _field = new Field(width, height);
            _gObjGenerator = gogenerator;
        }
        /// <summary>
        /// Draws game field and all game elements
        /// </summary>
        public void Draw()
        {
            Console.Clear();
            Console.WriteLine(new string('-', _field.Width + 1));

            List<GameObject> gameObjects = _gObjGenerator.GetGameObjects();

            for (int i = 0; i < _field.Height; i++)
            {
                Console.Write('|');

                for (int j = 0; j < _field.Width; j++)
                {
                    var obj = gameObjects.Where(x => x.location.Y == i && x.location.X == j).FirstOrDefault();

                    if (obj != null)
                    {
                        Type type = obj.GetType();

                        string fullName = type.FullName;

                        if (fullName.Contains("Monsters"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (fullName.Contains("Bonuses"))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (fullName.Contains("Barriers"))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                        }
                        //player case
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.Write(obj);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(' ');
                }
                Console.WriteLine('|');
            }

            Console.WriteLine(new string('-', _field.Width + 1));
        }

        public void ShowGameOverLoseScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔╗──╔╗╔═══╗╔╗─╔╗     ╔═══╗╔═══╗╔═══╗     ╔═══╗╔═══╗╔═══╗╔═══╗");
            Console.WriteLine("║╚╗╔╝║║╔═╗║║║─║║     ║╔═╗║║╔═╗║║╔══╝     ╚╗╔╗║║╔══╝║╔═╗║╚╗╔╗║");
            Console.WriteLine("╚╗╚╝╔╝║║─║║║║─║║     ║║─║║║╚═╝║║╚══╗     ─║║║║║╚══╗║║─║║─║║║║");
            Console.WriteLine("─╚╗╔╝─║║─║║║║─║║     ║╚═╝║║╔╗╔╝║╔══╝     ─║║║║║╔══╝║╚═╝║─║║║║");
            Console.WriteLine("──║║──║╚═╝║║╚═╝║     ║╔═╗║║║║╚╗║╚══╗     ╔╝╚╝║║╚══╗║╔═╗║╔╝╚╝║");
            Console.WriteLine("──╚╝──╚═══╝╚═══╝     ╚╝─╚╝╚╝╚═╝╚═══╝     ╚═══╝╚═══╝╚╝─╚╝╚═══╝");
            Console.ResetColor();
            PressAnyKeyMessage();
        }
        public void ShowGameOverWinScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔╗──╔╗╔═══╗╔╗─╔╗     ╔╗╔╗╔╗╔══╗╔═╗─╔╗");
            Console.WriteLine("║╚╗╔╝║║╔═╗║║║─║║     ║║║║║║╚╣─╝║║╚╗║║");
            Console.WriteLine("╚╗╚╝╔╝║║─║║║║─║║     ║║║║║║─║║─║╔╗╚╝║");
            Console.WriteLine("─╚╗╔╝─║║─║║║║─║║     ║╚╝╚╝║─║║─║║╚╗║║");
            Console.WriteLine("──║║──║╚═╝║║╚═╝║     ╚╗╔╗╔╝╔╣─╗║║─║║║");
            Console.WriteLine("──╚╝──╚═══╝╚═══╝      ╚╝╚╝╝╚══╝╚╝─╚═╝");
            Console.ResetColor();
            PressAnyKeyMessage();
        }
        public void PressAnyKeyMessage()
        {
            Console.WriteLine("Press any key to play again");
        }
    }
}
