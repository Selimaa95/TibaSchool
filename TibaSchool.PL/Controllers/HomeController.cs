using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TibaSchool.BL.Interface;
using TibaSchool.BL.VModels;
using TibaSchool.DAL.Entity;

namespace TibaSchool.PL.Controllers
{
    public class HomeController : Controller
    {

        #region Prop

        private readonly IMapper mapper;
        private readonly IVideo video;
        private readonly IAlbum album;
        private readonly IImages images;
        #endregion

        #region Ctor

        public HomeController(IMapper mapper, IVideo video, IAlbum album, IImages images)
        {
            this.mapper = mapper;
            this.video = video;
            this.album = album;
            this.images = images;
        }
        #endregion

        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult OurSchool() 
        {
            return View();
        }  
        
        public IActionResult Subjects() 
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Appeals()
        {
            return View();
        }

        public IActionResult Admission()
        {
            return View();
        }

        public IActionResult GetVideoFolders()
        {
            return View("VideoFolders");
        }

        public IActionResult GetImageFolders()
        {
            return View("ImageFolders");
        }

        public async Task<IActionResult> GetFolderAlbums(int id)
        {
            var Data = await album.GetAllAsync(x => x.FolderId == id);
            var Result = mapper.Map<IEnumerable<AlbumVM>>(Data);
            return View("FolderAlbums", Result);
        }

        public async Task<IActionResult> GetImages(int id)
        {
            var Data = await images.GetAllAsync(x => x.AlbumId == id);
            var Result = mapper.Map<IEnumerable<ImagesVM>>(Data);
            return View("Images", Result);
        }

        public async Task<IActionResult> GetVideos(int id)
        {
            var Data = await video.GetAllAsync(x => x.FolderId == id);
            var Result = mapper.Map<IEnumerable<VideoVM>>(Data);
            return View("Videos", Result);
        }

        #endregion

    }
}