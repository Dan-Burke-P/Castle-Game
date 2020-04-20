using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class AttackHandler
{
	private static readonly AttackHandler instance = new AttackHandler();
	public EventDefinition attackEvent;
	private static System.Random dice;
	
	public AttackHandler() {
		attackEvent = new EventDefinition(SysTarget.Unit, "UnitAttack", this);
		attackEvent.register(HandleAttack);
		dice = new System.Random();
	}

	public static AttackHandler Instance()
	{
		return instance;
	}

	public void HandleAttack(Dictionary<string, object> Params, int ID, object Caller) {
		object attackerObj, defenderObj;
		Params.TryGetValue("Attacker", out attackerObj);
		BaseUnit attacker = attackerObj as BaseUnit;
		Params.TryGetValue("Defender", out defenderObj);
		BaseUnit defender = defenderObj as BaseUnit;
		
		// Damage calculation
		Debug.Log(attacker.unitName + " makes an attack on " + defender.unitName + "...");
		float damage = CalculateDamage(attacker, defender);
		Debug.Log(defender.unitName + " takes " + damage + " points of damage.");
		if (damage >= defender.currHP) {
			if(attacker.RNG == 1) {
				MovementHandler.Instance().moveEvent.raise(0, this, new Dictionary<string, object> {
												{"Unit", attacker},
												{"x", defender.xPos},
												{"y", defender.yPos}
												});
			}
			Debug.Log(defender.unitName + " dies in battle.");
			defender.currHP = 0;
			defender.onDeath();
			return;
		}
		defender.currHP -= damage;
		
		// Check to see if the defender gets a counter attack
		int counterRoll = dice.Next(0,100);
		if (counterRoll >= 100 - defender.CTR * 100) {
			Debug.Log(defender.unitName + " makes a counter attack...");
			damage = CalculateDamage(defender, attacker);
			Debug.Log(attacker.unitName + " takes " + damage + " points in damage.");
			if (damage >= attacker.currHP)
			{
				Debug.Log(attacker.unitName + " dies in battle.");
				attacker.currHP = 0;
				attacker.onDeath();
				return;
			}
			attacker.currHP -= damage;
		}
	}

	private static float TypeModifier(BaseUnit caster, BaseUnit target) {
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
	
	private static float CritMultiplier(BaseUnit caster) {
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
	
	private static float CalculateDamage(BaseUnit caster, BaseUnit target) {
		return (caster.ATK - target.DEF) * TypeModifier(caster, target) * CritMultiplier(caster);
	}

}
