namespace AzureManagementLib.Services.Factories
{
    public interface IAzureServiceFactory
    {
        AppServicePlanService CreateAppServicePlanService();

        SqlDatabaseService CreateSqlDatabaseService();

        SqlServerService CreateSqlServerService();
    }
}