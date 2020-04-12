using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitObject : MonoBehaviour
{
	
	public BaseUnit unit;
	public string unitName;
	public int ID;
	public UnitType unitType;
	public int AP, RNG;
	public float HP, ATK, DEF, CRIT, LUCK, ACC, CTR, vsSoldier, vsSiege, vsCavalry, vsRanged, vsMedic;
	public int xPos, yPos;

    void Start()
    {
        unitName = unit.unitName;
		ID = UnitRegistry.setID();
		unitType = unit.unitType;
		AP = unit.AP;
		RNG = unit.RNG;
		HP = unit.HP;
		ATK = unit.ATK;
		DEF = unit.DEF;
		CRIT = unit.CRIT;
		LUCK = unit.LUCK;
		ACC = unit.ACC;
		CTR = unit.CTR;
		vsSoldier = unit.vsSoldier;
		vsSiege = unit.vsSiege;
		vsCavalry = unit.vsCavalry;
		vsRanged = unit.vsRanged;
		vsMedic = unit.vsMedic;
		xPos = 0;
		yPos = 0;
    }
	
	void Update() {
		if (this.HP <= 0) {
			Destroy(gameObject);
		}
	}
	
	public void Move(Coord coord) {
		unit.move(this, coord.x, coord.y);
	}
	
	public void Attack(UnitObject defender) {
		unit.attack(this, defender);
	}
}
