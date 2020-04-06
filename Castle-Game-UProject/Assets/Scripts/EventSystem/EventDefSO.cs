using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem{

    /// <summary>
    /// Scriptable object version of the event definition
    /// </summary>
    [CreateAssetMenu(menuName="Debug/EventSystem/EventDefinition")]
    public class EventDefSO : ScriptableObject
    {
     
        public SysTarget sysTarget;
        public string target;
        public object caller;

    }
}