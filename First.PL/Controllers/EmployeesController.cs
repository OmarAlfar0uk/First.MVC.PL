using First.BLL.DataTransferObjects.DepartmentDataTransferObject;
using First.BLL.DataTransferObjects.EmployeeDataTransferObject;
using First.BLL.Services.DepartmentServices;
using First.BLL.Services.EmployeeServices;
using First.DAL.Models.EmployeeModels;
using First.DAL.Models.Shared.Enums;
using First.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First.PL.Controllers
{
    public class EmployeesController(IEmployeeServices _employeeServices,
        IWebHostEnvironment _environment,
        ILogger<EmployeesController> _logger ) : Controller

    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            var Employee = _employeeServices.GetAllEmployees(EmployeeSearchName);
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var employeeDto = new CreatedEmployeeDto()
                    {
                        Name = employeeViewModel.Name,
                        Salary = employeeViewModel.Salary,
                        IsActive = employeeViewModel.IsActive,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Email = employeeViewModel.Email,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,    
                        Gender = employeeViewModel.Gender,
                        HiringDate = employeeViewModel.HiringDate,
                        PhoneNumber = employeeViewModel.PhoneNumber ,
                        DepartmentId = employeeViewModel.DepartmentId,
                        Img = employeeViewModel.Img


                    };
                    int Result = _employeeServices.AddEmployee(employeeDto);
                    if (Result > 0)
                        return RedirectToAction(nameof(Index));
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't Be Created");

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
            return View(employeeViewModel);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            return employee is null ? NotFound() : View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id )
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeServices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            var employeeViewModel = new EmployeeViewModel()
            {

                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender),
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId

            };
            return View(employeeViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeViewModel)
        {
            if (!id.HasValue ) return BadRequest();
            if (!ModelState.IsValid) return View(employeeViewModel);
            try
            {
                var employeeDto = new UpdatedEmployeeDto()
                {
                    Id = id.Value,  
                    PhoneNumber= employeeViewModel.PhoneNumber,
                    HiringDate= employeeViewModel.HiringDate,
                    Gender = employeeViewModel.Gender,
                    Address = employeeViewModel.Address,
                    Age = employeeViewModel.Age,    
                    Email = employeeViewModel.Email,    
                    EmployeeType = employeeViewModel.EmployeeType,
                    IsActive= employeeViewModel.IsActive,
                    Name = employeeViewModel.Name,  
                    Salary = employeeViewModel.Salary,
                    DepartmentId = employeeViewModel.DepartmentId,
                    

                };
                var Result =_employeeServices.UpdateEmployee(employeeDto);
                if (Result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee is not updated");
                    return View(employeeViewModel);   
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    // 1. Development => Log Error In Console and Return  Same View With Error Message

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeViewModel);
                }
                else
                {
                    //2. Deployment => Log Error In File | Table in Database And Return Error View

                    _logger.LogError(ex.Message);
                    return View("ErorrView" , ex);
                }
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool Deleted = _employeeServices.DeleteEmployee(id);
                if (Deleted)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee IS Not Deleted");
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
    }
}
