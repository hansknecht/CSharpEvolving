using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController {
        public ProductController(AdventureWorksDbContext context) : base() {
            _DbContext = context;
        }

        private AdventureWorksDbContext _DbContext;

        private const string ENTITY_NAME = "product";

        // GET api/values
        [HttpGet]
        public IActionResult GetAction() {
            IActionResult ret = null;
            List<Product> list = new List<Product>();

            try {
                if (_DbContext.Products.Count() > 0) {
                    list = _DbContext.Products.OrderBy(p => p.name).ToList();
                    ret = StatusCode(StatusCodes.Status200OK, list);
                } else {
                    ret = StatusCode(StatusCodes.Status404NotFound, $"No {ENTITY_NAME}s exist in the system.");
                }
            } catch (Exception ex) {
                ret = HandleException(ex, $"Exception trying to get all {ENTITY_NAME}s.");
            }
            return ret;
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id) {
            IActionResult ret = null;
            Product entity = null;

            try {
                entity = _DbContext.Products.Find(id);

                if (entity != null) {
                    ret = StatusCode(StatusCodes.Status200OK, entity);
                } else {
                    //ret = StatusCode( StatusCodes.Status404NotFound, "Can't find " + ENTITY_NAME + ": " + id.ToString() + ".");
                    ret = StatusCode( StatusCodes.Status404NotFound, $"Can't find {ENTITY_NAME}: {id.ToString()}.");
                }
            } catch (Exception ex) {
                ret = HandleException(ex, $"Exception trying to retrieve {ENTITY_NAME} ID: {id.ToString()}.");
            }
            return ret;
        }

    }
}