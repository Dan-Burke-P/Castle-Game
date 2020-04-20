using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Siege", menuName="Unit/Siege")]
public class UNIT_Siege : UNIT_Ranged {
	
	public UNIT_Siege() {
		unitType = UnitType.Siege;
		unitName = "Siege";
		DEF = 40;
		vsSoldier = 0.8f;
		vsSiege = 0.8f;
		vsCavalry = 0.8f;
		vsRanged = 0.8f;
		vsMedic = 0.8f;
	}
}
