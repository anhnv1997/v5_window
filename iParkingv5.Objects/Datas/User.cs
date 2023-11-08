using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace iParkingv6.Objects.Datas
{

    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordSalat { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool Admin { get; set; } = false;
        public bool Active { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public string UserAvatar { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public IEnumerable<Role> Roles { get; set; }
    }
}
