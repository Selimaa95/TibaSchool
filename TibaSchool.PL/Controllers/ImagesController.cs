using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TibaSchool.BL.Helper;
using TibaSchool.BL.Interface;
using TibaSchool.BL.VModels;
using TibaSchool.DAL.Entity;


namespace TibaSchool.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImagesController : Controller
    {
        #region Prop

        private readonly IMapper mapper;
        private readonly IFolder folder;
        private readonly IAlbum album;
        private readonly IImages images;
        #endregion

        #region Ctor
        public ImagesController(IMapper mapper, IFolder folder, IAlbum album, IImages images)
        {
            this.mapper = mapper;
            this.folder = folder;
            this.album = album;
            this.images = images;
        }
        #endregion

        #region Actions

        #region Add Images To Gallery

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
        public async Task<IActionResult> CreateFolder(FolderVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ImageName = FileUploader.UploadFile("ImagesGallery", model.Image);
                    var data = mapper.Map<Folder>(model);
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
        public async Task<IActionResult> CreateAlbum(AlbumVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.ImageName = FileUploader.UploadFile("ImagesGallery", model.Image);
                    var data = mapper.Map<Album>(model);
                    await album.CreateAsync(data);
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
        public async Task<IActionResult> CreateImages(ImagesVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var item in model.ImagesList)
                    {
                        model.Name = FileUploader.UploadFile("ImagesGallery", item);
                        var data = mapper.Map<Images>(model);
                        await images.CreateAsync(data);
                        TempData["Success"] = "Data Saved Successfully!";

                    }
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return RedirectToAction("Create");


        }

        #endregion

        #region Edit & Delete

        [HttpGet]
        public IActionResult EditDelete()
        {
            if (TempData.ContainsKey("Success"))
            {
                ViewBag.Success = TempData["Success"].ToString();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditOrDeleteFolder(string submit, FolderVM model)
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
                                fold.ImageName = FileUploader.UploadFile("ImagesGallery", model.Image);
                            }

                            if (!string.IsNullOrEmpty(model?.Name))
                            {
                                fold.Name = model.Name;
                            }
                            //var data = mapper.Map<Folder>(model);
                            await folder.UpdateAsync(fold);
                            TempData["Success"] = "Data Saved Successfully!";
                            return RedirectToAction("EditDelete");
                            break;

                        case "Delete":

                            //if (!string.IsNullOrEmpty(model?.Image?.FileName))
                            //{
                            //    model.ImageName = FileUploader.UploadFile("ImagesGallery", model.Image);
                            //}
                            //var data1 = mapper.Map<Folder>(model);

                            
                               /*TempData["Success"] = "Cant Delete Folder its Contains Albums!";
                                return RedirectToAction("EditDelete");
                                break;*/
                            
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
        public async Task<IActionResult> EditOrDeleteAlbum(string submit, AlbumVM model)
        {
            try
            {
                switch (submit)
                {
                    case "Edit":
                        var alb = await album.GetByIdAsync(model.Id);
                        if (!string.IsNullOrEmpty(model?.Image?.FileName))
                        {
                            alb.ImageName = FileUploader.UploadFile("ImagesGallery", model.Image);
                        }
                        if (!string.IsNullOrEmpty(model?.Name))
                        {
                            alb.Name = model.Name;
                        }
                        //var data = mapper.Map<Album>(model);
                        await album.UpdateAsync(alb);
                        TempData["Success"] = "Data Saved Successfully!";
                        return RedirectToAction("EditDelete");
                        break;

                    case "Delete":
                        //if (!string.IsNullOrEmpty(model?.Image?.FileName))
                        //{
                        //    model.ImageName = FileUploader.UploadFile("ImagesGallery", model.Image);
                        //}
                        //var data1 = mapper.Map<Album>(model);
                        await album.DeleteAsync(model.Id);
                        TempData["Success"] = "Data Saved Successfully!";
                        return RedirectToAction("EditDelete");
                        break;

                    default:
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
        public async Task<IActionResult> DeleteImages(IFormCollection formCollection)
        {
            try
            {
                string[] ids = formCollection["ImageId"].ToString().Split(new char[] { ',' }).Distinct().ToArray();
                foreach (string id in ids)
                {
                    await images.DeleteAsync(int.Parse(id));
                }
                TempData["Success"] = "Data Saved Successfully!";
                return RedirectToAction("EditDelete");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("EditDelete");
        }
        #endregion


        #endregion

        #region Ajax 

        [HttpPost]
        public async Task<IActionResult> GetAlbumByFolderId(int folderId)
        {
            var Data = await album.GetAllAsync(x => x.FolderId == folderId);
            var Result = mapper.Map<IEnumerable<AlbumVM>>(Data);
            return Json(Result);
        }

        [HttpPost]
        public async Task<IActionResult> GetImagesByAlbumId(int albumId)
        {
            var Data = await images.GetAllAsync(x => x.AlbumId == albumId);
            var Result = mapper.Map<IEnumerable<ImagesVM>>(Data);
            return Json(Result);
        }

        [HttpPost]
        public IActionResult GetFolderImage(int FolderId)
        {
            var data = folder.GetByIdAsync(FolderId);
            var result = mapper.Map<FolderVM>(data.Result);
            return PartialView("_imageFolder", result);
        }
        
        [HttpPost]
        public IActionResult GetAlbumImages(int AlbumId)
        {
            var data = images.GetAllAsync(x => x.AlbumId == AlbumId);
            var result = mapper.Map<IEnumerable<ImagesVM>>(data.Result);
            return PartialView("_imageToDelete", result);
        }

        [HttpPost]
        public ActionResult GetAlbumImage(int AlbumId)
        {
            var data = album.GetByIdAsync(AlbumId);
            var result = mapper.Map<AlbumVM>(data.Result);
            return PartialView("_imageAlbum", result);
        }
        #endregion

    }
}
