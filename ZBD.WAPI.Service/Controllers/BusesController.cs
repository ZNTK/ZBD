using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet]
        [Route("api/buses/{name}")]
        public IHttpActionResult Get(string name)
        {
            var bus = busesService.Get(name);
            return Ok(bus);
        }

        public IHttpActionResult Post(Bus bus)
        {
            busesService.Add(bus);

            return CreatedAtRoute("DefaultApi", new { id = bus.Id }, bus);
        }

        public IHttpActionResult Put(Bus bus)//nie dziala do konca dobrze bo jak czegos nie przekazesz to wstawia default vvalues
        {
            busesService.Update(bus);
            return Ok();
        }

        public IHttpActionResult Delete(Guid id)
        {
            busesService.Remove(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}