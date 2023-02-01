using TestDoubleV.DV_EF.DTO;
using TestDoubleV.DV_EF.User;

namespace TestDoubleV.DV_BL.Interfaces
{
    public interface IDV_BL
    {
        public HttpResponseData CreatePeopleAndUser(PeopleAndUserDTO peopleAndUserDTO);

        public HttpResponseData Login(UserEF userEF);
    }
}
