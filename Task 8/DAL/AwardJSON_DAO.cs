using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task_8._1_THREE_LAYER.DAL;

namespace DAL
{
    public class AwardJSON_DAO : IDAO<Award>
    {
        private string _path = @"C:\Users\bereg\Documents\epam\Task 8\Data.json";
        private JSON_DTO _jsonDto;
        public AwardJSON_DAO()
        {
            string json = File.ReadAllText(_path);
            _jsonDto = JsonConvert.DeserializeObject<JSON_DTO>(json);
        }
        public bool DeleteByID(Guid id)
        {
            var i = GetByID(id);
            var res = _jsonDto.Awards.Remove(i);

            WriteAllChanges();
            return res;
        }
        public Award GetByID(Guid id) => _jsonDto.Awards.Where(x => x.Id == id).FirstOrDefault();
        public List<Award> GetAll() => _jsonDto.Awards;
        public void Create(Award Award)
        {
            _jsonDto.Awards.Add(Award);

            WriteAllChanges();
        }
        public void WriteAllChanges()
        {
            string json = JsonConvert.SerializeObject(_jsonDto);
            File.WriteAllText(_path, json);
        }
        public bool Update(Award award)
        {
            var i = _jsonDto.Awards.FindIndex(x => x == award);

            try
            {
                _jsonDto.Awards[i] = award;
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
