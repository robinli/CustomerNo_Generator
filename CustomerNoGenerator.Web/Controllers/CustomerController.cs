using GroupageCore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerNoGenerator.Web.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Import(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                if (Path.GetExtension(file.FileName) != ".xlsx")
                {
                    ViewBag.Message = "You have to choose Excel file (*.xlsx)";
                }
                else
                {
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Data"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        GroupageCore.CustomerBLL bll = new GroupageCore.CustomerBLL();
                        bll.ImportThenSave(path);

                        ViewBag.Message = "File uploaded successfully";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        // GET: Customer
        public ActionResult Index()
        {
            GroupageCore.CustomerBLL bll = new GroupageCore.CustomerBLL();
            return View(bll.DB.Items.OrderBy(r=>r.New_Code));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerInfo data)
        {
            GroupageCore.CustomerBLL bll = new GroupageCore.CustomerBLL();
            CustomerInfo added = bll.NewCustomer(data.Customer_Code, data.Customer_Name);
            return RedirectToAction("Detail", new { id = added.New_Code });
        }

        public ActionResult Detail(string id)
        {
            GroupageCore.CustomerBLL bll = new GroupageCore.CustomerBLL();
            CustomerInfo item = bll.DB.Items.FirstOrDefault(r => r.New_Code == id);
            return View(item);
        }



    }
}