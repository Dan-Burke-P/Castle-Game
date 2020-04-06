using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class MovementHandler : MonoBehaviour
{	
	public void Start() {
		EventDefinition moveEvent = new EventDefinition(SysTarget.Unit, "UnitMovement");
		moveEvent.register(handleMovement);
	}

	public void handleMovement(Dictionary<string, object> Params, int ID, object Caller) {
		BaseUnit unit;
		object ox, oy;
		Params.TryGetValue("Unit", out unit as BaseUnit);
		Params.TryGetValue("x", out ox);
		Params.TryGetValue("y", out oy);
		unit.xPos = (ox is int ? (int) ox : 0);
		unit.yPos = (oy is int ? (int) oy : 0);
	}
}
