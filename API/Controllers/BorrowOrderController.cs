using Application;
using Application.Features.BorrowOrder.Commands.CreateBorrowOrder;
using Application.Features.BorrowOrder.Commands.UpdateBorrowOrder;
using Application.Features.BorrowOrder.Queries.GetAllBorrowOrders;
using Application.Features.BorrowOrder.Queries.GetBorrowOrder;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    public class BorrowOrderController : BaseController
    {
        private IMapper mapper;
        private IDispatcher dispatcher;

        public BorrowOrderController(IMapper mapper, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBorrowOrders()
        {
            GetAllBorrowOrdersQuery query = new GetAllBorrowOrdersQuery();
            var result = await this.dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBorrowOrder(int id)
        {
            var result = await this.dispatcher.Dispatch(new GetBorrowOrderQuery(id));
            return FromResult(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBorrowOrder(UpdateBorrowOrderRequest request)
        {
            UpdateBorrowOrderCommand updateCommand =
                new UpdateBorrowOrderCommand(request.OrderID , request.ReturnDate);
            var result = await dispatcher.Dispatch(updateCommand);
            return FromResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrowOrder(CreateBorrowOrderRequest request)
        {
            CreateBorrowOrderCommand command = new CreateBorrowOrderCommand(
                request.BorrowDate,
                request.Borrower,
                request.Librarian,
                request.Item);
            var result = await this.dispatcher.Dispatch(command);
            return FromResult(result);
        }
    }
}
