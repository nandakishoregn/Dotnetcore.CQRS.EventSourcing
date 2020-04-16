using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public class AgeChangedEvent<T> : DAPEvent
    {
        public AgeChangedEvent(T target, int oldValue, int newValue)
        {
            Target = target;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public T Target { get; set; }
        public int oldValue { get; set; }
        public int newValue { get; set; }

        public override string ToString()
        {
            return $"Age changed from {oldValue} : {newValue}";
        }
    }
}
