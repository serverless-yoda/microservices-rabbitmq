using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMQ.Transfer.Application.Interfaces;
using RMQ.Transfer.Application.Services;
using RMQ.Transfer.Domain.Models;

namespace RMQ.Transfer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService service;

        public TransferController(ITransferService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> GetAllTransferLogs() {
            return Ok(service.GetAllTransferLogs());
        }
    }
}
