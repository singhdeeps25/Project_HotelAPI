using System;
using Microsoft.AspNetCore.Mvc;
using Project_HotelAPI.Models;
using static Project_HotelAPI.Models.Hotel;

namespace Project_HotelAPI.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Search")]
        public IActionResult SearchHotel(string location, string checkIn, string checkOut, int guests)
        {
            var hotels = new List<object>
            {
                new { HotelId = 1, Name = "The Leela", Location = "Delhi", Rating = 3.0},
                new { HotelId = 2, Name = "Hayat Residency", Location = "Delhi", Rating = 2.0},
                new { HotelId = 3, Name = "Hotel Park In", Location = "Delhi", Rating = 4.0},
                new { HotelId = 4, Name = "Hotel Radisson", Location = "Delhi", Rating = 1.0},
                new { HotelId = 5, Name = "Hotel Taj", Location="Delhi", Rating = 5.0}
            };
            return Ok(hotels);
        }
        [HttpGet("{hotelId}/availability")]
        public IActionResult CheckAvailability(int hotelId, string checkIn, string checkOut)
        {
            var availability = new
            {
                HotelId = hotelId,
                RoomsAvailable = new[] { "Deluxe Room", "Suite", "Standard Room", "Delux Twin Bed", "Deluxe Single Bed" }
            };
            return Ok(availability);
        }
        [HttpPost("{hotelId}/prebook")]
        public IActionResult PrebookHotel(int hotelId, [FromBody] PrebookRequest request)
        {
            var prebookConfirmation = new
            {
                prebookId = Guid.NewGuid(),
                hotelId = hotelId,
                Status = "Prebooked",
                Expiry = DateTime.Now.AddMinutes(10),
            };
            return Ok(prebookConfirmation);
        }
        [HttpPost("{hotelId}/book")]
        public IActionResult BoookHotel(int hotelId, [FromBody] BookRequest request)
        {
            var bookingConfirmation = new
            {
                bookingId = Guid.NewGuid(),
                HotelId = hotelId,
                status = "Confirmed",
                AmountPaid = request.Amount
            };
            return Ok(bookingConfirmation);
        }
    }
}
