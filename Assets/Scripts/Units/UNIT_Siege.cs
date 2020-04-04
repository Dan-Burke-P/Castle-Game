using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNIT_Siege : BaseUnit {
	
	public UNIT_Siege() {
		unitType = UnitType.Siege;
		unitName = "Siege";
		AP = 1;
		RNG = 3;
		DEF = 25;
		vsSoldier = 0.8f;
		vsSiege = 0.8f;
		vsCavalry = 0.8f;
		vsRanged = 0.8f;
		vsMedic = 0.8f;
	}
	
	public override void attack(BaseUnit targetUnit) {
		int dist = System.Math.Abs(targetUnit.xPos - xPos) + System.Math.Abs(targetUnit.yPos - yPos);
		if(dist <= AP) {
			// raise event to be handled by attack handler
			AP--;;
		}
	}
}
