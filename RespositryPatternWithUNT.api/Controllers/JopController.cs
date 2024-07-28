using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespositryPatternWithUNT.core.Dtos;
using RespositryPatternWithUNT.core.Interfaces;
using RespositryPatternWithUNT.core.Models;

namespace RespositryPatternWithUNT.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JopController : ControllerBase
    {
        //private readonly IBaseRespositry<Book> _BookRespositry;
        //public BooksController(IBaseRespositry<Book> BookRespositry)
        //{
        //    _BookRespositry = BookRespositry;

        //}
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JopController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult Get( int id)
        {
            return Ok( _unitOfWork.Jops.GetById(id));
        }
        [HttpGet("GETAll")]
        public async Task<IActionResult> GetAll()
        {
           // var jops= _unitOfWork.Jops.Getjops();
           // var booksDto=_mapper.Map<IEnumerable<BookDtos>>(books);
            return Ok(_unitOfWork.Jops.Getjops());
        }
        [HttpPost]
        public async Task<IActionResult> AddJpp(JopDots jop)
        {
            if (ModelState.IsValid)
            {

              var AddJop=_mapper.Map<Jop>(jop);
              await  _unitOfWork.Jops.Add(AddJop);
              _unitOfWork.complate();
              return Ok(jop);
            }
            else
            { 
              return BadRequest(ModelState);
            }
            

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJop(int id, JopDots jop)
        {
            if (id > 0)
            {
                var Updatejop = _unitOfWork.Jops.GetById(id);
                if (Updatejop != null)
                {
                    if (ModelState.IsValid)
                    {
                        var updatejops=_mapper.Map<Jop>(jop);
                         _unitOfWork.Jops.Update(updatejops);
                        //_unitOfWork.complate();

                        return Ok("Updated");
                    }
                    return BadRequest(ModelState);
                }
                
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jop=_unitOfWork.Jops.GetById(id);
            if (jop != null)
            {
                _unitOfWork.Jops.Delete(jop);
                _unitOfWork.complate();
                return Ok("deleted");
            }
            return BadRequest(ModelState);
        }
    }
}
