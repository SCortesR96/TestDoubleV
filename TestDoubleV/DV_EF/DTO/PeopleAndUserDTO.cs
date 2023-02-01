using TestDoubleV.DV_EF.People;
using TestDoubleV.DV_EF.User;

namespace TestDoubleV.DV_EF.DTO
{
    /// <summary>
    /// Contains People and User entity for making one call when both are needed
    /// in any part of the project
    /// </summary>
    public class PeopleAndUserDTO
    {
        public PeopleEF People { get; set; }
        public UserEF Users { get; set; }
    }
}
