using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseUnit : ScriptableObject {
    
    public string unitName = "Error Instantiated as a Base Unit";
	public int ID;
	public UnitType unitType = UnitType.Soldier;
	public int maxAP = 2;
	public int currAP = 2;
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

    public bool shouldHighlight;
    
    public GameObject displayObject;
    //public Transform transform;
	
	
    
    public void move(Vector2Int coordinates){
		int dist = System.Math.Abs(coordinates.x - this.xPos) + System.Math.Abs(coordinates.y - this.yPos);
        if (dist <= this.currAP /* && there IS NOT a unit on target tile */){
			MovementHandler.Instance().moveEvent.raise(0, this, new Dictionary<string, object> {
												{"Unit", this},
												{"x", coordinates.x},
												{"y", coordinates.y}
												});
			this.currAP -= dist;
		}
    }
	
	public virtual void attack(BaseUnit defender) {
		int dist = System.Math.Abs(defender.xPos - this.xPos) + System.Math.Abs(defender.yPos - this.yPos);
		if(dist <= this.currAP) {
			AttackHandler.Instance().attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", this},
											{"Defender", defender}
											});
			this.currAP -= dist;
		}
	}

    public override string ToString(){
        string ret = "";
		
        ret += "{Name: " + unitName + ", Pos: (" + xPos + "," + yPos + ")}";
        
        return ret;
    }
}
