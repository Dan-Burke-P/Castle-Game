using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.InputSystem;
using EventSystem;
using GameManagers;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class BaseUnit : ScriptableObject{

	public int ownerID;
	
    public string unitName = "Error Instantiated as a Base Unit";
	public int ID;
	public UnitType unitType = UnitType.Soldier;
	public int maxAP = 5;
	public int currAP = 5;
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

	public int attackCost = 1;
	
    public int xPos, yPos;

    public bool shouldHighlight;
    public BoardSpace boardSpace;
    public GameObject displayObject;
    public UnitDisplayObject udo;

    public List<UnitTask> actions = new List<UnitTask>();
    //public Transform transform;

  
    protected void _init(){
	    actions.Add(new UnitTask(move, "Move", 0));
		actions.Add(new UnitTask(attack, "Attack", attackCost));
	    actions.Add(new UnitTask(resetAP, "Reset AP", 0));
	    actions.Add(new UnitTask(hurtMe, "Hurt me", 1));
	    actions.Add(new UnitTask(healMe, "heal me", 2));
    }

    #region DebugAction

    public void resetAP(){
	    currAP = maxAP;
    }

    public void hurtMe(){
	    currHP -= 10;
	    onDeath();
    }

    public void healMe(){
	    currHP = maxHP;
    }
    #endregion
    

    #region TempVariables

    public bool moveMode = false;
    public bool registeredMove = false;
	public bool attackMode = false;
	public bool registeredAttack = false;
	
    #endregion
    /// <summary>
    /// Move function that will be given to the unit task for building
    /// the action list
    /// </summary>
    public void move(){
	    if (!registeredMove){
		    FInput.Instance.RegisterCallback("BDown:Fire1",false, () => {
			    if (moveMode){
				    Vector2Int location = FInput.Instance.MouseOverTile;
				    move(location);
				    moveMode = false;
				    
				    EventDefinition unitUIpanel = new EventDefinition(SysTarget.UI, "setUnitPanelData");
				    unitUIpanel.raise(0, this, new Dictionary<string, object>(){
					    {"BaseUnit", this}
				    });
			    }
		    });
		    registeredMove = true;
	    }

	    moveMode = true;
    }

    public void move(Vector2Int coordinates){
		int dist = System.Math.Abs(coordinates.x - this.xPos) + System.Math.Abs(coordinates.y - this.yPos);
        if (dist <= this.currAP && boardSpace.movePiece(new Vector2Int(xPos, yPos), coordinates)) {
		        // We succeeded a move on the board space so we can update the SO now
		        MovementHandler.Instance().moveEvent.raise(0, this, new Dictionary<string, object> {
			        {"Unit", this},
			        {"x", coordinates.x},
			        {"y", coordinates.y}
		        });
		        
		        this.currAP -= dist;
		}
    }

	public void attack(){
		
		GameMaster.Instance.selectionMode = false;
		if(!registeredAttack)
		{
			FInput.Instance.RegisterCallback("BDown:Fire1", false, () =>
			{
				if (attackMode)
				{
					BaseUnit defender = this.boardSpace.getPieceAtLoc(FInput.Instance.MouseOverTile);
					attack(defender);
					attackMode = false;

					EventDefinition unitUIpanel = new EventDefinition(SysTarget.UI, "setUnitPanelData");
					unitUIpanel.raise(0, this, new Dictionary<string, object>(){
						{"BaseUnit", this}
					});
					
					GameMaster.Instance.selectionMode = true;
				}
			});

			registeredAttack = true;
		}

		attackMode = true;
	}
	
	public void attack(BaseUnit defender) {
		if (defender.ownerID == this.ownerID)
		{
			return;
		}
		int dist = System.Math.Abs(defender.xPos - this.xPos) + System.Math.Abs(defender.yPos - this.yPos);
		if(dist <= this.RNG && this.currAP >= this.attackCost) {
			AttackHandler.Instance().attackEvent.raise(0, this, new Dictionary<string, object> {
											{"Attacker", this},
											{"Defender", defender}
											});
			this.currAP -= attackCost;
		}
	}

	public void onDeath()
	{
		if (currHP <= 0){
			udo.removeDisplayObject();
			boardSpace.removeUnitAt(xPos, yPos);
			ScriptableObject.Destroy(this);
		}
	}

    public override string ToString(){
        string ret = "";
		
        ret += "{Name: " + unitName + ", Pos: (" + xPos + "," + yPos + ")}";
        
        return ret;
    }
}
