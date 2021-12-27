using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TamroTask.Core.Entities;

namespace TamroTask.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}
