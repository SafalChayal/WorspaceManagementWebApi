using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkspaceManagement.DataAccessLayer.CustomException
{
    public class CustomDataAccessException:Exception
    {
        public CustomDataAccessException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
