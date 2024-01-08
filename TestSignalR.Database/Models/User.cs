using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestSignalR.Database.Models
{
    public class User : NativeEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }


        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }

        [NotMapped]
        public string SurnameName
        {
            get => Surname + " " + Name;
        }

        [NotMapped]
        public string SurnameNamePatronymic
        {
            get => Surname + " " + Name + " " + Patronimyc;
        }

        [JsonIgnore]
        public List<Friendship> Friendship { get; set; }
        [JsonIgnore]
        public List<Friendship> Friendship1 { get; set; }

        public List<RequestOfFriendship> RequestOfFriendship { get; set; }
        public List<RequestOfFriendship> RequestOfFriendship1 { get; set; }

        public override void UpdateProperties(NativeEntity entity)
        {
            if (entity is User user)
            {
                Login = user.Login;
                Password = user.Password;
                Surname = user.Surname;
                Name = user.Name;
                Patronimyc = user.Patronimyc;
            }

        }
    }
}
