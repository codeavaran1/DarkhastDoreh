namespace Request_Course.VM
{
    public class AdminUpdateVM
    {
        public int id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        public bool IsUser { get; set; } = false;
    }
}
