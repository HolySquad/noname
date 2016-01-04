using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Audio;
using Factories;
using Repository.Interfaces;
using Utils;

namespace WebLayer.Controllers
{
    public class MediaFileController : Controller
    {
        private readonly IMediaFileRepository _mediaFileRepository;

        // private List<MediaFile> files = new List<MediaFile>();


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
            // Scanner.FileScanner.ScanFolder("/Content/Music/");
            //foreach (var mediaFile in MediaFile.Files)
            //{
            //    _mediaFileRepository.AddMediaFile(mediaFile);
            //}

            var rez = _mediaFileRepository.GetAllFiles() ?? new List<Song>();
            return View(rez);
        }

        // GET: MediaFile/Details/5
        public ViewResult Details(long id)
        {
            return View();
        }

        // GET: MediaFile/Create
        public PartialViewResult AddFiles()
        {
            return PartialView();
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
                        var path = Path.Combine(Server.MapPath("~/Content/Music/"), fileName);
                        file.SaveAs(path);
                        var item = SongFactory.CreateSong(path);
                        _mediaFileRepository.AddMediaFile(item);
                    }
                }
                ViewBag.Message = "Upload successful";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                Logger.AddToLog(ex);
                return RedirectToAction("AddFiles");
            }
        }

        // GET: MediaFile/Edit/5
        public ActionResult Edit(long id)
        {
            return View();
        }

        // POST: MediaFile/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection)
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
        public ActionResult Delete(long id)
        {
            var file = _mediaFileRepository.GetEntityById<MediaFile>(id);
            return View(file);
        }

        // POST: MediaFile/Delete/5
        [HttpPost]
        public ActionResult Delete(long id, FormCollection collection)
        {
            try
            {
                _mediaFileRepository.DeleteMediaFile(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: MediaFile/Details/5
        public ActionResult AddToPlaylist(long id)
        {
            //PlaylistController c = new PlaylistController(_playlistRepository);
            //var playlist = c.Index();
            return RedirectToAction("AddToPlaylist", "Playlist", new { id });
            //return View();
        }
    }
}