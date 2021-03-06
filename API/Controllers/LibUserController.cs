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
            try
            {
                GetAllLibUsersQuery query = new GetAllLibUsersQuery();
                var result = await this.dispatcher.Dispatch(query);
                return FromResult(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
            
        }

        // GET api/<LibUserController>/5
        [HttpGet]
        [Route("{SSN}")]
        public async Task<IActionResult> GetLibUser(int ssn)
        {
            try
            {
                var result = await this.dispatcher.Dispatch(new GetLibUserQuery(ssn));
                return FromResult(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }           
        }

        [HttpPost]
        public async Task<IActionResult> CreateLibUser(CreateLibUserRequest libUserRequest)
        {
            try
            {
                CreateLibUserCommand command = new CreateLibUserCommand(
                libUserRequest.SSN,
                libUserRequest.FName,
                libUserRequest.Surname,
                libUserRequest.Address,
                libUserRequest.Phone,
                libUserRequest.Campus);
                var result = await this.dispatcher.Dispatch(command);
                return FromResult(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }            
        }
    }
}
