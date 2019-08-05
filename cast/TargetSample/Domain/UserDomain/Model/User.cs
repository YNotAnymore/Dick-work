using System;
using System.Collections.Generic;
using System.Text;
using DomainCore;

namespace UserDomain.Model
{

    public class User: IAggregateRoot
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}
