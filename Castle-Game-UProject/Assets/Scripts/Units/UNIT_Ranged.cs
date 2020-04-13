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
	
	public override void attack(BaseUnit defender) {
		int dist = System.Math.Abs(defender.xPos - this.xPos) + System.Math.Abs(defender.yPos - this.yPos);
		if(dist <= RNG) {
			AttackHandler.Instance().attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", this},
											{"Defender", defender}
											});
			this.currAP--;
		}
	}
}
