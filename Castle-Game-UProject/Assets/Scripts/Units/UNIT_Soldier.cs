using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName="Soldier", menuName="Unit/Soldier")]
public class UNIT_Soldier : BaseUnit {

    public UNIT_Soldier() {
        unitName = "Soldier";
		vsSiege = 1.5f;
    }
}
