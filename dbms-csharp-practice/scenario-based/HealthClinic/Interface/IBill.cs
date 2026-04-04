using System;

interface IBill
{
    void GenerateBill();
    void ViewOutstandingBills();
    void GenerateRevenueReport();
    void ProcessOutstandingPayment();
}