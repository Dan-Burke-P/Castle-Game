using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNIT_Cavalry : BaseUnit {
	
	public UNIT_Cavalry() {
		unitType = UnitType.Cavalry;
		unitName = "Cavalry";
		AP = 3;
		vsRanged = 1.4f;
	}
}
