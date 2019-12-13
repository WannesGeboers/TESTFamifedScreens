using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TESTFamifedScreens.DAL.Entities
{
    public class FlowStatus
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
    }
}
