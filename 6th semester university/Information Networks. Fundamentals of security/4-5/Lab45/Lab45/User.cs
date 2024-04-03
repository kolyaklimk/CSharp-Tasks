namespace Lab45
{
    internal class User
    {
        public string? Login { get; set; } = "";
        public string? Password { get; set; } = "";
        public bool Authorized { get; set; } = false;
        public Roles Role { get; set; }
        public Roles DowngratedRole
        {
            get
            {
                switch (Role)
                {
                    case Roles.SuperUser:
                        return Roles.VipUser;
                    case Roles.Admin:
                        return Roles.SuperUser;
                    default:
                        return Role;
                }
            }
        }

        public User(string login, string password, bool authorized, Roles role)
        {
            Login = login;
            Password = password;
            Authorized = authorized;
            Role = role;
        }

        public User() { }
    }
}
