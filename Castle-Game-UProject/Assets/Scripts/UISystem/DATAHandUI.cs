using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="CardUI/Hand Data")]
public class DATAHandUI : ScriptableObject{
   public List<DATACardUI> cards;

   public void addCard(DATACardUI crd){
      cards.Add(crd);
   }
   
}
