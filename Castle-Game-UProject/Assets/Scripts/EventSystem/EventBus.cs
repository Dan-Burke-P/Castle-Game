using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventSystem {
        
    public class EventBus
    {
        
        // Use singleton design so we can centralize how we register events to a single back bone component
        private static EventBus _instance;

        /// <summary>
        /// A dictionary defining our system event lists keyed to their enums
        /// </summary>
        public Dictionary<SysTarget ,SystemEventList> SystemEvents = new Dictionary<SysTarget, SystemEventList>();   
        
        /// <summary>
        /// Tracker to check that the event system is initialized before using it
        /// </summary>
        public bool initialized = false;
        
        // Make sure we private the constructor to avoid other instances being made errantly 
        private EventBus(){
            _initSystemList();
        }

        /// <summary>
        /// Initialize our SystemList 
        /// </summary>
        private void _initSystemList(){
            // Iterate through each member of our enum
            foreach (SysTarget st in Enum.GetValues(typeof(SysTarget))){
                SystemEventList tmp = new SystemEventList(st);
                SystemEvents.Add(st, tmp);
            }
        }
        public static EventBus Instance(){
            if (_instance == null){
                _instance = new EventBus();
                return _instance;
            }
            else{
                return _instance;
            }
        }

        /// <summary>
        /// Registers an event to the event system 
        /// </summary>
        /// <param name="ed">
        /// The event definition we want to associate with the event 
        /// </param>
        /// <param name="action">
        /// The action we want to attach to the event definition 
        /// </param>
        /// <returns></returns>
        public int RegisterEvent(EventDefinition ed, UnityAction<Dictionary<string, object>, int, object> action){
            SystemEvents[ed.sysTarget].registerTarget(ed.target, action);
            return 0;
        }

        public int DeRegisterEvent(EventDefinition ed, UnityAction<Dictionary<string, object>, int, object> action){
            SystemEvents[ed.sysTarget].deregisterEvent(ed.target, action);
            return 0;
        }
    
        /// <summary>
        /// Create a new system and store it in our system dictionary
        /// </summary>
        /// <param name="SysTrg">
        /// The system we want to create
        /// </param>
        /// <returns>
        /// success status
        /// </returns>
        private int _createNewSystem(SysTarget SysTrg){

            if (SystemEvents.ContainsKey(SysTrg)) {
                Debug.LogError(
                    "Attempted to create a system in the event bus that already got registered");
                return -1;
            }
            else {
                SystemEvents.Add(SysTrg, new SystemEventList(SysTrg));
            }
            return 0;
        }

        /// <summary>
        /// Raises an event in the requested system targeting the passed target
        /// </summary>
        /// <param name="ID">
        /// The ID used to strictly define the target
        /// </param>
        /// <param name="caller">
        /// Reference to the object that raised the event
        /// </param>
        /// <param name="prm">
        /// The parameters we want to pass to the object
        /// </param>
        /// <param name="sys">
        /// The system we want the event to go to
        /// </param>
        /// <param name="trg">
        /// The target in the system we want to target
        /// </param>
        /// <returns>
        /// The status of the event
        /// </returns>
        public int raiseEvent(SysTarget sys,string trg,int ID,
            object caller ,Dictionary<string, object> prm){

            SystemEvents[sys].RaiseTarget(trg, ID, caller, prm);
            
            return 0;
        }

        /// <summary>
        /// For debug purposes, create a string representation of the event system
        /// </summary>
        /// <returns></returns>
        public string getEventSystemString(){

            string ret = "";

            foreach (SystemEventList se in SystemEvents.Values){
                ret += se.ToString();
                ret += "\n";
            }
            
            return ret;


        }
    }   
}