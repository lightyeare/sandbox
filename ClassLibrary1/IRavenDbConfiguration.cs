namespace RavenDb
{
    public interface IRavenDbConfiguration
    {
        IRavenDbConfiguration WithDatabaseName(string databaseName);
    }
}