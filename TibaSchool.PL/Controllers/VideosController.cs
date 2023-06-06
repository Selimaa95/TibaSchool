using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TibaSchool.BL.Helper;
using TibaSchool.BL.Interface;
using TibaSchool.BL.VModels;
using TibaSchool.DAL.DataBase;
using TibaSchool.DAL.Entity;

namespace TibaSchool.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VideosController : Controller
    {
        #region Prop
        private readonly IMapper mapper;
        private readonly IVideoFolder folder;
        private readonly IVideo video;

        #endregion

        #region Ctor
        public VideosController(IMapper mapper, IVideoFolder folder, IVideo video)
        {
            this.mapper = mapper;
            this.folder = folder;
            this.video = video;
        }
        #endregion

        #region Actions

        #region Add Folder && Video
       
        [HttpGet]
        public IActionResult Create()
        {
            if (TempData.ContainsKey("Success"))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFolder(VideoFolderVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ImageName = FileUploader.UploadFile("ImagesVideo", model.Image);
                    var data = mapper.Map<VideoFolder>(model);
                    await folder.CreateAsync(data);
                    TempData["Success"] = "Data Saved Successfully!";
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return RedirectToAction("Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(VideoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ImageName = FileUploader.UploadFile("ImagesVideo", model.Image);
                    var data = mapper.Map<Video>(model);
                    await video.CreateAsync(data);
                    TempData["Success"] = "Data Saved Successfully!";
                }

            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return RedirectToAction("Create");
        }
        #endregion

        #region Edit && Delete

        [HttpGet]
        public IActionResult EditDelete(int Id)
        {
            if (TempData.ContainsKey("Success"))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> EditOrDeleteFolder(string submit, VideoFolderVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    switch (submit)
                    {
                        case "Edit":

                            var fold = await folder.GetByIdAsync(model.Id);

                            if (!string.IsNullOrEmpty(model?.Image?.FileName))
                            {
                                fold.ImageName = FileUploader.UploadFile("ImagesVideos", model.Image);
                            }

                            if (!string.IsNullOrEmpty(model?.Name))
                            {
                                fold.Name = model.Name;
                            }
                            
                            await folder.UpdateAsync(fold);
                            TempData["Success"] = "Data Saved Successfully!";
                            return RedirectToAction("EditDelete");
                            break;

                        case "Delete":
                            
                            await folder.DeleteAsync(model.Id);
                            TempData["Success"] = "Data Saved Successfully!";
                            return RedirectToAction("EditDelete");
                            break;

                        default:
                            return RedirectToAction("EditDelete");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> EditOrDeleteVideos(List<VideoVM> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var data = mapper.Map<Video>(model);
                    await video.DeleteAsync(data); 
                    TempData["Success"] = "Data Saved Successfully!";
                    return RedirectToAction("EditDelete");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetVideos(int FolderId)
        {
            try
            {
                var data = await video.GetAllAsync(x => x.FolderId == FolderId);
                var result = mapper.Map<IEnumerable<VideoVM>>(data);
                TempData["Success"] = "Data Saved Successfully!";
                return PartialView("_videoToDelete", result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPost]
        public async Task<JsonResult> EditRowVideo(int VideoId, string Name, string Path)
        {
            var data = await video.GetByIdAsync(x=>x.Id == VideoId);
            data.Name = Name;
            data.Path = Path;
            await video.UpdateAsync(data);
            TempData["Success"] = "Data Saved Successfully!";
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteVideos(IFormCollection formCollection)
        {
            try
            {
                string[] ids = formCollection["VideoId"].ToString().Split(new char[] { ',' }).Distinct().ToArray();
                foreach (string id in ids)
                {
                    var obj = await video.GetByIdAsync(x => x.Id == int.Parse(id));
                    await video.DeleteAsync(obj);
                    TempData["Success"] = "Data Saved Successfully!";
                    return RedirectToAction("EditDelete");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
           return View("EditDelete");

        }

        #endregion

        #endregion
    }
}