using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ContosoInventoryAPIApp;
using ContosoInventoryAPIApp.Models;

namespace ContosoInventoryAPIApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class InventoryController : ApiController
    {
        private readonly InventoryActions _inventoryActions;

        public InventoryController()
        {
            _inventoryActions = new InventoryActions();
        }

        [HttpGet]
        [Route("inventory/listinventoryxml")]
        public async Task<List<InventoryData>> listInventoryXml()
        {
            return await Task.FromResult(_inventoryActions.listInventoryXml());
        }

        [HttpGet]
        [Route("inventory/listinventoryjson")]
        public async Task<List<InventoryData>> listInventoryJson()
        {
            return await Task.FromResult(_inventoryActions.listInventoryJson());
        }

        [HttpGet]
        [Route("inventory/getproductxml/{productId}")]
        public async Task<InventoryData> getProductXml(int productId)
        {
            return await Task.FromResult(_inventoryActions.getProductXml(productId));
        }

        [HttpGet]
        [Route("inventory/getproductjson/{productId}")]
        public async Task<InventoryData> getProductJson(int productId)
        {
            return await Task.FromResult(_inventoryActions.getProductJson(productId));
        }

    }
}