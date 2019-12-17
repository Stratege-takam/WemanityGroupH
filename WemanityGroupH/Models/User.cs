using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WemanityGroupH.Models
{
  public  class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
