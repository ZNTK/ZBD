using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ZBD.WAPI.DatabaseServices;
using ZBD.WAPI.IServices;
using ZBD.WAPI.Models;

namespace ZBD.WAPI.Service.Controllers
{
    public class BusesController : ApiController
    {
        private readonly IBusesService busesService;

        public BusesController()
            : this(new DatabaseBusesService())
        {

        }

        public BusesController(IBusesService busesService)
        {
            this.busesService = busesService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var buses = busesService.Get();
            return Ok(buses);
        }

        public IHttpActionResult Post(Bus bus)
        {
            busesService.Add(bus);

            return CreatedAtRoute("DefaultApi", new { id = bus.Id }, bus);
        }
    }
}