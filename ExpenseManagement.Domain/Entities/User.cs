using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManagement.Domain.Enums;

namespace ExpenseManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public UserRole Role { get; private set; }
        public Guid? ManagerId { get; private set; }

        private User() { }

        public User(string name, string email, UserRole role, Guid? managerId = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Role = role;
            ManagerId = managerId;
        }

        public void AssignManager(Guid managerId)
        {
            if (Role != UserRole.Manager)
            {
                throw new InvalidOperationException("Only employee can have manager.");
            }

            ManagerId = managerId;
        }

    }
}
