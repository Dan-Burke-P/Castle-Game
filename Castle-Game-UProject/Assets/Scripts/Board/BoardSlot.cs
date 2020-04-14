using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * The BoardSlot class is used to encapsulate data related to a particular location on the board
 *
 * Since the board is broken into discrete locations on a 2-d plane we can use a 2-d
 * array of board slots to represent the board in question
 *
 * this way we can store not only unit data at a location but other properties
 * such as if a piece of terrain or a building intersects this slot we can link to the
 * other slots that it occupies
 * 
 */
public class BoardSlot {

 public BaseUnit unit;
 
 public int x { get; }
 public int y { get; }

 public BoardSlot(int _x, int _y){
  x = _x;
  y = _y;
 }

 /*
  * Override the to string so we can easily parse and display this data for debugging and testing
  */
 public override string ToString(){
  string ret = "";
  ret += "{Coords: ( " + x + " , " + y + " )";

  if (unit != null) {
   ret += ", Unit: (" + unit.unitName + ")";
  }

  ret += "}";

  return ret;
 }
}
