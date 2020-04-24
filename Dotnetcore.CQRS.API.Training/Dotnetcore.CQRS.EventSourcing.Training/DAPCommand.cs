using Newtonsoft.Json;
using System;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public abstract class DAPCommand : EventArgs
    {
        
        public object Target { get; set; }
        public abstract void Execute_DAPCommand();
       
    }

    public interface IDAPCommand
    {
        Object Target { get; set; }
        void Execute_DAPCommand();
        
    }
}