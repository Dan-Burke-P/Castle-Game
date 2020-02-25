using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTester : MonoBehaviour
{
    public EventRaiser er;

    public void raiseEvent()
    {
        Dictionary<string, object> test = new Dictionary<string, object>();
        test.Add("card", ScriptableObject.CreateInstance<CRD_SU_soldier>());
        er.Raise(test);
    }
}
