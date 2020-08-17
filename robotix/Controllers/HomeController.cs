using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using robotix.Model;
using robotix.Model.Repository;

namespace robotix.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<admin> _repository { get; }
        public IUnitOfWork _unitofwork { get; }
        public HomeController(IRepository<admin> repository, IUnitOfWork unitofwork)
        {
            _repository = repository;
            _unitofwork = unitofwork;
        }
        public IActionResult Index()
        {
            IEnumerable<admin> admininfo = _repository.Gets();
            return View(admininfo);
        }
    }
}
