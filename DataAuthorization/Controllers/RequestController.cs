using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAuthorization.DataBase.Entities;
using DataAuthorization.DtoModels;
using DataAuthorization.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAuthorization.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class RequestController : Controller
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("Add")]
        public string Add([FromBody] Request request)
        {
            if (_requestService.AddRequest(request) > 0)
            {
                return "New Request Added";
            }
            return "New Request Failed";
        }

        [HttpGet("GetAll")]
        public IEnumerable<Request> GetAll()
        {
            return _requestService.GetAllRequest();
        }
    }
}
