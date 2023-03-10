using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using DDDCustomerUi.Server.Data;

namespace DDDCustomerUi.Server.Controllers
{
    public partial class ExportDDDCustomerDbController : ExportController
    {
        private readonly DDDCustomerDbContext context;
        private readonly DDDCustomerDbService service;

        public ExportDDDCustomerDbController(DDDCustomerDbContext context, DDDCustomerDbService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/DDDCustomerDb/customers/csv")]
        [HttpGet("/export/DDDCustomerDb/customers/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetCustomers(), Request.Query), fileName);
        }

        [HttpGet("/export/DDDCustomerDb/customers/excel")]
        [HttpGet("/export/DDDCustomerDb/customers/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportCustomersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetCustomers(), Request.Query), fileName);
        }
    }
}
