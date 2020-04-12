using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
	UnitObject unit;
	
    // Start is called before the first frame update
    void Start()
    {
        unit = gameObject.GetComponent<UnitObject>();
    }

    // Update is called once per frame
    void Update()
    {
		
		Vector3 temp = new Vector3((float) unit.xPos + 0.5f, 0.6f, (float) unit.yPos - 0.5f);
        transform.position = temp;
    }
}
