using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Cavalry", menuName="Unit/Cavalry")]
public class UNIT_Cavalry : BaseUnit {
	
	public UNIT_Cavalry() {
		unitType = UnitType.Cavalry;
		unitName = "Cavalry";
		maxAP = 3;
		currAP = 3;
		vsRanged = 1.5f;
	}
}
