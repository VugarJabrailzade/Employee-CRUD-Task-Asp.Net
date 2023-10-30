using EmployeeCrudTask.CheckingCode;
using EmployeeCrudTask.Database.DomainModels;
using EmployeeCrudTask.Database.Repositeries;
using EmployeeCrudTask.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Reflection;
using System.Text.RegularExpressions;

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


        [HttpGet]
        public IActionResult Employee()
        {

            return View(_employeeRepository.GetAllWithDepartaments());
        }


        #region Employee Add

        [HttpGet("employeeAdd", Name ="employee-add")]
        public IActionResult EmployeeAdd()
        {
            var departament = _departamentRepository.GetAll();
            var model = new EmployeeAddRequestViewModel
            {
                Departaments = departament
            };

            return View(model);
        }



        [HttpPost("employeeAdd", Name = "employee-add")]
        public async  Task<IActionResult> EmployeeAdd(EmployeeAddRequestViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var departament = _departamentRepository.GetAll();
                model = new EmployeeAddRequestViewModel
                {
                    Departaments = departament
                };
                return View(model);
            }
            if (model.DepartamentId != null)
            {
                var departament = _departamentRepository.GetById(model.DepartamentId.Value);
                if (departament == null)
                {
                    ModelState.AddModelError("DepartamentId", "Category doesn't exist");

                    return BadRequest();
                }
            }
            EmployeeCodeService UniqueCode = new EmployeeCodeService(_employeeRepository);

            var employee = new Employee
            {
                Name = model.Name,
                Surname = model.Surname,
                FatherName = model.FatherName,
                FinCode = model.Fincode,
                Email = model.Email,
                EmployeeImg = model.Employeeimg,
                DepartamentId = model.DepartamentId,
                EmployeeCode = UniqueCode.GenerateRandomCode(),
                IsDeleted = false

            };

            //string emailPattern = @;
            
             
            try
            {
                _employeeRepository.Insert(employee);
            }
            catch (PostgresException e)
            {
                _logger.LogError(e, "Postgresql Exception");

                throw e;
            }

            return RedirectToAction("Employee");
        }

        #endregion


        #region Employee Edit(Update)

        [HttpGet]
        public IActionResult EmployeeEdit(string employeeCode)
        {
            Employee employee = _employeeRepository.GetByEmployeeCode(employeeCode);
            if (employee == null)
                return NotFound();


            var model = new EmployeeUpdateViewModel
            {

                Name = employee.Name,
                Surname = employee.Surname,
                FatherName = employee.FatherName,
                Fincode = employee.FinCode,
                Email = employee.Email,
                Employeeimg = employee.EmployeeImg,
                Departaments = _departamentRepository.GetAll()

            };

            return View(model);
        }

        [HttpPost]
        //public IActionResult SubmitEmployeeEdit()
        //{
        //    if (!ModelState.IsValid)
        //        return PrepareValidationView("Views/Admin/Product/ProductEdit.cshtml");

        //    if (model.CategoryId != null)
        //    {
        //        var category = _categoryRepository.GetById(model.CategoryId.Value);
        //        if (category == null)
        //        {
        //            ModelState.AddModelError("CategoryId", "Category doesn't exist");

        //            return PrepareValidationView("Views/Admin/Product/ProductAdd.cshtml");
        //        }
        //    }

        //    Product product = _productRepository.GetById(model.Id);
        //    if (product == null)
        //        return NotFound();


        //    product.Name = model.Name;
        //    product.Price = model.Price;
        //    product.Rating = model.Rating;
        //    product.CategoryId = model.CategoryId;


        //    try
        //    {
        //        _productRepository.Update(product);
        //    }
        //    catch (PostgresException e)
        //    {
        //        _logger.LogError(e, "Postgresql Exception");

        //        throw e;
        //    }


        //    return RedirectToAction("Products");
        //}


        #endregion


        #region Delete by Id


        [HttpGet]
        public IActionResult EmployeeDelete(string employeeCode)
        {

            Employee employee = _employeeRepository.GetByEmployeeCode(employeeCode);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.DeleteByEmployeeCode(employee.EmployeeCode);

            return RedirectToAction("Employee");

        }
            

        #endregion

    }
}
