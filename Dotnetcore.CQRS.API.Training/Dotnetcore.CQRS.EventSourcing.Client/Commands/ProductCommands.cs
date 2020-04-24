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
            
        }
    }

    public class ChangeProductQtyCommand : DAPCommand
    {
        public ChangeProductQtyCommand()
        {

        }

        public int Qty { get; set; }

        public override void Execute_DAPCommand()
        {

        }
    }

    public class ChangeProductQtyNameCommand : DAPCommand
    {
        public ChangeProductQtyNameCommand()
        {

        }

        public int Qty { get; set; }
        public String Name { get; set; }

        public override void Execute_DAPCommand()
        {

        }
    }
}
