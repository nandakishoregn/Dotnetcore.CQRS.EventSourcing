using Dotnetcore.CQRS.EventSourcing.Client.Commands;
using Dotnetcore.CQRS.EventSourcing.Client.Events;
using Dotnetcore.CQRS.EventSourcing.Client.Queries;
using Dotnetcore.CQRS.EventSourcing.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Client.Entities
{
    public class ProductEntity
    {
        //DAPEventBroker eventBroker;
        //public ProductEntity(DAPEventBroker brokerInstance)
        //{
        //    eventBroker = brokerInstance;
        //    eventBroker.Commands += EventBroker_Commands;
        //    eventBroker.Queries += EventBroker_Queries;
        //}

        //private void EventBroker_Queries(object sender, DAPQuery e)
        //{
        //    if (e is ProductNameQuery)
        //    {
        //        var oPNQ = e as ProductNameQuery;
        //        if(oPNQ!=null && oPNQ.Target == this)
        //        {
        //            oPNQ.Result = _name;
        //        }
        //    }
        //}

        //private void EventBroker_Commands(object sender, DAPCommand e)
        //{
        //    if(e is ChangeProductNameCommand)
        //    {
        //        var oCPNC = e as ChangeProductNameCommand;
        //        if(oCPNC!=null && oCPNC.Target == this)
        //        {
        //            eventBroker.Events.Add(new ProductChangeNameEvent<ProductEntity>(this,_name,oCPNC.Name));
        //            _name = oCPNC.Name;
        //        }
        //    }
        //}

        public String Name { get; set; }
        public int Qty { get; set; }
    }
}
