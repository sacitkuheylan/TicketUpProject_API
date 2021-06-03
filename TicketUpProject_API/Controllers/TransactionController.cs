using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketUpProject_API.Service.Features.TransactionFeatures.Commands;
using TicketUpProject_API.Service.Features.TransactionFeatures.Queries;

namespace TicketUpProject_API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Transaction")]
    [ApiVersion("1.0")]
    public class TransactionController : ControllerBase
    {
            private IMediator _mediator;
            protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

            [HttpPost]
            public async Task<IActionResult> Create(AddTransactionCommand command)
            {
                return Ok(await Mediator.Send(command));
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                return Ok(await Mediator.Send(new GetTransactionByIdQuery { Id = id }));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                return Ok(await Mediator.Send(new DeleteTransactionCommand { Id = id }));
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, UpdateTransactionCommand command)
            {
                if (id != command.Id)
                {
                    return BadRequest();
                }
                return Ok(await Mediator.Send(command));
            }
        }
    }
