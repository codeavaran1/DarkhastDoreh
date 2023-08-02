namespace Request_Course.VM
{
    public class AdminCreateVM
    {
        public string Name { get; set; }=string.Empty;

        public string Username { get; set; }= string.Empty; 

        public string Phone { get; set; }=string.Empty ;

        public string Password { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        public bool IsUser { get; set; } = false;

    }
}
