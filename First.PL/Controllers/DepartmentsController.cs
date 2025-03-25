using First.BLL.DataTransferObjects;
using First.BLL.Services;
using First.PL.ViewModels.DepartmentsViewModel;
using Microsoft.AspNetCore.Mvc;

namespace First.PL.Controllers
{
    public class DepartmentsController(IDepartmentServices _departmentServices,
        ILogger<DepartmentsController> _logger,
        IWebHostEnvironment _environment) : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentServices.GatAllDepartments();
            return View(department);
        }

        [HttpGet]
        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create(CreatedDebartmentDTO departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int Result = _departmentServices.AddDepartment(departmentDto);
                    if (Result > 0) return
                            RedirectToAction(nameof(Index), _departmentServices.GatAllDepartments());

                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can t Be Created ");
                    }

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentDto);

        }



        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentServices.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation = department.CreateOn

            };

            return View(departmentViewModel);

        }


        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDTO()
                    {
                        Id = id,
                        Code = ViewModel.Code,
                        Name = ViewModel.Name,
                        Description = ViewModel.Description,
                        DateOfCreation = ViewModel.DateOfCreation
                    };
                    int Result = _departmentServices.UpdateDempartment(UpdatedDepartment);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department not updated");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErorrView", ex);
                    }
                }
            }
            return View(ViewModel);
        }

        //[HttpGet]
        //public IActionResult Delete(int? id )
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentServices.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound();
        //    return View(department);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Delete =_departmentServices.DeleteDepartment(id);
                if (Delete) 
                { 
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Is Not Delete");
                    return RedirectToAction(nameof(Delete),new {id}); 
                }


            }
            catch (Exception ex) 
            {
                if (!_environment.IsDevelopment())
                { 
                     ModelState.AddModelError(string.Empty,ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView" ,ex);

                }

            }
        }
    }
}
