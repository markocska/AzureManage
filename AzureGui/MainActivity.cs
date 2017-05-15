using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.OS;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using AzureManagementShared.ViewModel;
using AzureManagementShared;
using Android.Widget;
using AzureManagementLib;
using AzureGui;
using GalaSoft.MvvmLight.Helpers;

namespace AzureGui
{
    [Activity(Label = "AzureGui", MainLauncher = true, Icon = "@drawable/icon")]
    public  partial class MainActivity 
    {
        int count = 1;
        PlatformParameters platformParam;

        public MainViewModel MVM
        {
            get { return App.Locator.MVM; }
        }


        protected async override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            platformParam = new PlatformParameters(this, true);

           // MVM.LoginCommand.Execute(platformParam);

            SqlDatabaseListButton.Click += (object sender, EventArgs args) =>
            {
                MVM.NavigateToPageCommand.Execute(ViewModelLocator.sqlDatabaseListPageKey);
            };

            SqlServerListButton.Click += (object sender, EventArgs args) =>
            {
                MVM.NavigateToPageCommand.Execute(ViewModelLocator.sqlServerListPageKey);
            };

            AppServicesListButton.Click += (object sender, EventArgs args) =>
            {
                MVM.NavigateToPageCommand.Execute(ViewModelLocator.appServicePlanListPageKey);
            };

            LoginButton.Click +=  (object sender, EventArgs args) =>
            {
                MVM.LoginCommand.Execute(platformParam);
            };

            await LoginHandler();
      

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
                MVM.LoginCommand.Execute(platformParam);
            }
            catch (Exception e)
            {
                dialog.SetMessage("An unfortunate error happenened." + e.Message);
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

