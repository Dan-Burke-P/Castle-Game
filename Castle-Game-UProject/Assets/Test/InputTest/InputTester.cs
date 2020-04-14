using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputSystem 
{
    public class InputTester : MonoBehaviour
    {

        void Start()
        {
            Debug.Log(FInput.Instance);
            Debug.Log("Succesfully instantiated the input object, even though it didn't exist beforehand.");

            FInput.Instance.RegisterKeyToPoll(KeyCode.Space);
            FInput.Instance.RegisterCallback("KDown:Space", true, () =>
                {
                    Debug.Log("The function ran");
                }
            );
        }

        void Update()
        {
            //Debug.Log("Current mouseover tile: " + FInput.Instance.MouseOverTile);
        }
    }
}