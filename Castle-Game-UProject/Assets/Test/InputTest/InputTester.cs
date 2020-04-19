using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InputSystem 
{
    public class InputTester : MonoBehaviour
    {

        public Text text;
        public Transform selectionCube;

        void Start()
        {
            Debug.Log(FInput.Instance);
            Debug.Log("Succesfully instantiated the input object, even though it didn't exist beforehand.");

            FInput.Instance.RegisterKeyToPoll(KeyCode.Space);

            FInput.Instance.RegisterCallback("KDown:Space", true, () =>
                {
                    Debug.LogError("This function should only run once");
                }
            );
            FInput.Instance.RegisterCallback("MDown:Primary", false, () =>
                {
                    Debug.LogWarning("This other function ran, updating text!");
                    text.text = "MouseIsOverBoard: " + FInput.Instance.IsMouseOverBoard + "\nMouseHoverTile: " + FInput.Instance.MouseOverTile;
                }
            );
        }

        void Update()
        {
            Vector3 newPos = new Vector3(0.5f + FInput.Instance.MouseOverTile.x, 0f, -0.5f - FInput.Instance.MouseOverTile.y);
            selectionCube.position = newPos;
        }
    }
}