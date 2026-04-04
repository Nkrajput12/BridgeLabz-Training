using System;

class HotelBooking
{
    public string guestName;
    public string roomType;
    public int nights;

    public HotelBooking() { guestName = "Guest"; roomType = "Standard"; nights = 1; } //default

    public HotelBooking(string guestName, string roomType, int nights) //peremiterized constuctor
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.nights = nights;
    }

    public HotelBooking(HotelBooking other) // Copy Constructor
    {
        this.guestName = other.guestName;
        this.roomType = other.roomType;
        this.nights = other.nights;
    }

    public void ShowBooking() //method to display the booking details
    {
        Console.WriteLine($"Guest: {guestName} | Room: {roomType} | Nights: {nights}");
    }
}

class Application
{
    public static void Main(string[] args)
    {
        HotelBooking b1 = new HotelBooking("Amit", "Deluxe", 3); //calling perimetirized constructior
        HotelBooking b2 = new HotelBooking(b1); // Copying Amit's booking 

        //calling the method to show details of both the object
        b1.ShowBooking();
        b2.ShowBooking();
    }
}