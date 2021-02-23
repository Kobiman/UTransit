using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utransit.Services.Contracts;
using UTransit.Models;
using UTransit.Models.Requests;

namespace Utransit.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost,Route("AddStudents")]
        public IActionResult AddStudents([FromBody]IList<Student> students)
        {
           var result = _studentService.AddStudents(students);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        //[HttpPost, Route("GetStudent")]
        //public IActionResult GetStudent([FromBody] GetStudentRequest request)
        //{
        //    var result = _studentService.GetStudent(request);
        //    if (result.IsSucessful) return Ok(result);
        //    return BadRequest(result);
        //}

        [HttpGet, Route("GetByIndexNumber/{indexNumber}")]
        public IActionResult GetByIndexNumber([FromRoute] string indexNumber)
        {
            var result = _studentService.GetStudent(indexNumber);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost, Route("BuyVoucher")]
        public IActionResult BuyVoucher([FromBody]BuyVoucherRequest request)
        {
            var result = _studentService.BuyVoucher(request);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost, Route("MakePayment")]
        public IActionResult MakePayment([FromBody]MakePaymentRequest request)
        {
            var result = _studentService.MakePayment(request);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }
    }
}
