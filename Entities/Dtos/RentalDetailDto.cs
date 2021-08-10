using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalDetailDto:IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Brandname { get; set; }
        public string ColorName { get; set; }
        public string CompanyName { get; set; }
        public int CarModelYear { get; set; }
        public Decimal CarDailyPrice { get; set; }
        public string CarDescription { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
