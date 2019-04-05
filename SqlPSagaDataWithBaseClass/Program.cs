using NServiceBus;
using NServiceBus.Persistence.Sql;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlPSagaDataWithBaseClass
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpointConfiguration = new EndpointConfiguration("SqlPSagaDataWithBaseClass");
            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.SendFailedMessagesTo("error");

            var connection = @"Data Source=.\SqlExpress;Initial Catalog=SqlPSagaDataWithBaseClass;Integrated Security=True";
            var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
            persistence.SqlDialect<SqlDialect.MsSqlServer>();
            persistence.ConnectionBuilder(() =>new SqlConnection(connection));

            var endpoint = await Endpoint.Start(endpointConfiguration);

            Console.Read();
        }
    }
}
