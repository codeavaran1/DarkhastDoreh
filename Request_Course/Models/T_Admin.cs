using System.ComponentModel.DataAnnotations;

namespace Request_Course.Models
{
    public class T_Admin
    {
        [Key]
        public int id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public string? UserName { get; set; }=string.Empty;

        public string? Phone { get; set; } = string.Empty;

        public string? Password { get; set; }=string.Empty;

        public string? Code { get; set; } = string.Empty;

        public string? img { get; set; }= string.Empty;

        public bool Admin { get; set; } = false;

        public bool User { get; set; } = false;

    }
}
