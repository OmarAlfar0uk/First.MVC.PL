using First.BLL.DataTransferObjects.DepartmentDataTransferObject;
using First.BLL.Services.DepartmentServices;
using First.PL.ViewModels.DepartmentViewModel;
using Microsoft.AspNetCore.Mvc;

namespace First.PL.Controllers
{
    public class DepartmentsController(IDepartmentServices _departmentService, ILogger<DepartmentsController> _logger, IWebHostEnvironment _environment) : Controller
    {
        //BaseUrl/Departments/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GatAllDepartments();
            return View(departments);
        }
        #region Create Department
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(CreatedDebartmentDTO departmentDto)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    int Result = _departmentService.AddDepartment(departmentDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't Be Created");

                    }
                }
                catch (Exception ex)
                {
                    // Log Exception
                    if (_environment.IsDevelopment())
                    {
                        // 1. Development => Log Error In Console and Return  Same View With Error Message

                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        //2. Deployment => Log Error In File | Table in Database And Return Error View

                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(departmentDto);
        }

        #endregion
        #region Details Of Department
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();// 404
            return View(department);
        }
        #endregion
        #region Edit Of Department
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest(); // 400
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null) return NotFound();// 404
            var departmentViewModel = new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreatedOn = department.CreateOn
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id, DepartmentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDTO()
                    {
                        Id = id,
                        Code = viewModel.Code,
                        Name = viewModel.Name,
                        Description = viewModel.Description,
                        DateOfCreation = viewModel.CreatedOn
                    };
                    int Result = _departmentService.UpdateDempartment(UpdatedDepartment);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Department is not Updated");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(viewModel);
        }
        #endregion
        #region Delete Department
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentService.GetDepartmentById(id.Value);
        //    if (department is null) return NotFound();
        //    return View(department);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = _departmentService.DeleteDepartment(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department IS Not Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                // Log Exception
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error In Console and Return  Same View With Error Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    //2. Deployment => Log Error In File | Table in Database And Return Error View

                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }
        #endregion
    }
}
