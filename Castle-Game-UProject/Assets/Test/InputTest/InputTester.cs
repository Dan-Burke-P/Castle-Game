using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InputSystem 
{
    public class InputTester : MonoBehaviour
    {

        private bool toggle = false;
        private Vector2Int first, second;

        void Start()
        {
            Debug.Log(FInput.Instance);
            Debug.Log("Succesfully instantiated the input object, even though it didn't exist beforehand.");

            FInput.Instance.RegisterKeyToPoll(KeyCode.Space);
            FInput.Instance.RegisterCallback("KDown:Space", false, () =>
                {
                    if (!toggle)
                    {
                        first = FInput.Instance.MouseOverTile;
                    }
                    else
                    {
                        second = FInput.Instance.MouseOverTile;
                    }
                    toggle = !toggle;
                }
            );
        }

        void Update()
        {
            //Debug.Log("Current mouseover tile: " + FInput.Instance.MouseOverTile);
        }
    }
}