using System;
using System.Threading.Tasks;
using Application;
using Application.Features.ItemDescriptor.Commands.CreateItemDescriptor;
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

        [HttpPost]
        public async Task<IActionResult> CreateItemDescriptor(CreateItemDescriptorRequest itemDescriptorRequest)
        {
            CreateItemDescriptorCommand command = null;
            switch (itemDescriptorRequest.ItemDescriptorType)
            {
                case Domain.AggregateRoots.ItemDescriptorType.Map:
                    command = new CreateItemDescriptorCommand(
                itemDescriptorRequest.Year,
                itemDescriptorRequest.Author,
                itemDescriptorRequest.Title,
                itemDescriptorRequest.Description,
                itemDescriptorRequest.Publisher,
                itemDescriptorRequest.BorrowType,
                itemDescriptorRequest.ItemDescriptorType
                );
                    break;
                case Domain.AggregateRoots.ItemDescriptorType.Article:
                    command = new CreateItemDescriptorCommand(
                itemDescriptorRequest.Year,
                itemDescriptorRequest.Author,
                itemDescriptorRequest.Title,
                itemDescriptorRequest.Description,
                itemDescriptorRequest.Publisher,
                itemDescriptorRequest.BorrowType,
                itemDescriptorRequest.ItemDescriptorType,
                itemDescriptorRequest.Subject,
                itemDescriptorRequest.ReleaseDate
                );
                    break;
                case Domain.AggregateRoots.ItemDescriptorType.Book:
                    command = new CreateItemDescriptorCommand(
                itemDescriptorRequest.Year,
                itemDescriptorRequest.Author,
                itemDescriptorRequest.Title,
                itemDescriptorRequest.Description,
                itemDescriptorRequest.Publisher,
                itemDescriptorRequest.BorrowType,
                itemDescriptorRequest.ItemDescriptorType,
                itemDescriptorRequest.Subject,
                itemDescriptorRequest.ISBN,
                itemDescriptorRequest.Edition
                );
                    break;
                default:
                    break;
            }
            var result = await this.dispatcher.Dispatch(command);
            return FromResult(result);
        }
    }
}
