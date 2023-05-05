using IMS_Web.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMS_Web.BusinessLayer
{
    public class GetStock
    {
        private readonly DataClass _dataAccess;

        public static DATA stock = new DATA 
        {
            SEAT = 50,
            PEDAL = 60,
            FRAME = 60,
            TUBE = 35
        };

        public GetStock(DataClass dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public int GetStockCount()
        {
            var SingleComponentsReq = _dataAccess.GetDataAsync();
            int completedCount = 0;
            bool itemCreated = false;
            while (IsStocklast()) 
            {
                foreach (var item in SingleComponentsReq) 
                {
                    var stockCompCount = getPropertyValue(item.ComponenetName);
                    var pendingCompCount = stockCompCount - item.Quantity;
                    var result = updateStock(item.ComponenetName, pendingCompCount);
                    itemCreated = pendingCompCount > 0 ? true : false;
                }
                if(itemCreated)
                    completedCount++;
            }
            Console.WriteLine(completedCount);
            return completedCount;
        }
        public bool IsStocklast() 
        {
            return (stock.SEAT > 0 && stock.PEDAL > 0 && stock.FRAME > 0 && stock.TUBE > 0 );
        }

        public int getPropertyValue(string name) 
        {
            var properties = stock.GetType().GetProperties();
            foreach (var prop in properties) 
            {
                if (prop.Name.ToString() == name) 
                {
                    int result = (int)prop.GetValue(stock, null);
                    return result;
                }
            }
            return 0;
        }
        public bool updateStock(string componentName, int updatedstock) 
        {
            var properties = stock.GetType().GetProperties();
            foreach (var prop in properties)
            {
                if (prop.Name.ToString() == componentName)
                {
                    prop.SetValue(stock,updatedstock);
                    return true;
                }
            }
            return false;
        }
    }
}
