using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMQ.Banking.Application.DTO;
using RMQ.Banking.Application.Interfaces;
using RMQ.Banking.Domain.Models;

namespace RMQ.Banking.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService service;

        public BankingController(IAccountService service)
        {
            this.service = service;
        }
       

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return Ok(this.service.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer) {
            this.service.TransferFunds(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
