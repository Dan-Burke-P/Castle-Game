using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    
    /// <summary>
    /// The transform of the camera base
    /// </summary>
    public Transform trns;

    /// <summary>
    /// How fast do we want translation to occur
    /// </summary>
    public float translateSpeed;

    /// <summary>
    /// How fast do we want rotation to occur
    /// </summary>
    public float rotationSpeed;

    /// <summary>
    /// How big of an edge do we want to hit
    /// </summary>
    public float edgeDistance = 10f;

    /// <summary>
    /// Defines how far we should allow the camera to move before it hits the border
    /// </summary>
    public Vector2 horzBounds;

    /// <summary>
    /// Defines how far the camera can move vertically until it hits the border
    /// </summary>
    public Vector2 vertBounds;
    // Start is called before the first frame update
    void Start(){
        trns = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update(){
        checkTranslation();
        checkRotation();
    }

    public void checkTranslation(){
        if (Input.mousePosition.x >= Screen.width - edgeDistance){
            trns.position += trns.right * translateSpeed;
        }else if (Input.mousePosition.x <= edgeDistance){
            trns.position -= trns.right * translateSpeed;
        }else if (Input.mousePosition.y >= Screen.height - edgeDistance){
            trns.position += trns.forward * translateSpeed;
        }else if (Input.mousePosition.y <= edgeDistance){
            trns.position -= trns.forward * translateSpeed;
        }
    }

    public void checkRotation(){
        
    }
    
}
