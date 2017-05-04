using System;
using System.Collections.Generic;
using System.Text;

namespace AzureManagementShared.ViewModel.Interfaces
{
    public interface IAzureViewModelBase
    {
        string Name { get; }

        string Region { get; }

        string ResourceGroup { get; }

        string Type { get; }

    }
}
