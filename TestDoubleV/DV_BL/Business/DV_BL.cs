using TestDoubleV.DV_BL.Interfaces;
using TestDoubleV.DV_DL;
using TestDoubleV.DV_EF.DTO;
using TestDoubleV.DV_EF.User;

namespace TestDoubleV.DV_BL.Business
{
    public class DV_BL: IDV_BL
    {
        public HttpResponseData CreatePeopleAndUser(PeopleAndUserDTO peopleAndUserDTO)
        {
            PeopleAndUserDL peopleAndUserDL = new PeopleAndUserDL();
            return peopleAndUserDL.CreatePeopleAndUsers(peopleAndUserDTO);
        }

        public HttpResponseData Login(UserEF userEF)
        {
            UserDL userDL = new UserDL();
            return userDL.Login(userEF);
        }
    }
}
