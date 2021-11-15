using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using plog_project.Models;
namespace plog_project.Controllers
{
    public class admeenController : Controller
    {
        blogcontect db = new blogcontect();

        public ActionResult reegister()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult reegister(admeen a, HttpPostedFileBase img)
        {

            img.SaveAs(Server.MapPath("~/attach/" + img.FileName));

        
            a.photo = img.FileName;
            admeen s = db.admeens.Where(n => n.email == a.email).SingleOrDefault();
            if (s != null)
            {
                ViewBag.status = "email already exist!!";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.admeens.Add(a);
                db.SaveChanges();
                return RedirectToAction("login");

            }
            return View();
        }


        #region login
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(admeen a)
        {
            admeen s = db.admeens.Where(n => n.password == a.password && n.username == a.username).SingleOrDefault();
            if (s != null)
            {
                // login
                Session.Add("userid", s.id);
                return RedirectToAction("profile");
            }
            else
            {
                //البيانات مش موجودة 
                ViewBag.x = "username or password is incorrect!!";
                return View();
            }
         
        }
        #endregion

        #region profile
        public ActionResult profile()
        {
            if (Session["userid"] == null)
                return RedirectToAction("login");
            int Id = (int)Session["userid"];
            admeen s = db.admeens.Where(n => n.id == Id).SingleOrDefault();
            return View(s);
        }
        #endregion


        #region logout
        public ActionResult logout()
        {
            Session["userid"] = null;
            return RedirectToAction("login");
        }
        #endregion

       



    }
}
///*
 
//        #region register
//        public ActionResult register()
//        {
//            return View();
            
//             @model admeen

//@{
//    ViewBag.Title = "register";
//}

//<div style="background-color:black;text-align:center;width:600px;height:600px;margin:0 300px;">
//    <h2 style="text-align:center;font-size:40px;color:lightseagreen;font-weight:bolder">SIGN UP</h2>
//    <form method="post" enctype="multipart/form-data" novalidate="novalidate">
//        @Html.HiddenFor(n => n.password)
//        <table style="margin-left:135px ;font-weight:900;color:aliceblue">

//            <tr>

//                <td>id @Html.TextBoxFor(n => n.id, new { @class = "form-control" })</td>
 
//                <td>@Html.ValidationMessageFor(n => n.id)</td>
//            </tr>
//            <tr>

//                <td>username @Html.TextBoxFor(n => n.username, new { @class = "form-control" })</td>
//                <td>@Html.ValidationMessageFor(n => n.username)</td>
//            </tr>
//            <tr>

//                <td>email @Html.TextBoxFor(n => n.email, new { @class = "form-control" })</td>
//                <td>@Html.ValidationMessageFor(n => n.email)</td>
//            </tr>
//            <tr>

//                <td>age @Html.TextBoxFor(n => n.age, new { @class = "form-control" })</td>
//                <td>@Html.ValidationMessageFor(n => n.age)</td>
//            </tr>
//            <tr>

//                <td>address @Html.TextBoxFor(n => n.address, new { @class = "form-control" })</td>
//                <td>@Html.ValidationMessageFor(n => n.address)</td>
//            </tr>
//            <tr>

//                <td>password:@Html.PasswordFor(n => n.password)</td>
//                <td>@Html.ValidationMessageFor(n => n.password)</td>
//            </tr>

//            <tr>

//                <td>photo <input type="file" name="img" /></td>
//                <td>@ViewBag.status </td>
//            </tr>

//        </table>
//        <br />
//        <br />
//        <input type="submit" name="register" class="btn-primary" style="margin-left:-30px" />



//       @section scripts{

//            <script src="~/Scripts/jquery-3.3.1.js"></script>
//            <script src="~/Scripts/jquery.validate.js"></script>
//            <script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
//        }
//    </form>
//</div>


             

//        }
//        [HttpPost]
//public ActionResult register(admeen a, HttpPostedFileBase img)
//{

//    img.SaveAs(Server.MapPath("~/attach/" + img.FileName));

//    a.photo = img.FileName;
//    admeen s = db.admeens.Where(n => n.email == a.email).SingleOrDefault();
//    if (s != null)
//    {
//        ViewBag.status = "email already exist!!";
//        //return View();
//    }
//    if (ModelState.IsValid)
//    {
//        db.admeens.Add(a);
//        db.SaveChanges();
//        return RedirectToAction("login");

//    }
//    return RedirectToAction("register");
//}
//        #endregion
// * /