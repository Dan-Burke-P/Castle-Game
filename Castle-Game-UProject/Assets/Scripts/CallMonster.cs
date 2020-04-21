using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMonster : MonoBehaviour
{
    public GameObject[] monster;
    public GameObject[] spawnPosition;
    public GameObject[] card;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if ( Input.GetMouseButtonDown (0)){ 
    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
      if(Physics.Raycast(ray, out hit))
      {
      for (int i= 0; i<5; i++) {
      Vector3 spawningPosition=spawnPosition[i].transform.position;
      if (spawnPosition[i].GetComponent<spawnLocation>().MonsterHere ==false)
           {
           if(hit.collider.gameObject.name == "card1(Clone)"){
     
           Instantiate(monster[1], spawningPosition, Quaternion.identity);
           spawnPosition[i].GetComponent<spawnLocation>().MonsterHere=true;
           Destroy(hit.collider.gameObject,0);
            break;
          }

           else if (hit.collider.gameObject.name == "card2(Clone)")
           {

            Instantiate(monster[0], spawningPosition, Quaternion.identity);
              spawnPosition[i].GetComponent<spawnLocation>().MonsterHere=true;
           Destroy(hit.collider.gameObject,0);
            break;
		   }
         }
           }
           }
           }
	
        
    }
}
