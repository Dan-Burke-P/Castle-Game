using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNIT_Ranged : BaseUnit {

	public UNIT_Ranged() {
		unitType = UnitType.Ranged;
		unitName = "Ranged";
		AP = 2;
		RNG = 2;
		vsSoldier = 1.4f;
	}
	
	public override void attack(BaseUnit targetUnit) {
		int dist = System.Math.Abs(targetUnit.xPos - xPos) + System.Math.Abs(targetUnit.yPos - yPos);
		if(dist <= AP) {
			this.attackHandler = new AttackHandler();
			this.attackHandler.attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", this},
											{"Defentder", targetUnit}
											});
			AP--;;
		}
	}
}
