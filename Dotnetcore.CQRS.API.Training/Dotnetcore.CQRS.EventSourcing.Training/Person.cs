using System;
using System.Collections.Generic;
using System.Text;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public class Person
    {
        private int _age { get; set; }

        DAPEventBroker eventBroker;

        public Person(DAPEventBroker currentBroker)
        {
            this.eventBroker = currentBroker;
            eventBroker.Commands += EventBroker_Commands;
            eventBroker.Queries += EventBroker_Queries;
        }

        private void EventBroker_Queries(object sender, DAPQuery e)
        {
            var ac = e as AgeQuery<Person>;
            if(ac!=null && ac.Target == this)
            {
                ac.Result = _age;
            }
        }

        private void EventBroker_Commands(object sender, DAPCommand e)
        {
            var cAC = e as ChangeAgeCommand;
            if (cAC != null && cAC.Target == this)
            {
                //eventBroker.Events.Add(new AgeChangedEvent<Person>(this, _age, cAC.Age));
                _age = cAC.Age;
            }
        }


    }
}
