using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buddhism.Domain.Security;
using Buddhism.EntityFramework;
using Buddhism.EntityFramework.Infrastructure;
using Buddhism.Service.IServices.Security;
using Buddhism.Service.Services.Security;

namespace Buddhism.Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfwork;
        public HomeController(IUserService userService,IUnitOfWork unitOfwork)
        {
            _userService = userService;
            _unitOfwork = unitOfwork;
        }
        public ActionResult Index()
        {
            var query = _userService.QueryAll();
            return View(query);
        }
        public ActionResult Create(int id=0)
        {
            var user = id == 0 ? new User() : _userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            return Json(new { message="保存成功！",success=true});
        }
        public ActionResult Delete()
        {
            return Json(true);
        }
    }
}
