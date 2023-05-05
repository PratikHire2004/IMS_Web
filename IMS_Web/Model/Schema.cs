using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IMS_Web.Model
{
    public class tbl_schema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int component_id { get; set; }
        public int quantity { get; set; }
    }
    public class tbl_components
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int component_id { get; set; }
        public string componenet_name { get; set; }
    }
    public class tbl_depended
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int component_id { get; set; }
        public int depended_id { get; set; }
        public int quantity { get; set; }

    }
    public class ResponseData
    {
        public string ComponenetName { get; set; }
        public int Quantity { get; set; }
    }
}
