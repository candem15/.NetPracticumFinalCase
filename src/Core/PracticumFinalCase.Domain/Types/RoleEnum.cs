using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Domain.Types
{
    public enum RoleEnum
    {
        [Description(Role.Admin)]
        Admin = 1,

        [Description(Role.BasicUser)]
        BasicUser = 2
    }

    public class Role
    {
        public const string Admin = "admin";
        public const string BasicUser = "basicUser";
    }
}
