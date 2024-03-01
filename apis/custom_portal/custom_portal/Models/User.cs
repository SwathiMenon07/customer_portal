using System.ComponentModel.DataAnnotations;

namespace custom_portal.models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Full_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
