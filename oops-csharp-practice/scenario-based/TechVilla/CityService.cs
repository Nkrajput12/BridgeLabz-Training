using System;

public abstract class CityService{
    public string ServiceName {get; protected set;}

    public static int TotalBooking {get; set;} = 0;

    

    public abstract void PerformService();

    
}

public class HealthcareService : CityService, IBookable {

    public void TotalService(){
        Console.WriteLine("Total service provide in city is "+CityService.TotalBooking);
    }
    public override void PerformService() {
        Console.WriteLine($"[Hospital] Running diagnostic check via {ServiceName}...");
    }

    public void BookService(Citizen citizen) {
        base.ServiceName = "CityHospital";
        CityService.TotalBooking++;
        Console.WriteLine($"[Success] Appointment booked for {citizen.Name} at {ServiceName}.");
    }
}