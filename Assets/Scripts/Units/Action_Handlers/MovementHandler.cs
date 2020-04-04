using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{	
	public static void moveUnit(BaseUnit unit, int xTarget, int yTarget) {
		unit.xPos = xTarget;
		unit.yPos = yTarget;
	}
}
