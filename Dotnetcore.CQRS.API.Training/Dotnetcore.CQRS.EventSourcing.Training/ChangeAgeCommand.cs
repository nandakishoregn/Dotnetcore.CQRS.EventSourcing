using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public class ChangeAgeCommand : DAPCommand
    {
        public object ValueChanged { get; set; }
        public int Age { get; set; }
        public ChangeAgeCommand(object _target,object _valuetobechanged)
        {
            Target = _target;
            ValueChanged = _valuetobechanged;
            Age = (int)_valuetobechanged;
        }

        public override void Execute_DAPCommand()
        {
            
        }
    }
}
