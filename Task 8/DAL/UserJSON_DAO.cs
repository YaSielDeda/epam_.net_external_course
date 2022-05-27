using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Task_8._1_THREE_LAYER.Entities;

namespace Task_8._1_THREE_LAYER.DAL
{
    public class UserJSON_DAO : IDAO<User>
    {
        private string _path = Environment.CurrentDirectory + @"\Data.json";
        JSON_DTO _jsonDto;
        public UserJSON_DAO()
        {
            string json = File.ReadAllText(_path);
            _jsonDto = JsonConvert.DeserializeObject<JSON_DTO>(json);
        }
        public void DeleteByID(Guid id)
        {
            var i = _jsonDto.Users.FindIndex(x => x.Id == id);

            _jsonDto.Users.RemoveAt(i);
        }
        public void TestFill()
        {
            User user1 = new User("Vasya", new DateTime(1998, 4, 24));
            User user2 = new User("Petya", new DateTime(2000, 5, 12));

            Award award1 = new Award("Binary search expert");
            Award award2 = new Award("Dynamic programming expert");

            user1.AwardIDs.Add(award1.Id);

            user2.AwardIDs.Add(award1.Id);
            user2.AwardIDs.Add(award2.Id);

            award1.UserIDs.Add(user1.Id);
            award1.UserIDs.Add(user2.Id);

            award2.UserIDs.Add(user2.Id);

            _jsonDto = new JSON_DTO();

            _jsonDto.Users = new List<User>();
            _jsonDto.Users.Add(user1);
            _jsonDto.Users.Add(user2);

            _jsonDto.Awards = new List<Award>();
            _jsonDto.Awards.Add(award1);
            _jsonDto.Awards.Add(award2);

            string json = JsonConvert.SerializeObject(_jsonDto);
            File.AppendAllText(_path, json);
        }
        public User GetById(Guid id) => _jsonDto.Users.Where(x => x.Id == id).FirstOrDefault();
        public List<User> GetAll() => _jsonDto.Users;
        public void Create(User user) => _jsonDto.Users.Add(user);
        public void WriteAllChanges()
        {
            string json = JsonConvert.SerializeObject(_jsonDto);
            File.AppendAllText(_path, json);
        }
        public void Update(User user)
        {
            var i = _jsonDto.Users.FindIndex(x => x == user);

            if (user != null)
            {
                _jsonDto.Users[i] = user;
            }
        }
    }
}