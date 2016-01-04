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

        public MediaFileController(IMediaFileRepository mediaFileRepository)
        {
            _mediaFileRepository = mediaFileRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var songsList = _mediaFileRepository.GetAllFiles() ?? new List<Song>();
            return View(songsList);
        }

        // GET: MediaFile/Details/5
        [HttpGet]
        public PartialViewResult Details(long id)
        {
            var file = _mediaFileRepository.GetEntityById<MediaFile>(id);
            return PartialView(file);
        }

        // GET: MediaFile/Create
        [HttpGet]
        public PartialViewResult AddFiles()
        {
            return PartialView();
        }

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
                        var path = Path.Combine(Server.MapPath("~/AppData/Music/"), fileName);
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

        [HttpGet]
        public PartialViewResult Delete(int id)
        {
            var file = _mediaFileRepository.GetEntityById<MediaFile>(id);
            return PartialView(file);
        }

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
        [HttpGet]
        public ActionResult AddToPlaylist(long id)
        {
            //PlaylistController c = new PlaylistController(_playlistRepository);
            //var playlist = c.Index();
            return RedirectToAction("AddToPlaylist", "Playlist", new { id });
            //return View();
        }
    }
}