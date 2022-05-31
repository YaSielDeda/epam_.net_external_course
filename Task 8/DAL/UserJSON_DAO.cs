using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Task_8._1_THREE_LAYER.DAL
{
    public class UserJSON_DAO : IDAO<User>
    {
        private string _path = @"C:\Users\bereg\Documents\epam\Task 8\Data.json";
        private JSON_DTO _jsonDto;
        public UserJSON_DAO()
        {
            string json = File.ReadAllText(_path);
            _jsonDto = JsonConvert.DeserializeObject<JSON_DTO>(json);
        }
        public bool DeleteByID(Guid id)
        {
            var i = GetByID(id);
            var res = _jsonDto.Users.Remove(i);

            WriteAllChanges();
            return res;
        }
        public User GetByID(Guid id) => _jsonDto.Users.Where(x => x.Id == id).FirstOrDefault();
        public List<User> GetAll() => _jsonDto.Users;
        public void Create(User user)
        {
            _jsonDto.Users.Add(user);

            WriteAllChanges();
        }
        private void WriteAllChanges()
        {
            string json = JsonConvert.SerializeObject(_jsonDto);
            File.WriteAllText(_path, json);
        }
        public bool Update(User user)
        {
            var i = _jsonDto.Users.FindIndex(x => x == user);

            try
            {
                _jsonDto.Users[i] = user;
                WriteAllChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}