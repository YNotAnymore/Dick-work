using DomainCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderDomain.Model
{
    public class Order:IAggregateRoot
    {

        public int Id { get; set; }
        
        public decimal Amount { get; set; }

        public decimal ActualAmount { get; set; }

        public string Intro { get; set; }

        public int UserId { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
