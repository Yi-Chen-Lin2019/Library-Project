using System;
using System.Threading.Tasks;
using Application;
using Application.Features.ItemDescriptor.Queries.GetAllItemDescriptors;
using Application.Features.ItemDescriptor.Queries.GetItemDescriptor;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ItemDescriptorController : BaseController
    {
        private IMapper mapper;
        private IDispatcher dispatcher;

        public ItemDescriptorController(IMapper mapper, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetItemDescriptors()
        {
            GetAllItemDescriptorsQuery query = new GetAllItemDescriptorsQuery();
            var result = await this.dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemDescriptor(int id)
        {
            var result = await this.dispatcher.Dispatch(new GetItemDescriptorQuery(id));
            return FromResult(result);
        }
    }
}
