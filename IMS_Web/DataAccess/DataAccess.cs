using IMS_Web.DbEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using IMS_Web.Model;

namespace IMS_Web.DataAccess
{
    public class DataClass
    {
        private readonly ComponentContext _context;

        public DataClass(ComponentContext context)
        {
            _context = context;
        }

        public List<ResponseData> GetDataAsync() 
        {
            var result =  _context.singleComponentdata.FromSqlRaw($"select " +
                           "(select TS.componenet_name from dbo.components TS where TS.component_id = DP.depended_id) ComponenetName," +
                           " SCH.quantity from dbo.[schema] SCH inner join dbo.components CM on SCH.component_id = CM.component_id " +
                           "left join dbo.depended DP on CM.component_id = DP.component_id").ToList();
            return result;
        }
    }

}
