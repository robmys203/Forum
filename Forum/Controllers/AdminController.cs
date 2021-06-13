using Forum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    [Authorize(Roles="Administrator")]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> roleMannager;
        private UserManager<IdentityUser> UserManager;
        public AdminController(RoleManager<IdentityRole> roleMannager, UserManager<IdentityUser> UserManager)
        {
            this.UserManager = UserManager;
            this.roleMannager = roleMannager;
        }
        // GET: AdminController
        public ActionResult Index()
        {

            return View(UserManager.Users);
        }

        // GET: AdminController/Details/5
        public ActionResult Detail(string id)
        {
            if (id != null && UserManager.Users.FirstOrDefault(s => s.Id == id)!= null )
            {
                var user = UserManager.Users.FirstOrDefault(s => s.Id == id);
                return View(user);
            }

            return RedirectToAction("Index");

        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id != null && UserManager.Users.FirstOrDefault(s => s.Id == id) != null)
            {
                var user = UserManager.Users.FirstOrDefault(s => s.Id == id);
                return View(user);
            }
            return RedirectToAction("Index");
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Edit( IdentityUser newuser)
        {

            var user = UserManager.Users.FirstOrDefault(s => s.Id == newuser.Id);
            user.PhoneNumber = newuser.PhoneNumber;
            user.Email = newuser.Email;
            user.UserName = newuser.UserName;
            await UserManager.UpdateAsync(user);

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> addRole(string id)
        {
            if (id != null && UserManager.Users.FirstOrDefault(s => s.Id == id) != null)
            {
                var user = UserManager.Users.FirstOrDefault(s => s.Id == id);
                userRoleModel model = new userRoleModel();
                var roles = await UserManager.GetRolesAsync(user);

                model.userId = user.Id;
                model.userName = user.UserName;
                model.userRoles = roles.ToList();
                return View(model);
            }
            return RedirectToAction("index");
        }


       [HttpPost]
        public async Task<ActionResult> addRole(userRoleModel model)
        {
          if( model != null && model.userRoleToAdd !=null)
            {    
              var user =  UserManager.Users.FirstOrDefault(s => s.Id == model.userId);
              await   UserManager.AddToRoleAsync(user, model.userRoleToAdd);
              return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        
        // POST: AdminController/Delete/5

        public async Task<ActionResult> Delete(string id)
        {
            if (id != null && UserManager.Users.FirstOrDefault(s => s.Id == id) != null)
            {
                var user = UserManager.Users.FirstOrDefault(s => s.Id == id);
                await UserManager.DeleteAsync(user);
                return View("Index", UserManager.Users);
            }
            return RedirectToAction("index");


        }

        public async Task<ActionResult> removeRoleFromUser(string id)
        {
            if (id != null && UserManager.Users.FirstOrDefault(s => s.Id == id) != null)
            {

                var user = UserManager.Users.FirstOrDefault(s => s.Id == id);
                userRoleModel model = new userRoleModel();
                var roles = await UserManager.GetRolesAsync(user);

                model.userId = user.Id;
                model.userName = user.UserName;
                var roleurzytkownika= await UserManager.GetRolesAsync(user);
                model.userRoles = roleurzytkownika.ToList();
                return View(model);
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        public async Task<ActionResult> removeRoleFromUser(userRoleModel model)
        {
            if(model != null && model.userRoleToDelete != null) { 
                var user = UserManager.Users.FirstOrDefault(s => s.Id == model.userId);
               await UserManager.RemoveFromRoleAsync(user, model.userRoleToDelete);
            return View("Index", UserManager.Users);
            }

            return RedirectToAction("index");

        }
        
        
    }
}
