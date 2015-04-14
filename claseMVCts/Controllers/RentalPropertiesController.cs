using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace claseMVCts.Controllers
{
    public class RentalPropertiesController : Controller
    {
        //
        // GET: /RentalProperties/

        private RentalPropertyTestData _data = new RentalPropertyTestData();
        // List all the properties

        public ActionResult All()
        {

            //var allRentalProperties = _data.RentalProperties;
            //return View(allRentalProperties);
            return View();


        }



        // get a specific property, display details and list all units:

        public ActionResult RentalProperty(string rentalPropertyName)
        {

            //var rentalProperty = _data.RentalProperties.Find(a => a.Name == rentalPropertyName);
            //return View(rentalProperty);
            return View();

        }



        // get a specific unit at a specific property:

        public ActionResult Unit(string rentalPropertyName, string unitNo)
        {

            //var unit = _data.Units.Find(u => u.RentalProperty.Name == rentalPropertyName);
            //return View(unit);
            return View();

        }



    }
}
