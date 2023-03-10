using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using DDDCustomerUi.Server.Data;

namespace DDDCustomerUi.Server
{
    public partial class DDDCustomerDbService
    {
        DDDCustomerDbContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly DDDCustomerDbContext context;
        private readonly NavigationManager navigationManager;

        public DDDCustomerDbService(DDDCustomerDbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


        public async Task ExportCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dddcustomerdb/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dddcustomerdb/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dddcustomerdb/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dddcustomerdb/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCustomersRead(ref IQueryable<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> items);

        public async Task<IQueryable<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>> GetCustomers(Query query = null)
        {
            var items = Context.Customers.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCustomersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCustomerGet(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> GetCustomerByCustomerId(Guid customerid)
        {
            var items = Context.Customers
                              .AsNoTracking()
                              .Where(i => i.CustomerId == customerid);

  
            var itemToReturn = items.FirstOrDefault();

            OnCustomerGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnCustomerCreated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);
        partial void OnAfterCustomerCreated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> CreateCustomer(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer customer)
        {
            OnCustomerCreated(customer);

            var existingItem = Context.Customers
                              .Where(i => i.CustomerId == customer.CustomerId)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Customers.Add(customer);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(customer).State = EntityState.Detached;
                throw;
            }

            OnAfterCustomerCreated(customer);

            return customer;
        }

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> CancelCustomerChanges(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCustomerUpdated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);
        partial void OnAfterCustomerUpdated(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> UpdateCustomer(Guid customerid, DDDCustomerUi.Server.Models.DDDCustomerDb.Customer customer)
        {
            OnCustomerUpdated(customer);

            var itemToUpdate = Context.Customers
                              .Where(i => i.CustomerId == customer.CustomerId)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(customer);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterCustomerUpdated(customer);

            return customer;
        }

        partial void OnCustomerDeleted(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);
        partial void OnAfterCustomerDeleted(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer item);

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> DeleteCustomer(Guid customerid)
        {
            var itemToDelete = Context.Customers
                              .Where(i => i.CustomerId == customerid)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCustomerDeleted(itemToDelete);


            Context.Customers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCustomerDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}