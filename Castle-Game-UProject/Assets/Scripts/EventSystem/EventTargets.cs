using System.Collections.Generic;
using UnityEngine.Events;


// An event target for being specific in a registered event
namespace EventSystem{
    public class EventTargets
    {
        public string targetName;

        private UnityAction<Dictionary<string, object>, int, object> callStack;

        private int eventCount = 0;

        public int getEventCount(){
            return eventCount;
        }
        public void addCallback(UnityAction<Dictionary<string, object>, int, object> ua){
            callStack += ua;
            eventCount++;
        }

        public void removeCallBack(UnityAction<Dictionary<string, object>, int, object> ua){
            callStack -= ua;
            eventCount--;
            if (callStack == null){
                eventCount = 0;
            }
        }


    
        public void invoke(Dictionary<string, object> prms, int ID, object cllr){
            callStack(prms, ID, cllr);
        }

        public override string ToString(){
            return targetName;
        }
    }
}