using DisplayCurrentUserItemsDemo.Data;
using DisplayCurrentUserItemsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisplayCurrentUserItemsDemo.ViewModels.UserCategories
{
    public class CreateUserCategoryListViewModel
    {
        //Display a list of all categories which can be selected from (probably a checkbox list)
        public List<Category> Categories { get; set; }

        //Selected category ids are returned to this list
        public List<int> SelectedCategoryIds { get; set; }

        internal void Persist(string currentUserId, ApplicationDbContext context)
        {
            foreach(int categoryId in SelectedCategoryIds)
            {
                var newUserCategory = new UserCategory { UserId = currentUserId, CategoryId = categoryId };
                context.Add(newUserCategory);
            }
            context.SaveChanges();
        }
    }
}
