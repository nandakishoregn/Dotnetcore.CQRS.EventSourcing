using System;
using Dotnetcore.CQRS.EventSourcing.Training;
using System.Linq;
using Dotnetcore.CQRS.EventSourcing.Client.Entities;
using Dotnetcore.CQRS.EventSourcing.Client.Commands;
using Dotnetcore.CQRS.EventSourcing.Client.Queries;

namespace Dotnetcore.CQRS.EventSourcing.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DAPEventBroker eventBroker = new DAPEventBroker();
            //Person obj = new Person(eventBroker);
            //eventBroker.ExecuteCommand(new ChangeAgeCommand(obj, 134));

            //eventBroker.Events.ToList().ForEach(t=> {
            //    Console.WriteLine(t.ToString());
            //});

            //int Age = eventBroker.ExecuteQuery<int>(new AgeQuery<Person>() { Target=obj });
            //Console.WriteLine("Age before undo : " + Age);
            //eventBroker.UndoLastTransaction<Person>();
            //Age = eventBroker.ExecuteQuery<int>(new AgeQuery<Person>() { Target = obj });
            //Console.WriteLine("Age after undo : "+Age);


            //DAPEntity<ProductEntity> oProduct = new DAPEntity<ProductEntity>();
            //ChangeProductNameCommand oCmd = new ChangeProductNameCommand();
            //oCmd.Name = "Testing";
            //oCmd.Target = oProduct.CurrentEntity;
            //oProduct.eventBroker.ExecuteCommand(oCmd);

            //ChangeProductQtyCommand oQtyCmd = new ChangeProductQtyCommand();
            //oQtyCmd.Qty = 10;
            //oQtyCmd.Target = oProduct.CurrentEntity;
            //oProduct.eventBroker.ExecuteCommand(oQtyCmd);

            //var oChangedQtyEntity = oProduct.eventBroker.ExecuteQuery<ProductEntity>(new ProductQtyQuery() {Target=oProduct.CurrentEntity });

            //var oChngedEntity= oProduct.eventBroker.ExecuteQuery<ProductEntity>(new ProductNameQuery() { Target = oProduct.CurrentEntity });
            //Console.WriteLine("Name : "+ oChngedEntity.Name);
            DAPEntity<ProductEntity> oProduct = new DAPEntity<ProductEntity>();
            ChangeProductQtyNameCommand oQNCmd = new ChangeProductQtyNameCommand();
            oQNCmd.Name = "Hello Testing";
            oQNCmd.Qty = 100;
            oQNCmd.Target = oProduct.CurrentEntity;
            oProduct.eventBroker.ExecuteCommand(oQNCmd);

            ChangeProductQtyCommand oQtyCmd = new ChangeProductQtyCommand();
            oQtyCmd.Qty = 10;
            oQtyCmd.Target = oProduct.CurrentEntity;
            oProduct.eventBroker.ExecuteCommand(oQtyCmd);


            var oChngedEntity = oProduct.eventBroker.ExecuteQuery<ProductEntity>(new ProductNameQtyQuery() { Target = oProduct.CurrentEntity });
            Console.WriteLine("Name : " + oChngedEntity.Name);

            //ProductEntity product = new ProductEntity(eventBroker);
            //eventBroker.ExecuteCommand(new ChangeProductNameCommand(product,"Testing"));
            //eventBroker.Events.ToList().ForEach(t => {
            //    Console.WriteLine(t.ToString());
            //});

            //var oName = eventBroker.ExecuteQuery<ProductEntity>(new ProductNameQuery() { Target = product });
            //Console.WriteLine($"Query Name{"ProductNameQuery"} : " + oName);

            Console.ReadLine();
        }
    }
}
