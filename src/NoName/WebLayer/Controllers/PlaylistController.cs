using System;
using System.Web.Mvc;
using Repository.Interfaces;

namespace WebLayer.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IPlaylistRepository _playlistRepository;

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
            return View(rez);
        }
    }
}