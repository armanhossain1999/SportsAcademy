using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportAcademy.BlazorApp.Shared.ViewModels
{
    public class ManagerViewModel
    {
        public int ManagerId { get; set; }

        [Required, StringLength(100)]
        public string ManagerName { get; set; } = "";

        [Required, Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; } = "";

        [Required, StringLength(100)]
        public string Phone { get; set; } = "";

        [Required, StringLength(100)]
        public string Address { get; set; } = "";
    
    }
}
