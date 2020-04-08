using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class MovementHandler : MonoBehaviour
{	

	public EventDefinition moveEvent;

	public void Start() {
		moveEvent = new EventDefinition(SysTarget.Unit, "UnitMovement", this);
		moveEvent.register(handleMovement);
	}

	public void handleMovement(Dictionary<string, object> Params, int ID, object Caller) {
		object unitObj;
		object ox, oy;
		Params.TryGetValue("Unit", out unitObj);
		BaseUnit unit = unitObj as BaseUnit;
		Params.TryGetValue("x", out ox);
		Params.TryGetValue("y", out oy);
		unit.xPos = (ox is int ? (int) ox : 0);
		unit.yPos = (oy is int ? (int) oy : 0);
	}
}
