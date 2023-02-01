using System.ComponentModel.DataAnnotations;

namespace TestDoubleV.DV_EF.User
{
    public class UserEF
    {
        public int Id { get; set; }
        [Required, MinLength(6)]
        public string Username { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
