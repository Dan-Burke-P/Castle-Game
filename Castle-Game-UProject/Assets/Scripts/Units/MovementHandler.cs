using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class MovementHandler
{
	private static readonly MovementHandler instance = new MovementHandler();
	public EventDefinition moveEvent;

	public MovementHandler() {
		moveEvent = new EventDefinition(SysTarget.Unit, "UnitMovement", this);
		moveEvent.register(handleMovement);
	}

	public static MovementHandler Instance()
	{
		return instance;
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
		Debug.Log("New coordinates are x=" + unit.xPos + ", y=" + unit.yPos + ".");
	}
}
