﻿using System;
using System.Threading.Tasks;
using Application;
using Application.Features.ItemDescriptor.Commands.CreateItemDescriptor;
using Application.Features.ItemDescriptor.Queries.GetAllItemDescriptors;
using Application.Features.ItemDescriptor.Queries.GetItemDescriptor;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
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
        [Route("Map")]
        public async Task<IActionResult> CreateMap(CreateItemDescriptorRequest itemDescriptorRequest)
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

        [HttpPost]
        [Route("Article")]
        public async Task<IActionResult> CreateArticle(CreateItemDescriptorRequest itemDescriptorRequest)
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

        [HttpPost]
        [Route("Book")]
        public async Task<IActionResult> CreateBook(CreateItemDescriptorRequest itemDescriptorRequest)
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
    }
}