namespace Project_HotelAPI.Models
{
    public class Hotel
    {
        public class PrebookRequest
        {
            public string CustomerName { get; set; }
            public string RoomType { get; set; }
            public string CheckIn { get; set; }
            public string CheckOut { get; set; }
        }
        public class BookRequest
        {
            public string PreebookId { get; set; }
            public decimal Amount { get; set; }
            public string PaymentMethod { get; set; }
        }
    }
}
