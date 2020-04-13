using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputSystem {
    public class InputTester : MonoBehaviour
    {
        void Start()
        {
            Debug.Log(FInput.Instance);
            Debug.Log("Succesfully instantiated the input object, even though it didn't exist beforehand.");
        }

        void Update()
        {
            Debug.Log("Current mouseover tile: " + FInput.Instance.MouseOverTile);
        }
    }
}