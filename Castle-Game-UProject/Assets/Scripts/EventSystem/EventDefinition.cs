using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem {
    
    /// <summary>
    /// This class represents a definition of an event
    /// It will include the details about the target system
    /// and the sub target inside of the system
    /// </summary>
    // Defines an actual event
    public class EventDefinition
    {
        public SysTarget sysTarget;
        public string target;
        public object caller;
        
        public EventDefinition(){
            
        }

        /// <summary>
        /// Used for constructing an event definition with passed parameters
        /// </summary>
        /// <param name="ST">
        /// System we want to target
        /// </param>
        /// <param name="ET">
        /// The target inside the event name
        /// </param>
        /// <param name="clr">
        /// This is a reference to the object that raised the event
        /// </param>
        public EventDefinition(SysTarget ST, string ET, object clr){
            sysTarget = ST;
            target = ET;
            caller = clr;
        }
        
        /// <summary>
        /// Used for constructing an event definition with passed parameters
        /// </summary>
        /// <param name="ST">
        /// System we want to target
        /// </param>
        /// <param name="ET">
        /// The target inside the event name
        /// </param>
        public EventDefinition(SysTarget ST, string ET){
            sysTarget = ST;
            target = ET;
            caller = null;
        }
        
        /// <summary>
        /// Raise the event defined by the definition 
        /// </summary>
        /// <param name="ID">
        /// The target ID used to direct additional details to the event
        /// </param>
        /// <param name="clr">
        /// Overrides the caller in the event call
        /// </param>
        /// <param name="prms">
        /// The parameter dictionary passed to the event
        /// </param>
        public void raise(int ID, object clr, Dictionary<String, object> prms){
            EventBus.Instance().raiseEvent(sysTarget, target, ID, clr, prms);
        }
        
        /// <summary>
        /// Raise the event defined by the definition, uses internally set object to save "this" keyword usage for
        /// repeated event calls
        /// </summary>
        /// <param name="ID">
        /// The target ID used to direct additional details to the event
        /// </param>
        /// <param name="prms">
        /// The parameter dictionary passed to the event
        /// </param>
        public void raise(int ID, Dictionary<String, object> prms){
            EventBus.Instance().raiseEvent(sysTarget, target, ID, caller,  prms);
        }
    
        /// <summary>
        /// Register the event defined by this definition with the passed definition
        /// </summary>
        /// <param name="action">
        /// This is the action we want to be invoked by the event when it is raised
        /// </param>
        public void register(UnityAction<Dictionary<string, object>, int, object> action){
            EventBus.Instance().RegisterEvent(this, action);
        }

        public void deregister(UnityAction<Dictionary<string, object>, int, object> action){
            EventBus.Instance().DeRegisterEvent(this, action);
        }
    }
}