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
        public T CurrentEntity { get; }
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
            execute_cq("q", e);
        }

        public virtual void EventBroker_Commands(object sender, DAPCommand e)
        {
            execute_cq("c", e);
        }

        private List<PropertyInfo> GetMatchingProperties(object targetObject, object sourceObject)
        {
            var oMatchingProps = targetObject.GetType().GetProperties().Where(t =>
             sourceObject.GetType().GetProperties().Any(r => r.Name == t.Name)).ToList();
            return oMatchingProps;
        }

        private void SetMatchingPropertiesValue(List<PropertyInfo> matchingPropInfos,object targetObject, object sourceObject)
        {
            if (matchingPropInfos.Count > 0)
            {
                matchingPropInfos.ForEach(t=> {
                    var oSourceObjectData = sourceObject.GetType().GetProperty(t.Name).GetValue(sourceObject);
                    targetObject.GetType().GetProperty(t.Name).SetValue(targetObject, oSourceObjectData);
                });
            }
        }

        private void execute_cq(string sender, object e)
        {
            if (e != null)
            {
                Type eRuntime = e.GetType();
                if (eRuntime != null)
                {
                    var oAssembly = AppDomain.CurrentDomain.GetAssemblies().Single(t => t == e.GetType().Assembly);
                    if (oAssembly != null)
                    {
                        var runtimeClass = oAssembly.GetTypes().FirstOrDefault(t => t == eRuntime);
                        if (runtimeClass != null)
                        {
                            var oRuntimeObject = Activator.CreateInstance(runtimeClass);
                            if (oRuntimeObject != null)
                            {
                                oRuntimeObject.GetType().GetProperty("Target").SetValue(oRuntimeObject, this.CurrentEntity);
                                var oTarget = oRuntimeObject.GetType().GetProperty("Target").GetValue(oRuntimeObject);
                                //var oSrc= eRuntime.GetType().GetProperty("Target").GetValue(oRuntimeObject);
                                switch (sender)
                                {
                                    case "c":
                                        {
                                            MethodInfo toInvoke = oRuntimeObject.GetType().GetMethod("Execute_DAPCommand");
                                            this.SetMatchingPropertiesValue(this.GetMatchingProperties(oTarget, e),oTarget,e);
                                            toInvoke.Invoke(e, null);
                                        }
                                        break;
                                    case "q":
                                        {
                                            MethodInfo toInvoke = oRuntimeObject.GetType().GetMethod("Execute_DAPQuery");
                                            e.GetType().GetProperty("Result").SetValue(e, oTarget);
                                            toInvoke.Invoke(e, null);
                                        }
                                        break;
                                }


                            }
                        }

                    }
                }
            }
        }

    }
}
