using System;
using System.Threading.Tasks;
using Application;
using Application.Features.ItemDescriptor.Commands.CreateItemDescriptor;
using Application.Features.ItemDescriptor.Queries.GetAllItemDescriptors;
using Application.Features.ItemDescriptor.Queries.GetItemDescriptor;
using AutoMapper;
using MediatR;
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
            try
            {
                GetAllItemDescriptorsQuery query = new GetAllItemDescriptorsQuery();
                var result = await this.dispatcher.Dispatch(query);
                return FromResult(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }       
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItemDescriptor(int id)
        {
            try
            {
                var result = await this.dispatcher.Dispatch(new GetItemDescriptorQuery(id));
                return FromResult(result);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPost]
        [Route("Map")]
        public async Task<IActionResult> CreateMap(CreateItemDescriptorRequest itemDescriptorRequest)
        {
            try
            {
                CreateItemDescriptorCommand command = new CreateItemDescriptorCommand(
                itemDescriptorRequest.Year,
                itemDescriptorRequest.Author,
                itemDescriptorRequest.Title,
                itemDescriptorRequest.Description,
                itemDescriptorRequest.Publisher,
                itemDescriptorRequest.BorrowType,
                itemDescriptorRequest.ItemDescriptorType
                );
                var result = await this.dispatcher.Dispatch(command);
                return FromResult(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }          
        }

        [HttpPost]
        [Route("Article")]
        public async Task<IActionResult> CreateArticle(CreateItemDescriptorRequest itemDescriptorRequest)
        {
            try
            {
                CreateItemDescriptorCommand command = new CreateItemDescriptorCommand(
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
                var result = await this.dispatcher.Dispatch(command);
                return FromResult(result);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }          
        }

        [HttpPost]
        [Route("Book")]
        public async Task<IActionResult> CreateBook(CreateItemDescriptorRequest itemDescriptorRequest)
        {
            try
            {
                CreateItemDescriptorCommand command = new CreateItemDescriptorCommand(
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
