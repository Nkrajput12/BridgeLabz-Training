using System;

interface IAppointment
{
    void BookAppointment();
    void CheckAvailability();
    void CancelAppointment();
    void ShowAllAppointment();
    void RescheduleAppointment();

}