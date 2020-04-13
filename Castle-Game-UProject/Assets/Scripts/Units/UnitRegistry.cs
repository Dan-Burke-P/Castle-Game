using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRegistry
{
	public static int nextID = 0;
	
	public static int setID() {
		int ID = nextID;
		nextID++;
		return ID;
	}
}
