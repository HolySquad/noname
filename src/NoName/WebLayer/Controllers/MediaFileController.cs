using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Microsoft.Ajax.Utilities;
using Repository.Interfaces;

namespace WebLayer.Controllers
{
    public class MediaFileController : Controller
    {
        private readonly IMediaFileRepository _mediaFileRepository;
        private  List<MediaFile> files = new List<MediaFile>();


        [Obsolete]
        public MediaFileController()
        {

        }

        public MediaFileController(IMediaFileRepository mediaFileRepository)
        {
            _mediaFileRepository = mediaFileRepository;
        }
    
        // GET: MediaFile
        public ActionResult Index()
        {
            //files.Add(new MediaFile("Test Item", "Test Path"));
            //foreach (var mediaFile in MediaFile.Files)
            //{
            //    files.Add(mediaFile);
            //}           

            _mediaFileRepository.AddMediaFile(new MediaFile("testName", "testPath"));

            return View();
        }

        // GET: MediaFile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MediaFile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaFile/Create
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
