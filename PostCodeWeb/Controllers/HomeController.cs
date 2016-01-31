using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using PostCodeDataAccess.DataAccess;
using PostCodeDataAccess.Models;
using PostCodeWeb.ViewModels;
using System.Data;
using PostCodeDataAccess.Models.General;

namespace PostCodeWeb.Controllers
{
    public class HomeController : AsyncController
    {
        private readonly IDataReader<GeneralDetails> _dataReader;

        /// <summary>
        /// Dependecy injection will be used to initialize the controller. it is helpful for testing purposes
        /// </summary>
        public HomeController(IDataReader<GeneralDetails> dataReader)
        {
            _dataReader = dataReader;
        }
        /// <summary>
        /// This action show the main view only
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[OutputCache(Duration = 30, VaryByParam = "none", Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This action passes the filled in view model to view
        /// </summary>
        /// <returns></returns>
        [HttpPost]
       // [OutputCache(Duration = 2, VaryByParam = "none",  VaryByCustom = "browser")]
        public async Task<ActionResult> Index(PostCodeResultVm postCodeResultVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    GeneralDetails model = await _dataReader.GetDetailsAsync(postCodeResultVm.Postcode);
                    if (model != null)
                    {
                        var restaurantList =
                            Mapper.Map<Result, PostCodeResultVm>(model.result);

                        postCodeResultVm = restaurantList;
                    }
                }
                catch (Exception)
                {
                    //Todo: Could not find time to implment logginf for the project
                    //ExceptionLogger logger = new ExceptionLogger();
                    //await logger.HandleExceptionAsync(exception);
                }
            }
            return View(postCodeResultVm);
        }
    }
}