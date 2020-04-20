using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    
    /// <summary>
    /// The transform of the camera base
    /// </summary>
    public Transform trns;

    /// <summary>
    /// Arm that we will use to handle forward and backwards rotation
    /// </summary>
    public Transform rotationArm;

    /// <summary>
    /// Scalar for our rotation that will make it easier to fine tune in the options menu
    /// </summary>
    [SerializeField]
    private float _rotScaler;
    
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

    /// <summary>
    /// Clamping for the forwards and backwards rotation
    /// </summary>
    public Vector2 rotBounds;


    public float yAxisRotation = 0f;
    
    // Start is called before the first frame update
    void Start(){
        trns = gameObject.GetComponent<Transform>();
        rotationArm.Rotate(45,0,0);
        yAxisRotation += 45;
    }

    // Update is called once per frame
    void Update(){
        checkTranslation();
        checkRotation();
    }

    public void checkTranslation(){
        if (Input.mousePosition.x >= Screen.width - edgeDistance){
            // Right hand movement
            Vector3 targetPos = trns.position + trns.right * translateSpeed;
            if (targetPos.x > horzBounds.x 
                && targetPos.x < horzBounds.y
                && targetPos.z > vertBounds.x
                && targetPos.z < vertBounds.y){
                
                trns.position = targetPos;
            }
        }else if (Input.mousePosition.x <= edgeDistance){
            // Lefthand movement
            Vector3 targetPos = trns.position - trns.right * translateSpeed;
            if (   targetPos.x > horzBounds.x 
                && targetPos.x < horzBounds.y
                && targetPos.z > vertBounds.x
                && targetPos.z < vertBounds.y){
                
                trns.position = targetPos;
            }
        }
        
        if (Input.mousePosition.y >= Screen.height - edgeDistance){
            // Forward movement
            Vector3 targetPos = trns.position + trns.forward * translateSpeed;

            if (   targetPos.x > horzBounds.x 
                && targetPos.x < horzBounds.y
                && targetPos.z > vertBounds.x
                && targetPos.z < vertBounds.y){
                
                trns.position = targetPos;
            }
        }else if (Input.mousePosition.y <= edgeDistance){
            // Backward movement
            Vector3 targetPos = trns.position - trns.forward * translateSpeed;

            if (   targetPos.x > horzBounds.x 
                && targetPos.x < horzBounds.y
                && targetPos.z > vertBounds.x
                && targetPos.z < vertBounds.y){
                
                trns.position = targetPos;
            }
        }
    }

    public void checkRotation(){
        if (Input.GetKey(KeyCode.UpArrow)){
            // Rotate forward
            float rotationAmount = yAxisRotation + (rotationSpeed * _rotScaler);
            if (rotationAmount < rotBounds.y){
                rotationArm.Rotate(rotationSpeed * _rotScaler,0,0);
                yAxisRotation += (rotationSpeed * _rotScaler);

            }
        }else if(Input.GetKey(KeyCode.DownArrow)){
            // Rotate backwards
            float rotationAmount = yAxisRotation - (rotationSpeed * _rotScaler);
            if (rotationAmount > rotBounds.x){
                rotationArm.Rotate(-rotationSpeed * _rotScaler,0,0);
                yAxisRotation -= (rotationSpeed * _rotScaler);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            // Rotate to the left
            trns.Rotate(0,rotationSpeed * _rotScaler,0);
        }else if (Input.GetKey(KeyCode.RightArrow)){
            // Rotate to the right
            trns.Rotate(0,-rotationSpeed * _rotScaler,0);
        }
        
        //trns.rotation.eulerAngles.Set(0,trns.rotation.eulerAngles.y,0);
    }
    
}
