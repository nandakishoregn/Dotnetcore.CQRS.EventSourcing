using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Dotnetcore.CQRS.EventSourcing.Training
{
    public interface IDAPEntity<T>
    {
        DAPEventBroker eventBroker { get; set; }
    }
    public class DAPEntity<T> : IDAPEntity<T>
    {
        public T CurrentEntity { get;}
        private string _currentEnntityType { get; set; }
        public DAPEventBroker eventBroker { get; set; }
        public DAPEntity()
        {
            this.CurrentEntity = (T)Activator.CreateInstance(typeof(T));
            eventBroker = new DAPEventBroker();
            eventBroker.Commands += EventBroker_Commands;
            eventBroker.Queries += EventBroker_Queries;
        }

        public virtual void EventBroker_Queries(object sender, DAPQuery e)
        {
            Type eRuntime = e.GetType();
            if (eRuntime != null)
            {

            }
        }

        public virtual void EventBroker_Commands(object sender, DAPCommand e)
        {
            Type eRuntime = e.GetType();
            if (eRuntime != null)
            {
                var oAssembly= AppDomain.CurrentDomain.GetAssemblies().Single(t => t == e.GetType().Assembly);
                if (oAssembly != null)
                {
                    var runtimeClass= oAssembly.GetTypes().FirstOrDefault(t => t == eRuntime);
                    if (runtimeClass != null)
                    {
                        var oRuntimeObject = Activator.CreateInstance(runtimeClass);
                        if (oRuntimeObject != null)
                        {
                            oRuntimeObject.GetType().GetProperty("Target").SetValue(oRuntimeObject, this.CurrentEntity);
                            MethodInfo toInvoke = oRuntimeObject.GetType().GetMethod("Execute_DAPCommand");
                            toInvoke.Invoke(oRuntimeObject, null);
                        }
                    }
                    
                }
            }
        }

        
    }
}
