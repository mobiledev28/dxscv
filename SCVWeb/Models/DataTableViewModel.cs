using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SCVWeb.Models
{

    public class DataTableViewModel
    {
        public string sEcho { get; set; }
        public int iDisplayStart { get; set; }
        public int iDisplayLength { get; set; }
        public string sSearch { get; set; }
        public int iSortingCols { get; set; }
        public string sSearch_1 { get; set; } //reltype
        public bool? iIsExport { get; set; }
    }
}