using NServiceBus;
using NServiceBus.Persistence.Sql;
using System;
using System.Threading.Tasks;

namespace SampleSagaLibrary
{
    //[SqlSaga( correlationProperty:"MyId")]
    class SampleSaga : Saga<SampleSagaData>,
        IAmStartedByMessages<AMessage>
    {
        public Task Handle(AMessage message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<SampleSagaData> mapper)
        {
            mapper.ConfigureMapping<AMessage>(m => m.MyId).ToSaga(s => s.MyId);
        }
    }

    abstract class SampleSagaDataBaseClass : ContainSagaData
    {
        public Guid MyId { get; set; }
    }

    class SampleSagaData : SampleSagaDataBaseClass
    {
        
    }

    class AMessage
    {
        public Guid MyId { get; set; }
    }
}
