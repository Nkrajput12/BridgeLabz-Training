using System;

namespace HealthClinic.Entities
{
    public class Billing
    {
        public int BillID { get; set; }
        public int AppointmentID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
    }
}