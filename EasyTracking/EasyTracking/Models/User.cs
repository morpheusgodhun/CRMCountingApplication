namespace EasyTracking.Models {
    public class User {

        public User() { }

        public void AddUser(int id, string fullName, string token) {
            Id = id;
            FullName = fullName;
            Token = token;
        }

        public void SetDescription(string description)
            => Description = description;

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Token { get; private set; }
        public string Description { get; set; }
    }
}