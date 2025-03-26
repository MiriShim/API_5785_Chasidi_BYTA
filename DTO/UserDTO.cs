using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public  class UserDTO
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string? Email { get; set; }

        public string Password  { get; set; } = "1234"!;

        public DateOnly CreatedAt { get; set; }

        public string MainGroup { get; set; }
        public int NumberOfPrivatePermissions { get; set; }
    }
}
