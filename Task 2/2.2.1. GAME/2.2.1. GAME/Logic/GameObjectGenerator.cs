using _2._2._1._GAME.Entities;
using _2._2._1._GAME.Entities.Enums;
using _2._2._1._GAME.Entities.GameObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace _2._2._1._GAME.Logic
{
    public class GameObjectGenerator
    {
        private List<GameObject> _gameObjects;
        private int _numberOfMonsters;
        private int _numberOfBarriers;
        private int _numberOfBonuses;
        public int xRange { get; private set; }
        public int yRange { get; private set; }
        public GameObjectGenerator()
        {
            _gameObjects = new List<GameObject>();

            int.TryParse(ConfigurationManager.AppSettings["number_of_monsters"], out _numberOfMonsters);
            int.TryParse(ConfigurationManager.AppSettings["number_of_barriers"], out _numberOfBarriers);
            int.TryParse(ConfigurationManager.AppSettings["number_of_bonuses"], out _numberOfBonuses);
        }
        public List<GameObject> GetGameObjects() => _gameObjects;
        public void GenerateGameObjects()
        {
            CreateRange();

            Generate<Monster, MonsterVariations>("Monsters", _numberOfMonsters);
            Generate<Barrier, BarrierVariations>("Barriers", _numberOfBarriers);
            Generate<Bonus, BonusVariations>("Bonuses", _numberOfBonuses);

            var Player = new Player();
            GiveUniqueLocation(Player);

            _gameObjects.Add(Player);
        }
        private void Generate<T, TE>(string folderName, int count) where T : class 
                                                                   where TE : Enum
        {
            for (int i = 0; i < count; i++)
            {
                try
                {
                    int number = new Random().Next(Enum.GetNames(typeof(TE)).Length);

                    var className = (TE)(object)number;

                    var monster = Activator.CreateInstance(null, $"_2._2._1._GAME.Entities.GameObjects.{folderName}.{className}").Unwrap() as T;

                    GiveUniqueLocation(monster as GameObject);

                    _gameObjects.Add(monster as GameObject);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private void GiveUniqueLocation(GameObject gameObject)
        {
            Point location = null;
            do
            {
                location = new Point(new Random().Next(1, xRange), new Random().Next(1, yRange));
            } 
            while (_gameObjects.Where(x => x.location == location).ToList().Count > 0);

            gameObject.location = location;
        }
        private void CreateRange()
        {
            int.TryParse(ConfigurationManager.AppSettings["Width"], out int xTemp);
            int.TryParse(ConfigurationManager.AppSettings["Height"], out int yTemp);

            xRange = xTemp--;
            yRange = yTemp--;
        }
    }
}
