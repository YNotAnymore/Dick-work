using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public decimal ActualAmount { get; set; }

        public string Intro { get; set; }

        public int UserId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}