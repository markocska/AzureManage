using AzureManagementLib.Models;
using AzureManagementLib.ModelView;
using Microsoft.Azure.Management.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagementLib.Services
{
    public interface ISqlServerService : IAzureService<SqlServerModel>
    {

    }
}
