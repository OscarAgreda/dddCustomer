using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DDDCustomerUi.Server.Controllers.DDDCustomerDb
{
    [Route("odata/DDDCustomerDb/Customers")]
    public partial class CustomersController : ODataController
    {
        private DDDCustomerUi.Server.Data.DDDCustomerDbContext context;

        public CustomersController(DDDCustomerUi.Server.Data.DDDCustomerDbContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> GetCustomers()
        {
            var items = this.context.Customers.AsQueryable<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>();
            this.OnCustomersRead(ref items);

            return items;
        }

        partial void OnCustomersRead(ref IQueryable<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> items);

        partial void OnCustomerGet(ref SingleResult<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/DDDCustomerDb/Customers(CustomerId={CustomerId})")]
        public SingleResult<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> GetCustomer(Guid key)
        {
            var items = this.context.Customers.Where(i => i.CustomerId == key);
            var result = SingleResult.Create(items);

            OnCustomerGet(ref result);

            return result;
        }
        partial void OnCustomerDeleted(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);
        partial void OnAfterCustomerDeleted(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        [HttpDelete("/odata/DDDCustomerDb/Customers(CustomerId={CustomerId})")]
        public IActionResult DeleteCustomer(Guid key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var items = this.context.Customers
                    .Where(i => i.CustomerId == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.OnCustomerDeleted(item);
                this.context.Customers.Remove(item);
                this.context.SaveChanges();
                this.OnAfterCustomerDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCustomerUpdated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);
        partial void OnAfterCustomerUpdated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        [HttpPut("/odata/DDDCustomerDb/Customers(CustomerId={CustomerId})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutCustomer(Guid key, [FromBody]DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.Customers
                    .Where(i => i.CustomerId == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>(Request, items);

                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                this.OnCustomerUpdated(item);
                this.context.Customers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Customers.Where(i => i.CustomerId == key);
                ;
                this.OnAfterCustomerUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/DDDCustomerDb/Customers(CustomerId={CustomerId})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchCustomer(Guid key, [FromBody]Delta<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var items = this.context.Customers
                    .Where(i => i.CustomerId == key)
                    .AsQueryable();

                items = Data.EntityPatch.ApplyTo<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>(Request, items);

                var item = items.FirstOrDefault();

                if (item == null)
                {
                    return StatusCode((int)HttpStatusCode.PreconditionFailed);
                }
                patch.Patch(item);

                this.OnCustomerUpdated(item);
                this.context.Customers.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Customers.Where(i => i.CustomerId == key);
                ;
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnCustomerCreated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);
        partial void OnAfterCustomerCreated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnCustomerCreated(item);
                this.context.Customers.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.Customers.Where(i => i.CustomerId == item.CustomerId);

                ;

                this.OnAfterCustomerCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
