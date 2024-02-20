using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetLIstAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Date=createBookingDto.Date,
                Name=createBookingDto.Name,
                Phone=createBookingDto.Phone,
                PersonCount= createBookingDto.PersonCount
            };
            _bookingService.TAdd(booking);
            return Ok("Booking was created successfuly");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Booking was deleted successfuly");

        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = updateBookingDto.Name,
                BookingID = updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };
            _bookingService.TUpdate(booking);
            return Ok("Booking was updated successfuly");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}

