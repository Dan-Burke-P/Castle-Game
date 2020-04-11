using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem{
    /// <summary>
    /// Holds a list of events registered within a given system
    /// </summary>
    public class SystemEventList {

        /// <summary>
        /// The enum for the system we are targeting
        /// </summary>
        public SysTarget systemTarget;
        
        private Dictionary<string, EventTargets> subTargets = new Dictionary<string, EventTargets>();

        // Constructor
        public SystemEventList(SysTarget ST){
            systemTarget = ST;
        }
     
        /// <summary>
        /// Registers a target within the system
        /// </summary>
        /// <param name="targetName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public int registerTarget(string targetName, UnityAction<Dictionary<string, object>, int, object>  action){

            Debug.Log("Adding target to action");
            EventTargets et;
            if (subTargets.TryGetValue(targetName, out et)){
                // We succeeded in finding the event target specified 
                et.addCallback(action);
                return 0;
            }
            else{
                // We didn't find the target so make a new one and register it to this event
                Debug.Log("Didn't find target so adding new target");
                et = new EventTargets();
                et.targetName = targetName;
                et.addCallback(action);
                
                subTargets.Add(targetName, et);
                return 1;
            }
        }

        public int RaiseTarget(string trg,int ID,object caller , Dictionary<string, object> prms){
            
            EventTargets et;
            if (subTargets.TryGetValue(trg, out et)){
                // We succeeded in finding the event target specified
                et.invoke(prms, ID, caller);
                return 0;
            }
            return -1; 
        }

        public int deregisterEvent(string targetName, UnityAction<Dictionary<string, object>, int, object>  action){
            Debug.Log("Removing target from action");
            EventTargets et;
            if (subTargets.TryGetValue(targetName, out et)){
                // We succeeded in finding the event target specified 
                et.removeCallBack(action);
                if (et.getEventCount() < 1){
                    subTargets.Remove(targetName);
                }
                return 0;
            }
            else{
                // We didn't find the target so make a new one and register it to this event
                Debug.Log("Didn't find target to remove");
                return 1;
            }
        }

        public override string ToString(){
            string ret = systemTarget.ToString() + "{\n";
            foreach (EventTargets et in subTargets.Values){
                ret += et.ToString() + " | EventCount: " + et.getEventCount();
                ret += "\n";
            }

            ret += "}";
            return ret;
        }
    }
    
}
