using Application;
using Application.Features.LibUser.Commands.CreateLibUser;
using Application.Features.LibUser.Queries.GetAllLibUsers;
using Application.Features.LibUser.Queries.GetLibUser;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class LibUserController : BaseController
    {
        private IMapper mapper;
        private IDispatcher dispatcher;

        public LibUserController(IMapper mapper, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.mapper = mapper;
        }

        // GET: api/<LibUserController>
        [HttpGet]
        public async Task<IActionResult> GetLibUsers()
        {
            GetAllLibUsersQuery query = new GetAllLibUsersQuery();
            var result = await this.dispatcher.Dispatch(query);
            return FromResult(result);
        }

        // GET api/<LibUserController>/5
        [HttpGet]
        [Route("LibUser/{SSN}")]
        public async Task<IActionResult> GetLibUser(int ssn)
        {
            var result = await this.dispatcher.Dispatch(new GetLibUserQuery(ssn));
            return FromResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibUser(CreateLibUserRequest libUserRequest)
        {
            CreateLibUserCommand command = new CreateLibUserCommand(
                libUserRequest.SSN,
                libUserRequest.FName,
                libUserRequest.Surname,
                libUserRequest.Address,
                libUserRequest.Phone,
                libUserRequest.Campus,
                libUserRequest.MemberType,
                libUserRequest.LibrarianType);
            var result = await this.dispatcher.Dispatch(command);
            return FromResult(result);
        }
    }
}
