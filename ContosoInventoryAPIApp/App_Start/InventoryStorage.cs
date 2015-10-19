using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoInventoryAPIApp.Models;

namespace ContosoInventoryAPIApp.App_Start
{
    class InventoryStorage
    {
        private InventoryActions _actions;

        public InventoryStorage()
        {
            _actions = new InventoryActions();
        }

        public async Task<IEnumerable<InventoryData>> listInventoryXml()
        {
            var data = new InventoryData();
            await _actions.listInventoryXml();
            return _actions.listInventoryXml();
        }
    }
}
