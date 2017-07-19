using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OshBusinessModel.Data;

namespace OshBusinessModel.Da
{
    partial class UserDa
    {
        public bool IsAdmin
        {
            get { return Role.Trim() == UserType.Administrator.SemanticId; }
        }
    }
}
