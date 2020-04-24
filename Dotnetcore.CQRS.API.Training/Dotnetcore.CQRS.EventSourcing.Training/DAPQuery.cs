using System;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public abstract class DAPQuery
    {
        public Object Result { get; set; }
        public object Target { get; set; }
        public abstract void Execute_DAPQuery();
    }

    public class AgeQuery<T> : DAPQuery
    {
        //public Object Result { get; set; }
        //public T Target { get; set; }
        public override void Execute_DAPQuery()
        {
            throw new NotImplementedException();
        }
    }

}