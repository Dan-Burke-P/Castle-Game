using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class AttackHandler : MonoBehaviour
{
	
	public void Start() {
		EventDefinition attackEvent = new EventDefinition(SysTarget.Unit, "UnitAttack");
		attackEvent.register(handleAttack);
	}

	public void handleAttack(Dictionary<string, object> Params, int ID, object Caller) {
		BaseUnit attacker, defender;
		Params.TryGetValue("attacker", out attacker as BaseUnit);
		Params.TryGetValue("defender", out defender as BaseUnit);
		
		// Damage calculation
		defender.HP -= calculateDamage(attacker, defender);
		
		if (defender.HP <= 0) {
			// TO DO: Remove defending unit from the field
			// Check if unit is ranged
			switch (attacker.unitType) {
				case UnitType.Ranged:
					break;
				case UnitType.Siege:
					break;
				default:
					// TO DO: Raise event to be handled by movement handler for non-ranged units
					break;
			}
			return;
		}
		
		// Check to see if the defender gets a counter attack
		System.Random counterDice = new System.Random();
		int counterRoll = counterDice.Next(0,100);
		if (counterRoll >= 100 - defender.CTR * 100) {
			attacker.HP -= calculateDamage(defender, attacker); 
		}
		
		if (attacker.HP <= 0) {
			// TO DO: Remove attacking unit from the field
			return;
		}
	}

	private static float typeModifier(BaseUnit caster, BaseUnit target) {
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
	
	private static float critMultiplier(BaseUnit caster) {
		System.Random critDice = new System.Random();
		int critRoll = critDice.Next(0,100);
		if (critRoll >= 100 - caster.CRIT * 100) {
			return 1.3f;
		}
		if (critRoll < 100 - caster.ACC) {
			return 0.7f;
		}
		return 1.0f;
	}
	
	private static float calculateDamage(BaseUnit caster, BaseUnit target) {
		return (caster.ATK - target.DEF) * typeModifier(caster, target) * critMultiplier(caster);
	}

}
