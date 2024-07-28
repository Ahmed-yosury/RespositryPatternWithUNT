using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RespositryPatternWithUNT.core.Dtos;
using RespositryPatternWithUNT.core.Interfaces;
using RespositryPatternWithUNT.core.Models;

namespace RespositryPatternWithUNT.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly IBaseRespositry<Author> _authorRespositry;
        //public AuthorController( IBaseRespositry<Author> authorRespositry)
        //{
        //    _authorRespositry = authorRespositry;
            
        //}
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EmployeeController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
           
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _unitOfWork.Employees.GetByIdAsync(id));
        }
       
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.Employees.GetAllAsync());
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetName(string name)
        {
            if (name != null)
            {
                return Ok(_unitOfWork.Employees.Find(n => n.Name == name));
            }
            else
                return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddAuther(EmployeeDtos employee)
        {
            if (ModelState.IsValid)
            {
                var employe = AddEmployee(employee);
                var Emp =  _unitOfWork.Employees.Add(employe);
                _unitOfWork.complate();
                return Ok(Emp);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, EmployeeDtos employee)
        {
            if (Id != employee.Id)
            {
                return BadRequest(ModelState);
            }
            var employe = UpdateEmployee(employee,Id);

            _unitOfWork.Employees.Update(employe);
            _unitOfWork.complate();
            return Ok("update");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee= _unitOfWork.Employees.GetById(id);
            if (employee != null)
            {
                _unitOfWork.Employees.Delete(employee);
                _unitOfWork.complate();
                return Ok("deleted");
            }
            return BadRequest(ModelState);
        }
        [NonAction]
        public Employee AddEmployee(EmployeeDtos employeeDtos)
        {
            Employee employee = new Employee();
            employee.Name = employeeDtos.Name;
            employee.JopId = employeeDtos.JopId;
            employee.date=employeeDtos.date;
            employee.photopath = Addimagepath(employeeDtos.image);
            return employee;
        }
       
        [NonAction]
        public string Addimagepath (IFormFile file)
        {
            
            string fileName= file.FileName;
            string Filepath=Getfilepath(fileName);
            if (!System.IO.Directory.Exists(Filepath))
            {
                System.IO.Directory.CreateDirectory(Filepath);
            }
            string imagepath = Filepath + "\\image.png";
            if (System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);
            }
            using (FileStream stream = System.IO.File.Create(imagepath))
            {

                 file.CopyToAsync(stream);

                
            }
            return "https://localhost:44323/"+imagepath;
        }
        [NonAction]
        public Employee UpdateEmployee(EmployeeDtos employee, int id)
        {
            Employee employee1 = _unitOfWork.Employees.GetById(id);
            employee1.date = employee.date;
            employee1.JopId = employee.JopId;
            employee1.Name = employee.Name;
            employee1.photopath = UpdateImagePath(employee.image);
            return employee1;


        }
        [NonAction]
        public string UpdateImagePath(IFormFile file) 
        {
            string fileName= file.Name;
            string Filepath= Getfilepath(fileName);
            if (!System.IO.Directory.Exists(Filepath))
            {
                System.IO.Directory.CreateDirectory(Filepath);
            }
           // string fileurl=""+fileName
            string imagePath=System.IO.Path.Combine(Filepath, "image.png");
            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyToAsync(stream);
            }
            return "https://localhost:44323/" + imagePath;
        }

        [NonAction]
        private string Getfilepath(string filename)
        {
            return Path.Combine( _webHostEnvironment.WebRootPath + "www.rot\\Images\\" + filename)  ;
        }

    }

}
