using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Erbosan.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
