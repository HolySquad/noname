using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Domain;
using Repository.Interfaces;
using Utils;

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
            //files.Add(new MediaFile("Test Item", "Test Path"));
            //foreach (var mediaFile in MediaFile.Files)
            //{
            //    files.Add(mediaFile);
            //}           

            // _mediaFileRepository.AddMediaFile(new MediaFile("testName", "testPath"));
            var rez = _mediaFileRepository.GetAllFiles();
            return View(rez);
        }

        // GET: MediaFile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MediaFile/Create
        public ViewResult AddFiles()
        {
            return View();
        }

        // POST: MediaFile/Create
        [HttpPost]
        public ViewResult AddFiles(FormCollection collection)
        {
            try
            {
                foreach (string upload in Request.Files)
                {
                    if (!Request.Files[upload].HasFile()) continue;
                    string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                }
                return View();
            }
            catch
            {
                return View();
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