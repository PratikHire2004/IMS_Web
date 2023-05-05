using IMS_Web.BusinessLayer;
using IMS_Web.DataAccess;
using IMS_Web.DbEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS_Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GetStock _getStock;
        public string stockCount;
        public IndexModel(ILogger<IndexModel> logger,GetStock getStock)
        {
            _logger = logger;
            _getStock = getStock;
        }
         
        public void OnGet()
        {
            this.stockCount = _getStock.GetStockCount().ToString();
        }
    }
}
