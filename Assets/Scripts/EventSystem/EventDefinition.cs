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
    public class EventDefinition : ScriptableObject
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
        /// Raise the event defined by the definition 
        /// </summary>
        /// <param name="ID">
        /// The target ID used to direct additional details to the event
        /// </param>
        public void raise(int ID){
            
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
        public void raise(int ID, object clr){
            EventBus.Instance().raiseEvent()
        }
    
        /// <summary>
        /// Register the event defined by this definition with the passed definition
        /// </summary>
        /// <param name="action">
        /// This is the action we want to be invoked by the event when it is raised
        /// </param>
        public void register(UnityAction<Dictionary<string, object>> action){
            
        }
    }
}