using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayCurrentUserItemsDemo.Data;
using DisplayCurrentUserItemsDemo.Models;
using DisplayCurrentUserItemsDemo.ViewModels.UserCategories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DisplayCurrentUserItemsDemo.Controllers
{
    public class UserCategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public UserCategoryController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        // GET: UserCategory
        public ActionResult Index()
        {
            string currentUserId = userManager.GetUserId(User);
            List<Category> categoryList = context.UserCategories
                                                .Where(uc => uc.UserId == currentUserId)
                                                .Select(uc => context.Categories.Find(uc.CategoryId))
                                                .ToList();
            return View(categoryList);
        }

        // GET: UserCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUserCategoryListViewModel model)
        {
            string currentUserId = userManager.GetUserId(User);
            model.Persist(currentUserId, context);
            return RedirectToAction(nameof(Index));
        }
    }
}