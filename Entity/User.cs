namespace Entity
{
    public class User
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }


        public User(int UserID, int PersonId, string userName, string Password, int isActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonId;
            this.UserName = userName;
            this.Password = Password;
            this.IsActive = isActive;
        }
        public User( int PersonId, string userName, string Password, int isActive)
        {

            this.PersonID = PersonId;
            this.UserName = userName;
            this.Password = Password;
            this.IsActive = isActive;
        }
        public User( int UserId, string userName, int isActive)
        {

            this.UserID = UserId;
            this.UserName = userName;
            this.IsActive = isActive;
        }
    }
}