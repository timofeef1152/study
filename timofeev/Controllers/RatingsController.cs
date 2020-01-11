using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using timofeev.Models;

namespace timofeev.Controllers
{
    public class RatingsController : ApiController
    {
        // READ
        public IEnumerable<RatingVM> GetAll()
        {
            return Db.GetRatings().Select(x => new RatingVM(x));
        }

        public RatingVM Get(int id)
        {
            var list_r = Db.GetRatings().Select(x => new RatingVM(x)).ToArray();
            if (id < 0 || id >= list_r.Length)
            {
                return null;
            }
            else
            {
                return list_r[id];
            }
        }

        // CREATE
        public void Add([FromBody]string value)
        {
        }

        // UPDATE
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE
        public IHttpActionResult Del(int id)
        {
            if (Db.DeleteRating(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
