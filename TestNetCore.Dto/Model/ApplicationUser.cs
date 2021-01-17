using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestNetCore.Core.Model
{
    [Table("AspNetUsers")]
    public class ApplicationUser : IdentityUser
    {
        public virtual User User { get; set; }

        public ApplicationUser()
        {
        }
    }
}
