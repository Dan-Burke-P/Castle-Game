using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Ranged", menuName="Unit/Ranged")]
public class UNIT_Ranged : BaseUnit {

	public UNIT_Ranged() {
		unitType = UnitType.Ranged;
		unitName = "Ranged";
		RNG = 2;
		DEF = 20;
		vsSoldier = 1.5f;
	}
	
	public override void attack(UnitObject attacker, UnitObject defender) {
		int dist = System.Math.Abs(defender.xPos - attacker.xPos) + System.Math.Abs(defender.yPos - attacker.yPos);
		if(dist <= RNG) {
			UnitRegistry.attackHandler.attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", attacker},
											{"Defender", defender}
											});
			attacker.AP--;
		}
	}
}
