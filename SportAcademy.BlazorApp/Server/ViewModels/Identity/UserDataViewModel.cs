using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportAcademy.BlazorApp.Server.DataApi.ViewModels.Identity
{
    public class UserDataViewModel
    {
        public string Id { get; set; } = default!;
        [Required, StringLength(30)]
        public string Username { get; set; } = default!;
        [Required, StringLength(50), EmailAddress]
        public string Email { get; set; }= default!;
        public string[]? Roles { get; set; }
    }
}
