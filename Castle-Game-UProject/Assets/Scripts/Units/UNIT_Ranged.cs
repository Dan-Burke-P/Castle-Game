using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Ranged", menuName="Unit/Ranged")]
public class UNIT_Ranged : BaseUnit {

	public UNIT_Ranged() {
		unitType = UnitType.Ranged;
		unitName = "Ranged";
		RNG = 3;
		DEF = 20;
		vsSoldier = 1.5f;
	}
}
