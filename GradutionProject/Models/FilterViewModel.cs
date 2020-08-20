using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradutionProject.Models
{
    public class FilterViewModel
    {
        public int Page { get; set; }
        public int CatagoryId { get; set; }
        public int DistrictId { get; set; }
        public decimal MinimumPrice { get; set; }
        public decimal MaximumPrice { get; set; }
        public Finishig FinishingState { get; set; }
        public Furniture FurnitureState { get; set; }
    }
}
