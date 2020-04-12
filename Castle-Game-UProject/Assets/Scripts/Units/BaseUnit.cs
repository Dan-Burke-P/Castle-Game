using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : ScriptableObject {
    
    public string unitName = "Error Instantiated as a Base Unit";
	public UnitType unitType = UnitType.Soldier;
	public int AP = 2;
	public int RNG = 1;
	public float HP = 100;
	public float ATK = 50;
	public float DEF = 15;
	public float CRIT = 0.15f;
	public float ACC = 0.95f;
	public float CTR = 0.3f;
	public float vsSoldier = 1.0f;
	public float vsSiege = 1.0f;
	public float vsCavalry = 1.0f;
	public float vsRanged = 1.0f;
	public float vsMedic = 1.0f;
	
    public int xPos, yPos;
	
	public AttackHandler attackHandler;
	public MovementHandler movementHandler;

    public GameObject obj;
    public Transform transform;
	
	
    
    public void move(int x, int y){
		int dist = System.Math.Abs(x - xPos) + System.Math.Abs(y - yPos);
        if (dist <= AP /* && there IS NOT a unit on target tile */){
			movementHandler = new MovementHandler();
			movementHandler.moveEvent.raise(0, this, new Dictionary<string, object> {
												{"Unit", this},
												{"x", x},
												{"y", y}
												});
			AP -= dist;
		}
    }
	
	public virtual void attack(BaseUnit targetUnit) {
		int dist = System.Math.Abs(targetUnit.xPos - xPos) + System.Math.Abs(targetUnit.yPos - yPos);
		if(dist <= AP) {
			attackHandler = new AttackHandler();
			attackHandler.attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", this},
											{"Defentder", targetUnit}
											});
			AP -= dist;
		}
	}

    public override string ToString(){
        string ret = "";
		
        ret += "{Name: " + unitName + ", Pos: (" + xPos + "," + yPos + ")}";
        
        return ret;
    }
}
