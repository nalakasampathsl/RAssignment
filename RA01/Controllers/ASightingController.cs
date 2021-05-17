using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using RA01.Models;
using RA01.Repository;

namespace RA01.Controllers
{
    public class ASightingController : Controller
    {
        private readonly IAircraftSighting iAircraftSighting;

        public ASightingController()
        {
            this.iAircraftSighting = new AircraftSightingRepository(new AircraftSightingDBEntities());
        }

        // GET: ASighting
        public ActionResult Index()
        {
            return View(iAircraftSighting.GetAircraftSightings());
        }

        /// <summary>
        /// Fetches all AircraftSightings and return the jason format.
        /// </summary>
        /// <returns></returns>
        public JsonResult FetchAircraftSightings()
        {
            return Json(iAircraftSighting.GetAircraftSightings(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult FetchAircraftSightingsByParams(string make, string model, string registration)
        {
            if (!String.IsNullOrEmpty(make))
            {
                return Json(iAircraftSighting.GetAircraftSightings().Where(x => x.Make == make), JsonRequestBehavior.AllowGet);
            }
            else if (!String.IsNullOrEmpty(model))
            {
                return Json(iAircraftSighting.GetAircraftSightings().Where(x => x.Model == model), JsonRequestBehavior.AllowGet);
            }
            else if (!String.IsNullOrEmpty(registration))
            {
                return Json(iAircraftSighting.GetAircraftSightings().Where(x => x.Registration == registration), JsonRequestBehavior.AllowGet);
            }

            return Json(iAircraftSighting.GetAircraftSightings(), JsonRequestBehavior.AllowGet);
        }

        // GET: ASighting/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public string Create(AircraftSighting aircraftSighting)
        {
            if (ModelState.IsValid)
            {
                if (!AircraftSightingExists(aircraftSighting))
                {
                    iAircraftSighting.InsertAircraftSighting(aircraftSighting);
                    iAircraftSighting.Save();
                }
                else
                    return Edit(aircraftSighting);
                return "AircraftSighting Created";
            }
            return "Creation Failed";
        }

        public ActionResult Edit(string Id = null)
        {
            AircraftSighting aircraftSighting = iAircraftSighting.GetAircraftSightingByID(Convert.ToInt32(Id));
            if (aircraftSighting == null)
            {
                return null;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(aircraftSighting);
            return View();
        }

        /// <summary>
        /// Edits particular AircraftSighting details
        /// </summary>
        /// <param name="aircraftSighting"></param>
        /// <returns></returns>
        [HttpPost]
        public string Edit(AircraftSighting aircraftSighting)
        {
            if (ModelState.IsValid)
            {
                iAircraftSighting.UpdateAircraftSighting(aircraftSighting);
                iAircraftSighting.Save();
                return "AircraftSighting Edited";
            }
            return "Edit Failed";
        }

        public ActionResult Delete(string Id = null)
        {
            AircraftSighting aircraftSighting = iAircraftSighting.GetAircraftSightingByID(Convert.ToInt32(Id));
            if (aircraftSighting == null)
            {
                return null;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(aircraftSighting);
            return View();
        }

        public ActionResult Details(string Id = null)
        {
            AircraftSighting aircraftSighting = iAircraftSighting.GetAircraftSightingByID(Convert.ToInt32(Id));
            if (aircraftSighting == null)
            {
                return null;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewBag.InitialData = serializer.Serialize(aircraftSighting);
            return View();
        }

        /// <summary>
        /// Delete particular AircraftSighting details
        /// </summary>
        /// <param name="aircraftSighting"></param>
        /// <returns></returns>
        [HttpPost]
        public string Delete(AircraftSighting aircraftSighting)
        {
            iAircraftSighting.DeleteAircraftSighting(aircraftSighting.Id);
            iAircraftSighting.Save();
            return "AircraftSighting Deleted";
        }

        /// <summary>
        /// Checks if AircraftSighting exists
        /// </summary>
        /// <param name="aircraftSighting"></param>
        /// <returns></returns>
        private bool AircraftSightingExists(AircraftSighting aircraftSighting)
        {
            AircraftSighting foundAircraftSighting = iAircraftSighting.GetAircraftSightingByID(aircraftSighting.Id);
            if (foundAircraftSighting != null && !String.IsNullOrEmpty(foundAircraftSighting.Id.ToString()))
                return true;
            return false;
        }

        /// <summary>
        /// Dispose dbContext
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            iAircraftSighting.Dispose();
            base.Dispose(disposing);
        }
    }
}
