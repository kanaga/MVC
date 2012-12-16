using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Text.RegularExpressions;
using System.Reflection;
using CMSAdmin.Models;
using EFCFCMSDomain;
//using EFCFCMSDomain.MapEntities;
using EFCFCMSDomain.Repository;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.Extensions;

namespace CMSAdmin.Controllers
{
    public class BlockController : Controller
    {
        //
        // GET: /Block/
         private readonly IRepository<Block> _blockrepository;

         public BlockController(IRepository<Block> blockrepository)
        {
            _blockrepository = blockrepository;
        }

        public ActionResult Index()
        {
            var model = new BlockViewModel();
            model.Blocks = _blockrepository.All.Where(x => x.CompanyId == 1000 && x.DivisionId == 1000);
            return View(model);
        }

        //
        // GET: /Block/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Block/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Block/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Block/Edit/5
 
        public ActionResult Edit(int id)
        {
           
            Block editblock = _blockrepository.Get(id);
            var contentHtml = HttpUtility.HtmlDecode(editblock.BlockContent);
            ViewData["BlockContent"] = editblock.BlockContent;
            ViewData["value"] = HttpUtility.HtmlEncode(contentHtml);
            return View(_blockrepository.Get(id));
        }

        //
        // POST: /Block/Edit/5

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

        //
        // GET: /Block/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Block/Delete/5

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
    }
}
