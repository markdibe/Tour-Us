using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOUR_US.BO.ViewModels
{
    public class QueryFilter
    {

        public QueryFilter()
        {
            PageNumber = 0;
            Range = 100;
            PropertyNames = new string[0];
            PropertyValues = new string[0];
            Condition = "AND";
        }

        public int Id { get; set; }
        public string id { get; set; }

        public string[] PropertyNames { get; set; }

        public string[] PropertyValues { get; set; }

        public int PageNumber { get; set; }

        public int Range { get; set; }

        public bool OrderByDescending { get; set; }

        public string OrderProperty { get; set; }

        private string condition;
        public string Condition
        {
            get { return condition; }
            set
            {
                if (value == "AND" || value == "OR")
                { condition = value; }
                else { condition = "AND"; }
            }
        }
    }
}
