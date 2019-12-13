using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESTFamifedScreens.DAL.Entities
{
    public class FoodRequest
    {
        [Key]
        public int Id { get; set; }
        public Person RequestBy { get; set; }
        public bool IsThirsty { get; set; }
        public int FlowStatusId { get; set; }
        public int FoodOptionId { get; set; }
        public DateTime TimeOfReview { get; set; }
        public Person ReviewedBy { get; set; }
        public DateTime TimeOfOrder { get; set; }
        public Person OrderedBy { get; set; }
        public string Remark { get; set; }


    }
}
