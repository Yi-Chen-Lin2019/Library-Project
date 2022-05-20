using System;
using Application;
using AutoMapper;

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
    }
}
