using Microsoft.AspNetCore.Mvc;
using TestDoubleV.DV_BL.Interfaces;
using TestDoubleV.DV_EF.DTO;
using TestDoubleV.DV_EF.User;

namespace TestDoubleV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleAndUserController : ControllerBase
    {
        private IDV_BL iDV_BL;

        public PeopleAndUserController(IDV_BL dV_BL)
        {
            iDV_BL = dV_BL;
        }

        [HttpPost(Name = "CreatePeopleAndUser")]
        public IActionResult Create(PeopleAndUserDTO peopleAndUserDTO)
        {
            HttpResponseData httpResponseData = iDV_BL.CreatePeopleAndUser(peopleAndUserDTO);
            return HttpResponse(httpResponseData);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserEF userEF)
        {
            HttpResponseData httpResponseData = iDV_BL.Login(userEF);
            return HttpResponse(httpResponseData);
        }

        /// <summary>
        /// This method was created for making selecting the status
        /// response to be sent
        /// </summary>
        /// <param name="httpResponseData">Object with status and data</param>
        /// <returns>Http response to know the data to be sent</returns>
        private IActionResult HttpResponse(HttpResponseData httpResponseData)
        {
            switch (httpResponseData.Status)
            {
                case "Success":
                    return Ok(httpResponseData.Data);
                case "Error":
                    return BadRequest(httpResponseData.Data);
                case "Exception":
                    return StatusCode(StatusCodes.Status500InternalServerError, httpResponseData.Data);
                default:
                    return NoContent();
            }
        }

    }
}