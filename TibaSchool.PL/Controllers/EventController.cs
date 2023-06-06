using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TibaSchool.BL.Helper;
using TibaSchool.BL.Interface;
using TibaSchool.BL.Repository;
using TibaSchool.BL.VModels;
using TibaSchool.DAL.Entity;

namespace TibaSchool.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        #region Prop
        private readonly IEvent rep;
        private readonly IMapper mapper;

        #endregion

        #region Ctor
        public EventController(IEvent rep, IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        #endregion

        #region Actions

        #region GetData
        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await rep.GetByIdAsync(x => x.Id == id);
            var result = mapper.Map<EventVM>(data);

            return View(result);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventVM model)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    model.ImageName = FileUploader.UploadFile("UploadedImages", model.Image);

                    var data = mapper.Map<Event>(model);
                    await rep.CreateAsync(data);
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View(model);
        }
        #endregion

        #region Update

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await rep.GetByIdAsync(x => x.Id == id);
            var result = mapper.Map<EventVM>(data);

            return View(result);
        }

        public async Task<IActionResult> UpdateAsync(EventVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //FileUploader.RemoveFile("UploadedImages", model.ImageName);
                    if (!string.IsNullOrEmpty(model?.Image?.FileName))
                    {
                        model.ImageName = FileUploader.UploadFile("UploadedImages", model.Image);                     
                    }
                    var data = mapper.Map<Event>(model);
                    await rep.UpdateAsync(data);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View(model);
        }

        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            var data = await rep.GetByIdAsync(x => x.Id == id);
            var result = mapper.Map<EventVM>(data);
            return View(result);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(EventVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    /*//RemoveFile.
                    FileUploader.RemoveFile("UploadedImages", obj.ImageName);*/
                    var data = mapper.Map<Event>(obj);
                    await rep.DeleteAsync(data);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View();
        }

        #endregion


        #endregion
    }
}
