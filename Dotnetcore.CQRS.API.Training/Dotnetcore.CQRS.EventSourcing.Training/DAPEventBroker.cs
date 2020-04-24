using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    /// <summary>
    /// To perform Operations using commands and queries
    /// </summary>
    public class DAPEventBroker
    {
        public DAPEventBroker()
        {
        }

        //List of all events supported
        public DAPEvent EventDetails { get; set; } = new DAPEvent();
        //public IList<DAPEvent> Events { get; set; } = new List<DAPEvent>();
        //Commands for execution
        public event EventHandler<DAPCommand> Commands;
        //Queries for fetching
        public event EventHandler<DAPQuery> Queries;
        //To undo last transaction


        public void ExecuteCommand(DAPCommand command)
        {
            DAPEventInfo oEventInfo = new DAPEventInfo();
            oEventInfo.Id = EventDetails.EventInfos.Count + 1;
            oEventInfo.Command = command;
            oEventInfo.CreatedBy = "Guest";
            oEventInfo.OldTarget = command.Target;
            Commands?.Invoke(this, command);

            EventDetails.EventInfos.Add(new DAPEventInfo() {Id= EventDetails.EventInfos.Count+1, Command = command, CreatedBy = "Guest" });
            EventDetails.Save();
        }

        public T ExecuteQuery<T>(DAPQuery query)
        {
            Queries?.Invoke(this, query);
            return (T)query.Result;
        }

        public void UndoLastTransaction<T>()
        {

            //var e = Events.Where(t => (t as AgeChangedEvent<T>).Target.GetType() == typeof(T)).LastOrDefault();
            //if (e != null)
            //{
            //    var oEvent = e as AgeChangedEvent<T>;
            //    if (oEvent != null)
            //    {
            //        ExecuteCommand(new ChangeAgeCommand(oEvent.Target, oEvent.oldValue));
            //        Events.Remove(e);
            //    }
            //}
        }
    }
}
