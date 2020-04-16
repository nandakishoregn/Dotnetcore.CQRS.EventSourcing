using Dotnetcore.CQRS.EventSourcing.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Client.Commands
{
    public class ChangeProductNameCommand : DAPCommand
    {
        public ChangeProductNameCommand()
        {
            
        }

        public String Name { get; set; }

        public override void Execute_DAPCommand()
        {
            var oName = nameof(Name);
            var oRuntimeObject = Target.GetType().GetProperty(oName).GetValue(Target);
            this.GetType().GetProperty(oName).SetValue(this, oRuntimeObject);
            if (Name != null)
            {

            }
        }
    }
}
