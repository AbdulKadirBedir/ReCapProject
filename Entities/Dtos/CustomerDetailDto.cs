using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CustomerDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public int CompanyName { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public int Status { get; set; }
    }
}
