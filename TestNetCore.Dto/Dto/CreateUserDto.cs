using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestNetCore.Core.Dto
{
    public class CreateUserDto
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Password { get; set; }

        public ICollection<CreatePhoneDto> Phones { get; set; }     

        public CreateUserDto()
        {
            this.Phones = new Collection<CreatePhoneDto>();
        }
    }
}
