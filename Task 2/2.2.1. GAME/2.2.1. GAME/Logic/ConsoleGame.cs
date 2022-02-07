using _2._2._1._GAME.Entities.GameObjects;
using _2._2._1._GAME.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Logic
{
    public class ConsoleGame
    {
        public void Start()
        {
            while (true)
            {
                GameObjectGenerator gameObjectGenerator = new();
                gameObjectGenerator.GenerateGameObjects();

                Visualiser visualiser = new(gameObjectGenerator);

                var gameObjects = gameObjectGenerator.GetGameObjects();

                MovableGameObject player = gameObjects.Where(x => x.ToString() == "P").FirstOrDefault() as MovableGameObject;

                //Player only controller
                ControlLogic playerControlLogic = new(player, ref gameObjects);

                List<ControlLogic> listOfNpcsControlLogics = new();

                //Controllers for monsters
                foreach (var item in gameObjects.Where(x => x.ToString() != "P" && x.GetType().FullName.Contains("Monsters")))
                {
                    listOfNpcsControlLogics.Add(new(item as MovableGameObject, ref gameObjects));
                }

                while (true)
                {
                    if (player.location == null)
                    {
                        visualiser.ShowGameOverLoseScreen();
                        break;
                    }
                    else if (!gameObjects.Where(x => x.GetType().FullName.Contains("Bonuses")).Any())
                    {
                        visualiser.ShowGameOverWinScreen();
                        break;
                    }

                    playerControlLogic.PlayerMakeMove(Console.ReadKey());

                    foreach (var npcLogic in listOfNpcsControlLogics)
                    {
                        npcLogic.NPCMakeMove();
                    }

                    playerControlLogic.PlayerDoInteraction();

                    foreach (var npcLogic in listOfNpcsControlLogics)
                    {
                        npcLogic.NPCMakeInteraction();
                    }
                    visualiser.Draw();
                }
            }
        }
    }
}
