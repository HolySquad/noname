using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Audio;
using Factories;
using PagedList;
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
        public ActionResult Index(int? page)
        {
            var songsList = _mediaFileRepository.GetAllFiles() ?? new List<Song>();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(songsList.ToPagedList(pageNumber, pageSize));
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
            ViewBag.Message = "Add file";
            return PartialView();
        }

        [HttpPost]
        public ActionResult AddFiles(List<HttpPostedFileBase> files)
        {
            try
            {

                if (Request.Files.Count > 0)
                {
                    foreach (string file in Request.Files)
                    {
                        HttpPostedFileBase hpf = Request.Files[file];
                        if (hpf.ContentLength == 0)
                            continue;
                        var fileName = Path.GetFileName(hpf.FileName);
                        if (fileName != null)
                        {
                            var path = Path.Combine(Server.MapPath("~/Content/Music/"), fileName);
                           
                          //  var path = "~/content/music/" + fileName;
                            hpf.SaveAs(Path.GetFullPath(path));
                            var item = SongFactory.CreateSong(path);
                            _mediaFileRepository.AddMediaFile(item);
                            return Content("{\"name\":\"" + fileName + "\"}", "application/json");
                        }
                    }
                }
                //ViewBag.Message = "Upload successful";

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
                // To Add deleting from Hdd of music file
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