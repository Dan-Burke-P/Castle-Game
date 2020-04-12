using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class AttackHandler
{
	public EventDefinition attackEvent;
	private static System.Random dice;
	
	public AttackHandler() {
		attackEvent = new EventDefinition(SysTarget.Unit, "UnitAttack", this);
		attackEvent.register(handleAttack);
		dice = new System.Random();
	} 

	public void handleAttack(Dictionary<string, object> Params, int ID, object Caller) {
		object attackerObj, defenderObj;
		Params.TryGetValue("Attacker", out attackerObj);
		UnitObject attacker = attackerObj as UnitObject;
		Params.TryGetValue("Defender", out defenderObj);
		UnitObject defender = defenderObj as UnitObject;
		
		// Damage calculation
		Debug.Log(attacker.unitName + " makes an attack on " + defender.unitName + "...");
		float damage = calculateDamage(attacker, defender);
		Debug.Log(defender.unitName + " takes " + damage + " points of damage.");
		if (damage > defender.HP) {
			if(attacker.RNG == 1) {
				UnitRegistry.movementHandler.moveEvent.raise(0, this, new Dictionary<string, object> {
												{"Unit", attacker},
												{"x", defender.xPos},
												{"y", defender.yPos}
												});
			}
			Debug.Log(defender.unitName + " dies in battle.");
			defender.HP = 0;
			return;
		}
		defender.HP -= damage;
		
		// Check to see if the defender gets a counter attack
		int counterRoll = dice.Next(0,100);
		if (counterRoll >= 100 - defender.CTR * 100) {
			Debug.Log(defender.unitName + " makes a counter attack...");
			damage = calculateDamage(defender, attacker);
			attacker.HP -= damage;
			Debug.Log(attacker.unitName + " takes " + damage + " points in damage.");
		}
		
		if (attacker.HP <= 0) {
			Debug.Log(attacker.unitName + " dies in battle.");
			return;
		}
	}

	private static float typeModifier(UnitObject caster, UnitObject target) {
		switch (target.unitType) {
			case UnitType.Soldier:
				return caster.vsSoldier;
			case UnitType.Siege:
				return caster.vsSiege;
			case UnitType.Cavalry:
				return caster.vsCavalry;
			case UnitType.Ranged:
				return caster.vsRanged;
			case UnitType.Medic:
				return caster.vsMedic;
			default:
				return 1.0f;
		}
	}
	
	private static float critMultiplier(UnitObject caster) {
		int critRoll = dice.Next(0,100);
		if (critRoll >= 100 - caster.LUCK * 100) {
			Debug.Log("Critical Hit!");
			return caster.CRIT;
		}
		if (critRoll < 100 - caster.ACC * 100) {
			Debug.Log("Glancing Blow!");
			return 0.7f;
		}
		return 1.0f;
	}
	
	private static float calculateDamage(UnitObject caster, UnitObject target) {
		return (caster.ATK - target.DEF) * typeModifier(caster, target) * critMultiplier(caster);
	}

}
