using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestNetCore.Core.Model
{
    
    public class User  
    {
        //private readonly ILazyLoader _lazyLoader;
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }


        //public virtual ICollection<Phone> Phones
        //{
        //    get => _lazyLoader.Load(this, ref _phones);
        //    set => _phones = value;
        //}

        //public User(ILazyLoader lazyLoader)
        //{
        //    _lazyLoader = lazyLoader;
        //}

        public User()
        {

        }
    }
}
