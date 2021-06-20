using Hotel.Api.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Application.Common.Models
{
    public class EditRoleViewModel
    {
        public string RoleId { get; set; }
        
        [Required]
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
