namespace P03_SalesDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Store
    {
        public Store()
        {
            Sales = new List<Sale>(); 
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public ICollection<Sale> Sales { get; set; }


    }
}
