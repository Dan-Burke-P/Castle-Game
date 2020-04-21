using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCard : MonoBehaviour
{
    public GameObject[] card;
    public GameObject[] placeHolder;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    
   
      //get position of card to jam in position of placeHolder;   
    }
    void OnMouseDown(){
    if(Input.GetMouseButtonDown(0)){
    
    GameObject[] CardDestroys = GameObject.FindGameObjectsWithTag("CardDestroy");

        foreach (GameObject cardDestroy in CardDestroys)
        {
            Destroy(cardDestroy,0);
        }
	
    for(int i=0; i<6;i++){
    Vector3 placeHolderPosition=placeHolder[i].transform.position;
    int r=Random.Range(0,2);
    Instantiate(card[r], placeHolderPosition, Quaternion.identity);
    }
	}
    
	}
}
