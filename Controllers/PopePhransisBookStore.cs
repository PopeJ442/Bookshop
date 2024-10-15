using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PopePhransisBookStore.Model;
using PopePhransisBookStore.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using PopePhransisBookStore.DTO;

namespace PopePhransisBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopePhransisBookStore(IBookRepository bookRepository, IMapper mapper) : ControllerBase
    {
        private readonly IBookRepository bookRepository = bookRepository;
        private readonly IMapper mapper = mapper;


        [Authorize]
        [HttpPost("CreateBook")]
       public async Task<ActionResult<BookDTO>> CreateBook([FromBody] BookDTO bookDto)
    {
    if (bookDto == null)
    {
        return BadRequest("Book is null.");
    }

    
    var book = mapper.Map<Book>(bookDto);


    var createdBook = await bookRepository.CreateBook(book);
   

    var createdBookDto = mapper.Map<BookDTO>(createdBook);
   
    return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBookDto);
}

         [Authorize]
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

    
            var bookDto = mapper.Map<BookDTO>(book);
            return Ok(bookDto);
        }

        [Authorize]
        [HttpGet("ListOfBooks")]
        public async Task<ActionResult<List<BookDTO>>> ListOfBooks()
        {
            var books = await bookRepository.ListOfBooks();

   
            var bookDtos = mapper.Map<List<BookDTO>>(books);
            return Ok(bookDtos);
        }
        [Authorize]
        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult<BookDTO>> UpdateBook(int id, [FromBody] BookDTO updatedBookDto)
        {
            if (updatedBookDto == null)
            {
                return BadRequest();
            }


            var existingBook = await bookRepository.GetBook(id);
            if (existingBook == null)
            {
                return NotFound();
            }

     
            var updatedBook = mapper.Map(updatedBookDto, existingBook);

            var result = await bookRepository.UpdateBook(updatedBook);


            var resultDto = mapper.Map<BookDTO>(result);
            return Ok(resultDto);
        }


        [Authorize]
        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var isDeleted = await bookRepository.DeleteBook(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }

    }
}
