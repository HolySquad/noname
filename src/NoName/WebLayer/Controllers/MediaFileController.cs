using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Domain;
using Repository.Interfaces;

namespace WebLayer.Controllers
{
    public class MediaFileController : Controller
    {
        private readonly IMediaFileRepository _mediaFileRepository;
        private List<MediaFile> files = new List<MediaFile>();


        [Obsolete]
        public MediaFileController()
        {
        }

        public MediaFileController(IMediaFileRepository mediaFileRepository)
        {
            _mediaFileRepository = mediaFileRepository;
        }

        // GET: MediaFile
        [HttpGet]
        public ViewResult Index()
        {
            var rez = _mediaFileRepository.GetAllFiles();
            return View(rez);
        }

        // GET: MediaFile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MediaFile/Create
        public ActionResult AddFiles()
        {
            return View();
        }

        // POST: MediaFile/Create
        [HttpPost]
        public ActionResult AddFiles(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileName != null)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/Music"), fileName);
                        file.SaveAs(path);
                        var item = new MediaFile(fileName, path);
                        _mediaFileRepository.AddMediaFile(item);
                    }
                }
                ViewBag.Message = "Upload successful";

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("AddFiles");
            }
        }

        // GET: MediaFile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MediaFile/Edit/5
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

        // GET: MediaFile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MediaFile/Delete/5
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