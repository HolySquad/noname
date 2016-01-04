using System;
using System.Web.Mvc;
using Repository.Interfaces;
using WebLayer.Models;
using System.Net;
using Factories;
using System.Collections.Generic;

namespace WebLayer.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistRepository _playlistRepository;
        //private readonly PlaylistFactory PlaylistFactory;

        [Obsolete]
        public PlaylistController()
        {
        }

        public PlaylistController(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        // GET: Playlist
        [HttpGet]
        public ViewResult Index()
        {
            var rez = _playlistRepository.GetAllPlaylists();
            var modellist = new List<PlaylistModel>();
            foreach(var item in rez)
            {
                var model = new PlaylistModel();
                model.PlaylistToModel(item);
                modellist.Add(model);
            }
            return View(modellist);
        }

        // Get: CreatePlaylist
        [HttpGet]
        public ViewResult Create()
        {     
            return View();
        }

        [HttpPost]
        public ActionResult Create(PlaylistModel model)
        {
            if (ModelState.IsValid)
            {
                var playlist = PlaylistFactory.CreatePlaylist(model.PlaylistName, model.Comments);
                _playlistRepository.AddPlaylist(playlist);

                return Redirect("Index");
            }
            Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            return PartialView(model);
        }

        // GET: MediaFile/Details/5
        public ActionResult AddToPlaylist(long id)
        {
            var rez = _playlistRepository.GetAllPlaylists();
            var modellist = new List<PlaylistModel>();
            foreach (var item in rez)
            {
                var model = new PlaylistModel();
                model.PlaylistToModel(item);
                modellist.Add(model);
            }
            return View(modellist);
        }

       // [HttpPost]
        public ActionResult AddingSong(long id)
        {

            return View("AddToPlaylist");
        }
    }
}