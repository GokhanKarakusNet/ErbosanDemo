using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Erbosan.Entities.Concrete
{
    public class Sales:IEntity
    {
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SalesDate { get; set; }
    }
}

