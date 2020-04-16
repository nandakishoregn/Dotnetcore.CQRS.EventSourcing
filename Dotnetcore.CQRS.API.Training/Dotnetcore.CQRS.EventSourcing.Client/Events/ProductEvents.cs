using Dotnetcore.CQRS.EventSourcing.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Client.Events
{
    public class ProductChangeNameEvent<T> : DAPEvent
    {
        public T Target { get; set; }
        public object oldValue { get; set; }
        public object newValue { get; set; }
        //public ProductChangeNameEvent(T _target,object _oldvalue,object _newvalue)
        //{
        //    Target = _target;
        //    oldValue = _oldvalue;
        //    newValue = _newvalue;
        //}
    }
}
