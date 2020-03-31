using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RMQ.Banking.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountType { get; set; }

        [Range(1,1_000_000_000)]
        public decimal AccountBalance { get; set; }
    }
}
