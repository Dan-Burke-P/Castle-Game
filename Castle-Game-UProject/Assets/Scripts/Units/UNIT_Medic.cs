using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Medic", menuName="Unit/Medic")]
public class UNIT_Medic : BaseUnit
{
	
	public UNIT_Medic() {
		unitType = UnitType.Medic;
		unitName = "Medic";
		vsSoldier = -1.0f;
		vsSiege = 0f;
		vsCavalry = -1.0f;
		vsMedic = -1.0f;
	}
}
