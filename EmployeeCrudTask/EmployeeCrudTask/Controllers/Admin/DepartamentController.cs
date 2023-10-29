using EmployeeCrudTask.Database.DomainModels;
using EmployeeCrudTask.Database.Repositeries;
using EmployeeCrudTask.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace EmployeeCrudTask.Controllers.Admin
{

    [Route("admin/departament")]
    public class AdminDepartamentController : Controller
    {
        private readonly DepartamentRepository _departamentRepository;
        private readonly ILogger<AdminDepartamentController> _logger;

        public AdminDepartamentController()
        {
            _departamentRepository = new DepartamentRepository();
            var factory = LoggerFactory.Create(builder => { builder.AddConsole(); });

            _logger = factory.CreateLogger<AdminDepartamentController>();
        }



        [HttpGet("list", Name="departament-list")]
        public IActionResult Index()
        {
            return View(_departamentRepository.GetAll());
        }

        #region Add

        [HttpGet("add", Name = "add-departament")]
        public IActionResult Add()
        {
            var departament = _departamentRepository.GetAll();

            var model = new DepartamentAddRequestViewModel
            {
                Departaments = departament
            };
            return View(model);
        }


        [HttpPost("add", Name ="add-departament")]
        public IActionResult SubmitAddDepartament(SubmitAddDepartamentViewModel model)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departament = new Departament
            {
                Id = model.Id,
                Name = model.Name
            };

            try
            {
                _departamentRepository.InsertDepartament(departament);
            }
            catch (PostgresException e)
            {
                _logger.LogError(e, "Postgresql Exception");

                throw e;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Edit
        [HttpGet("edit", Name="edit-departament")]
        public IActionResult Edit(int id)
        {
            Departament departament = _departamentRepository.GetById(id);
            
            if(departament == null)
            {
                return NotFound();
            }

            var model = new DepartamentEditResponseViewModel
            {
                Id = id,
                Name = departament.Name
            };


            return View(model);
        }



        [HttpPost("edit", Name = "edit-departament")]
        public IActionResult SubmitEditDepartament(DepartamentEditRequestViewModel model)
        {
            Departament departament = _departamentRepository.GetById(model.Id);

            if (departament == null)
            {
                return NotFound();
            }
            
            departament.Name = model.Name;

            try
            {
                _departamentRepository.UpdateDepartament(departament);
            }
            catch (PostgresException e)
            {
                _logger.LogError(e, "Postgresql Exception");

                throw e;
            }

            return RedirectToAction("Index");
        }


        #endregion

        #region Delete

        [HttpGet("delete", Name ="delete-departament")]
        public IActionResult Delete(int id)
        {
            Departament departament = _departamentRepository.GetById(id);

            if(departament == null)
            {
                return NotFound();
            }

            _departamentRepository.DeleteDepartament(id);

            return RedirectToAction("Index");
        }
        #endregion
    }

}

