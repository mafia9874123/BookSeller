using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookStoreAPI.Orchestrations;
using Lib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreAPI.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookOrchestrator _bookOrchestrator;
        public BookController(BookOrchestrator bookOrchestrator)
        {
            _bookOrchestrator = bookOrchestrator;
        }

        // GET: api/<BookController>
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var message = await _bookOrchestrator.GetAllBook();
            return Ok(message);
        }

        // GET api/<BookController>/5
        [Authorize]
        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var message = await _bookOrchestrator.GetBook(id);
            return Ok(message);
        }

        // POST api/<BookController>
        [Authorize]
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> Post([FromBody] Order order, CancellationToken token)
        {
            var message = _bookOrchestrator.CreateOrder(order, token);
            return Ok(message);
        }

        // GET api/<BookController>/5
        [Authorize]
        [HttpGet("Search")]
        public async Task<IActionResult> SearchBook(string searchString)
        {
            var message = await _bookOrchestrator.SearchtBook(searchString);
            return Ok(message);
        }
    }
}
