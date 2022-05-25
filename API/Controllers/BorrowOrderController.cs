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
            try
            {
                GetAllBorrowOrdersQuery query = new GetAllBorrowOrdersQuery();
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
        public async Task<IActionResult> GetBorrowOrder(int id)
        {
            try
            {
                var result = await this.dispatcher.Dispatch(new GetBorrowOrderQuery(id));
                return FromResult(result);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBorrowOrder(UpdateBorrowOrderRequest request)
        {
            try
            {
                UpdateBorrowOrderCommand updateCommand =
                    new UpdateBorrowOrderCommand(request.OrderID, request.ReturnDate);
                var result = await dispatcher.Dispatch(updateCommand);
                return FromResult(result);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBorrowOrder(CreateBorrowOrderRequest request)
        {
            try
            {
                CreateBorrowOrderCommand command = new CreateBorrowOrderCommand(
                request.BorrowDate,
                request.Borrower,
                request.Librarian,
                request.Item);
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
