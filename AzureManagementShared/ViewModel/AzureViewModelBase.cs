﻿
using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using AzureManagementLib.Models;
using AzureManagementShared.ViewModel.Interfaces;

namespace AzureManagementShared
{
     public abstract class AzureViewModelBase : ViewModelBase, IAzureViewModelBase
    {
        protected IAzureResource azureResource;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            RaisePropertyChanged(propertyName);
        }

        public string Name { get { return azureResource.Name; } }

        public string Region { get { return azureResource.Region; } }

        public string ResourceGroup { get { return azureResource.ResourceGroupName; } }

        public string Type {get { return azureResource.Type; } }

        public AzureViewModelBase(IAzureResource azureResource)
        {
            this.azureResource = azureResource;
        }

        public bool IsHidden { get; set; } = false;


    }
}
