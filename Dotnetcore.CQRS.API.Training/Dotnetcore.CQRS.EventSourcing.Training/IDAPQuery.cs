using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public interface IDAPQuery<T>
    {
        Object Result { get; set; }
        T Target { get; set; }
    }
}
