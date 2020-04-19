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
            // Ensuring that the FInput instance either exists, or can be created.
            Debug.Log(FInput.Instance);
            // If we've made it this far, we can print a success message to the console.
            Debug.Log("Succesfully instantiated the input object, even though it didn't exist beforehand.");

            // So below I will show how to register an input callback for when the Space key is pressed.
            // First we have to tell the input system to poll the Space Key for events:
            FInput.Instance.RegisterKeyToPoll(KeyCode.Space);
            // Now we have to assign a function (or callback) that we want to run when a specific event triggers.
            // Since we are polling for events on the Space key, we can get an event when the Space Key is pressed.
            // For this we use the event code "KDown" for key down.  There are also KHold and KUp events.
            // It is also important to note the function has a boolean as the second argument.  This is the auto-deregister bool.
            // Essentially what this means is: when true, the function will only run the next time this event triggers - and never again.
            // if the bool is false, the function will run for every single time this event happens.
            FInput.Instance.RegisterCallback("KDown:Space", true, () =>
                {   // what we choose to do only a single time (when space key is pressed) is LogError a message.
                    Debug.LogError("This function should only run once");
                }
            );
            // Now you can also register Buttons to poll (buttons being defined in Unity->Edit->Project Settings->Input Manager).
            // If you'd like to register a button (not a key!) use: FInput.Instance.RegisterButtonToPoll("<axis_name>");

            // It is also important to note that the mouse input does not need special instructions for the input system to poll it.
            // In other words, the Input system is ALWAYS polling the mouse buttons for events.
            // To take advantage of this, we can set up a callback for when the primary mouse button is pressed down.
            // Note: The auto-deregister bool is false - so this function will run for every click after its registered.
            FInput.Instance.RegisterCallback("MDown:Primary", false, () =>
                {   // The first thing we choose to do is LogWarning a message.
                    Debug.LogWarning("This other function ran, updating text!");
                    // Next we will update some UI Text using public data from the FInput Instance.
                    text.text = "MouseIsOverBoard: " + FInput.Instance.IsMouseOverBoard + "\nMouseHoverTile: " + FInput.Instance.MouseOverTile;
                }
            );
        }

        void Update()
        {
            // The public data we can get from the FInput instance is updated every frame during the LateUpdate() function.
            // Therefore the data is always updated in between frames, and will never effect the games current update.

            // To demo the capability of this, we have can calculate the centerpoint of the tile our mouse is currently hovering over
            // on the game board.
            Vector3 newPos = new Vector3(0.5f + FInput.Instance.MouseOverTile.x, 0f, -0.5f - FInput.Instance.MouseOverTile.y);
            // then (if we are actually hovering over the board) we can update a selection cube's transform, to mirror the 
            // location of the mouse.
            // NOTE: The selectionCube DOES NOT HAVE A COLLIDER!  I.e. we do NOT want the mouse to recognize interactions with the
            // selection cube object.
            if (FInput.Instance.IsMouseOverBoard) selectionCube.position = newPos;
        }
    }
}