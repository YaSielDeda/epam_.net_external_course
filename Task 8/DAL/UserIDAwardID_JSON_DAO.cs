using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8._1_THREE_LAYER.DAL;

namespace DAL
{
    public class UserIDAwardID_JSON_DAO : IDAO<AwardUser>
    {
        private string _path = @"C:\Users\bereg\Documents\epam\Task 8\Data.json";
        JSON_DTO _jsonDto;
        public UserIDAwardID_JSON_DAO()
        {
            string json = File.ReadAllText(_path);
            _jsonDto = JsonConvert.DeserializeObject<JSON_DTO>(json);
        }
        public void DeleteByID(Guid id)
        {
            var entity = GetByID(id);
            _jsonDto.AwardIDUserID.Remove(entity);

            WriteAllChanges();
        }
        public List<AwardUser> GetAll() => _jsonDto.AwardIDUserID;
        public void Create(AwardUser awardUser)
        {
            _jsonDto.AwardIDUserID.Add(awardUser);

            WriteAllChanges();
        }
        private void WriteAllChanges()
        {
            string json = JsonConvert.SerializeObject(_jsonDto);
            File.WriteAllText(_path, json);
        }

        public void Update(AwardUser item) { }

        public AwardUser GetByID(Guid id)
        {
            var i = _jsonDto.AwardIDUserID.FindIndex(x => x.Id == id);

            return _jsonDto.AwardIDUserID[i];
        }
    }
}
