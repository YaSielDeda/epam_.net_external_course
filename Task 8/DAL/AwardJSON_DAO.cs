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
        JSON_DTO _jsonDto;
        public AwardJSON_DAO()
        {
            string json = File.ReadAllText(_path);
            _jsonDto = JsonConvert.DeserializeObject<JSON_DTO>(json);
        }
        public void DeleteByID(Guid id)
        {
            var i = _jsonDto.Awards.FindIndex(x => x.Id == id);

            _jsonDto.Awards.RemoveAt(i);
        }
        public Award GetById(Guid id) => _jsonDto.Awards.Where(x => x.Id == id).FirstOrDefault();
        public List<Award> GetAll() => _jsonDto.Awards;
        public void Create(Award Award) => _jsonDto.Awards.Add(Award);
        public void WriteAllChanges()
        {
            string json = JsonConvert.SerializeObject(_jsonDto);
            File.AppendAllText(_path, json);
        }
        public void Update(Award Award)
        {
            var i = _jsonDto.Awards.FindIndex(x => x == Award);

            if (Award != null)
            {
                _jsonDto.Awards[i] = Award;
            }
        }
    }
}
