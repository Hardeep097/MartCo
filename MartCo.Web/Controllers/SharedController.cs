﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartCo.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var file = Request.Files[0];

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);

                file.SaveAs(path);

                result.Data = new { Success = true, ImageURL = string.Format("/Content/images/{0}", fileName) };


                //var newImage = new Image() { Name = fileName };

                //if (ImagesService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}") };
                //}

            }
            catch (Exception ex)
            {

                result.Data = new { Success = false, Message =  ex.Message };
            }

            return result;
        }
    }
}