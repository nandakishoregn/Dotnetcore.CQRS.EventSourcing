using System;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public class DAPQuery
    {
        public Object Result { get; set; }
        public object Target { get; set; }
    }

    public class AgeQuery<T>: DAPQuery
    {
        //public Object Result { get; set; }
        //public T Target { get; set; }
    }

}