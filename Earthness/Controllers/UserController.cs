using System.Web.Mvc;
using BusinessLayerEarthness.Facade;
using BusinessLayerEarthness.Implementation;

using DAL.Models;


namespace Earthness.Controllers
{
    public class UserController : Controller
    {
        private IUserManager manager = new UserManager(new masterEntities());
        
        public ActionResult StartUser()
        {
            User user = new User();
        
            return View(@"~\Views\StartUser.cshtml",user);
        }

        public ActionResult Homepage()
        {
            // User m = (User)Session["user"];
            User u = manager.GetUserByID(2010);
           // User u = manager.GetUserByID(m.UserId);
           // manager.Save();
            return View("Homepage",u);
        }

        //action to increment points 
        public ActionResult IncrementPoints()
        {
           // User m = (User)Session["user"];
            User u = manager.GetUserByID(2010);

            u.UserPoints++;
            manager.UpdateUser(u);
            manager.Save();
            return View("Create");
        }
        
        // GET: User

        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="UserName,UserPhoneNumber,UserMail,Password")]  User user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    user.UserPoints = 0;
                    manager.InsertUser(user);
                    manager.Save();
                   
                }
               
                return RedirectToAction("StartUser");
            }
            catch
            {
                return RedirectToAction("StartUser");
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                User user = manager.checkLogIn(model.UserMail, model.Password);
                if (user != null)
                {
                    Session.Add("user",user);
                    return RedirectToAction("Homepage");
                }
                ViewBag.logerror = "Please verify your e-mail or password !";
            }

           
            return View(@"~\Views\StartUser.cshtml");
            
        }
 




    }
}
