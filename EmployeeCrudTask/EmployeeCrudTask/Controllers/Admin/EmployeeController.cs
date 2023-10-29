using EmployeeCrudTask.Database.DomainModels;
using EmployeeCrudTask.Database.Repositeries;
using EmployeeCrudTask.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace EmployeeCrudTask.Controllers.Admin
{
    
    public class AdminController : Controller
    {

        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartamentRepository _departamentRepository;
        private readonly ILogger<AdminController> _logger;

        public AdminController()
        {
            _employeeRepository = new EmployeeRepository();
            _departamentRepository = new DepartamentRepository();

            var factory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            _logger = factory.CreateLogger<AdminController>();
        }


        [HttpGet("index", Name ="employee-list")]
        public IActionResult Employee()
        {
            return View(_employeeRepository.GetAll());
        }


        #region Employee Add

        [HttpGet("employeeAdd", Name ="employee-add")]
        public IActionResult EmployeeAdd()
        {
            var departament = _departamentRepository.GetAll();
            var model = new EmployeeAddResponseViewModel
            {
                Departament = departament
            };

            return View(model);
        }



        [HttpPost("employeeAdd", Name = "employee-add")]
        public IActionResult EmployeeAdd(EmployeeAddRequestViewModel model)
        {

            if (model.DepartamentId != null)
            {
                var departament = _departamentRepository.GetById(model.DepartamentId.Value);
                if (departament == null)
                {
                    ModelState.AddModelError("DepartamentId", "Category doesn't exist");

                    return BadRequest();
                }
            }

            var employee = new Employee
            {
                Name = model.Name,
                Surname = model.Surname,
                FatherName = model.FatherName,
                FinCode = model.Fincode,
                Email = model.Email,
                EmployeeImg = model.Employeeimg,
                DepartamentId = model.DepartamentId

            };

            try
            {
                _employeeRepository.Insert(employee);
            }
            catch (PostgresException e)
            {
                _logger.LogError(e, "Postgresql Exception");

                throw e;
            }

            return RedirectToAction("index");
        }

        #endregion


        #region Employee Edit(Update)

        [HttpGet]
        public IActionResult EmployeeEdit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitEmployeeEdit()
        {
                return View();
        }


        #endregion


        #region Delete by Id


        [HttpGet]
        public IActionResult EmployeeDelete()
        {
            return View();

        }

        #endregion

    }
}
