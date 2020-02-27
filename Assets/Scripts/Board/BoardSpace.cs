using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public GameObject unitTemplate;
    public List<SO_BaseUnit> unitData = new List<SO_BaseUnit>();
    public int boardWidth = 5, boardHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void addGamepiece(Dictionary<string, object> prms){
        object tmp;

        prms.TryGetValue("unitData", out tmp);
        
        SO_BaseUnit unitSO = tmp as SO_BaseUnit;
        
        unitData.Add(unitSO);

        Instantiate(unitTemplate);
    }
}
