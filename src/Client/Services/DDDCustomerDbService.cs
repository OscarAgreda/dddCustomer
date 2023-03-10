
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace DDDCustomerUi.Client
{
    public partial class DDDCustomerDbService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public DDDCustomerDbService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/DDDCustomerDb/");
        }


        public async System.Threading.Tasks.Task ExportCustomersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dddcustomerdb/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dddcustomerdb/customers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportCustomersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/dddcustomerdb/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/dddcustomerdb/customers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetCustomers(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>> GetCustomers(Query query)
        {
            return await GetCustomers(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>> GetCustomers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Customers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>>(response);
        }

        partial void OnCreateCustomer(HttpRequestMessage requestMessage);

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> CreateCustomer(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer customer = default(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer))
        {
            var uri = new Uri(baseUri, $"Customers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            OnCreateCustomer(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>(response);
        }

        partial void OnDeleteCustomer(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteCustomer(Guid customerId = default(Guid))
        {
            var uri = new Uri(baseUri, $"Customers({customerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteCustomer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetCustomerByCustomerId(HttpRequestMessage requestMessage);

        public async Task<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> GetCustomerByCustomerId(string expand = default(string), Guid customerId = default(Guid))
        {
            var uri = new Uri(baseUri, $"Customers({customerId})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetCustomerByCustomerId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer>(response);
        }

        partial void OnUpdateCustomer(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateCustomer(Guid customerId = default(Guid), DDDCustomerUi.Server.Models.DDDCustomerDb.Customer customer = default(DDDCustomerUi.Server.Models.DDDCustomerDb.Customer))
        {
            var uri = new Uri(baseUri, $"Customers({customerId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", customer.ETag);    

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            OnUpdateCustomer(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}