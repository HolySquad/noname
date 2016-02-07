using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Domain.Audio;
using Factories;
using PagedList;
using Repository.Interfaces;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class SongController : Controller
    {
        private readonly IMediaFileRepository _mediaFileRepository;

        public SongController(IMediaFileRepository mediaFileRepository)
        {
            _mediaFileRepository = mediaFileRepository;
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {

            var songsList = _mediaFileRepository.GetAllFiles() ?? new List<Song>();
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(songsList.ToPagedList(pageNumber, pageSize));
        }

        [ChildActionOnly]
        public PartialViewResult SongsCount()
        {
            var songsListCount = _mediaFileRepository.GetFileCount();
            return PartialView(songsListCount);
        }

        [HttpGet]
        public PartialViewResult AddFilePartial()
        {
            return PartialView();
        }

        public JsonResult AddFile()
        {

            var files = new List<string>();
            foreach (string file in Request.Files)
            {
                var hpf = Request.Files[file];
                if (hpf.ContentLength == 0)
                    continue;

                var path =
                    Path.Combine(Server.MapPath("~/Content/Music/"),
                        hpf.FileName);
                files.Add(path);

                hpf.SaveAs(Path.GetFullPath(path));
            }
            if (!files.Any()) return Json("No Files");

            var songs = SongFactory.MultiCreateSong(files);
            UpdateDb(songs);
            return Json(songs.Select(x => x.Name).First() + " uploaded");


        }

        [HttpGet]
        public PartialViewResult DeletePartial(int id)
        {
            var song = _mediaFileRepository.GetEntityById<Song>(id);
            return PartialView(song);
        }

        public PartialViewResult Delete()
        {
            return PartialView();
        }

   
        public PartialViewResult SearchSong(string query)
        {

            var resultSongs = _mediaFileRepository.SearchItemByString(query);

            if (resultSongs == null) return PartialView(new List<Song>());

            var distinctSongs = resultSongs.Distinct().ToList();
            return PartialView(distinctSongs);
        }

    private void UpdateDb(IList<Song> songs)
        {
            foreach (var song in songs)
            {
                _mediaFileRepository.Save(song);
            }
        }
    }
}