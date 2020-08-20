using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace GradutionProject
{
    public class Helper
    {

        public static string RenderRazorViewToString(Controller controller, string viewName, object model = null, GradutionProject.Data.ApplicationDbContext _context =null)
        {
            controller.ViewData.Model = model;
            if(viewName== "ViewAllRegion")
            {
                controller.ViewBag.page= _context.Regions.Include(r => r.City).Include(a => a.Image).ToPagedList(1, 2);
            }
            else if (viewName == "ViewAllCategory")
            {
                controller.ViewBag.page = _context.Categories.ToPagedList(1, 2);
            }
            else if (viewName == "ViewAllCities")
            {
                controller.ViewBag.page = _context.Cities.ToPagedList(1, 2);
            }

            using (var sw = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    sw,
                    new HtmlHelperOptions()
                );
                viewResult.View.RenderAsync(viewContext);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
