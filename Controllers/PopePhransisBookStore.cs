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
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
      public class PopePhransisBookStore(IBookRepository bookRepository, IMapper mapper) : ControllerBase
    {
        private readonly IBookRepository bookRepository = bookRepository;
        private readonly IMapper mapper = mapper;

        /// <summary>
        /// This endpoint is used to create a new book 
        /// </summary>
        /// <param name="bookDto"></param>
        /// <returns></returns>
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
        /// <summary>
        /// This endpoint is used to get  book 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// This endpoint gets all the books in the system
        /// </summary>
        /// <response code= "200"> Returns the list of all the books"</response>
       // [Authorize]
        [HttpGet("ListOfBooks")]
        [ProducesResponseType(200)] 
        public async Task<ActionResult<List<BookDTO>>> ListOfBooks()
        {
            var books = await bookRepository.ListOfBooks();

   
            var bookDtos = mapper.Map<List<BookDTO>>(books);
            return Ok(bookDtos);
        } 



        /// <summary>
        /// This endpoint is used to update the details of a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBookDto"></param>
        /// <returns></returns>
       // [Authorize]
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

        /// <summary>
        ///This is used to delete a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize]
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
