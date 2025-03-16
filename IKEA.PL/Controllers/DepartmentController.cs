using IKEA.BLL.Services;
using IKEA.DAL.Models.Departments;
using IKEA.PL.Models.Department;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IWebHostEnvironment _environment;
        public ILogger _Logger { get; }

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _Logger = logger;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartmentsToReturn();
            return View(departments);
        }

        #region details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(new DepartmentEditViewMode()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
            });
        }

        [HttpPost]
        public IActionResult Edit(DepartmentEditViewMode departmentVM)
        {
            if (ModelState.IsValid)
            {
                return View(departmentVM);
            }
            var Message = string.Empty;
            try
            {
                var updatedDepartment = new UpdatedDepartmentDTO()
                {
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate,
                };
                var updated = _departmentService.UpdateDepartment(updatedDepartment) > 0;
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
                Message = "sorry, an error occurred while updating the department";
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, ex.Message);
                Message = _environment.IsDevelopment() ? ex.Message : "sorry, an error occurred while updating the department";
            }
            ModelState.AddModelError(string.Empty, Message);
            return View(departmentVM);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO department)
        {
            if (ModelState.IsValid)
            {
                var Message = string.Empty;
                try
                {
                    var result = _departmentService.CreateDepartment(department);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Message = "Sorry, the department has not been created";
                        ModelState.AddModelError(string.Empty, Message);
                        return View(department);
                    }
                }
                catch (Exception ex)
                {
                    _Logger.LogError(ex, ex.Message);
                    if (_environment.IsDevelopment())
                    {
                        Message = ex.Message;
                        return View(department);
                    }
                    else
                    {
                        Message = "Sorry, the department has not been created";
                        return View("Error", Message);
                    }
                }
            }
            return View(department);
        }
        #endregion

    }
}
