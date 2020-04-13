using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseUnit : ScriptableObject {
    
    public string unitName = "Error Instantiated as a Base Unit";
	public UnitType unitType = UnitType.Soldier;
	public int AP = 2;
	public int RNG = 1;
	public float maxHP = 100;
	public float currHP = 100;
	public float ATK = 50;
	public float DEF = 25;
	public float CRIT = 1.35f;
	public float LUCK = 0.15f;
	public float ACC = 0.95f;
	public float CTR = 0.3f;
	public float vsSoldier = 1.0f;
	public float vsSiege = 1.0f;
	public float vsCavalry = 1.0f;
	public float vsRanged = 1.0f;
	public float vsMedic = 1.0f;
	
    public int xPos, yPos;

    public GameObject displayObject;
    //public Transform transform;
	
	
    
    public void move(UnitObject unit, int x, int y){
		int dist = System.Math.Abs(x - xPos) + System.Math.Abs(y - yPos);
        if (dist <= unit.AP /* && there IS NOT a unit on target tile */){
			UnitRegistry.movementHandler.moveEvent.raise(0, this, new Dictionary<string, object> {
												{"Unit", unit},
												{"x", x},
												{"y", y}
												});
			unit.AP -= dist;
		}
    }
	
	public virtual void attack(UnitObject attacker, UnitObject defender) {
		int dist = System.Math.Abs(defender.xPos - attacker.xPos) + System.Math.Abs(defender.yPos - attacker.yPos);
		if(dist <= attacker.AP) {
			UnitRegistry.attackHandler.attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", attacker},
											{"Defender", defender}
											});
			attacker.AP -= dist;
		}
	}

    public override string ToString(){
        string ret = "";
		
        ret += "{Name: " + unitName + ", Pos: (" + xPos + "," + yPos + ")}";
        
        return ret;
    }
}
