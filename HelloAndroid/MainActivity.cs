﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AzureManagementLib;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Collections.Generic;
using System.Net.Http;
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using System.Threading;
using HelloAndroid.Adapters;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureManager
{
    [Activity(Label = "Hello Android!", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        PlatformParameters platformParam;
        
        public MainViewModel MainViewModel
        {
            get { return ViewModelLocator.MainViewModel; }
        }

        


        protected async override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            platformParam = new PlatformParameters(this, true);

         

            Button sqlServerListButton = FindViewById<Button>(Resource.Id.sqlServerListButton);
            Button sqlDatabaseListButton = FindViewById<Button>(Resource.Id.sqlDatabaseListButton);
            Button appServicesListButton = FindViewById<Button>(Resource.Id.appServicesListButton);

            // optionsButton.Click += (object sender, EventArgs e) =>
            //{
            //     //Dictionary<string,string> dict = await AuthenticationManager.GetAccessTokenAsync("lucu", platformParam);
            //     try
            //    {
            //    }
            //    catch (Exception ex)
            //    {
            //        string exc = ex.Message;
            //    }
            //};

            await LoginHandler();
            try
            {
               // sqlServerList = await azureResourceManager.SqlDbManager.GetSqlServersAsync().ConfigureAwait(false);
                RunOnUiThread(() =>
                {
                //    sqlServerAdapter = new SqlServerAdapter(sqlServerList);

                  //  mRecyclerView.SetAdapter(sqlServerAdapter);
                });
            }
            catch (Exception e)
            {

            }

        }

        public async Task LoginHandler()
        {

            AlertDialog.Builder alertBuilder = new AlertDialog.Builder(this);
            alertBuilder.SetTitle("Login")
                 .SetMessage("Please wait while logging in...")
                 .SetCancelable(false);

            AlertDialog dialog = null;
            RunOnUiThread(() => { dialog = alertBuilder.Show(); });
            try
            {
                azureResourceManager = await AuthenticationManager.Authenticate(platformParam);
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dismiss();
                    dialog.Dispose();
                }
                if (alertBuilder != null)
                {
                    alertBuilder.Dispose();
                }
            }

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }
    }
}
