namespace EasyTracking.Datas.Users {
    public class UserRequest {

        public UserRequest(string userName, string password) {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}