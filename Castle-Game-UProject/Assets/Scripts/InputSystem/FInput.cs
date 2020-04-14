using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.InputSystem
{
    /// <summary>
    /// This class is a Monobehaviour that will poll for input events and invoke delegate functions
    /// based on which events have been triggered.
    /// </summary>
    public class FInput : MonoBehaviour
    {
        #region Members

        private static FInput _instance;
        /// <summary>
        /// This is the static instance of this class, used to invoke the non-static methods and 
        /// maintain a single instance.
        /// </summary>
        public static FInput Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject t = new GameObject();
                    t.AddComponent<FInput>();
                    _instance = t.GetComponent<FInput>();
                }
                return _instance;
            }
        }

        /// <summary>
        /// The tile the mouse is currently hovering over - updates every frame.
        /// </summary>
        public Vector2Int MouseOverTile = new Vector2Int();


        /// <summary>
        /// The callbackLookup Dictionary is given an event invocation code, and stores a UnityAction for
        /// invocation.
        /// </summary>
        private Dictionary<string, UnityAction> callbackLookup;

        /// <summary>
        /// A dictionary to track whether or not a callback should be deregistered after a single call or not.
        /// </summary>
        private Dictionary<Delegate, bool> deregesterCallbackOptionLookup;

        // The keysToPoll and buttonsToPoll lists contain all hard input that this class will poll for new
        // events on each frame.
        private List<KeyCode> keysToPoll;
        private List<string> buttonsToPoll;

        // These dictionaries contain references to each of the keys we will be polling.  This stops duplicate keys
        // from being added to the poll list, without needing to file through the entire list every single time.
        private Dictionary<KeyCode, bool> registeredKeys;
        private Dictionary<string, bool> registeredButtons;

        #endregion Members

        #region Instantiation
        /// <summary>
        /// This function is called automatically by the unity system.  So if you attach this monobehaviour to a
        /// GameObject before running the scene, the script will be instantiated.
        /// </summary>
        void Awake()
        {
            _instance = this;
        }

        /// <summary>
        /// This private constructor for FInput only initializes all of the previously discussed lists and
        /// dictionaries.  This way we know by the time any of our member functions are called, we will not
        /// get any Null Pointer Exceptions.
        /// </summary>
        private FInput()
        {
            keysToPoll = new List<KeyCode>();
            buttonsToPoll = new List<string>();
            registeredKeys = new Dictionary<KeyCode, bool>();
            registeredButtons = new Dictionary<string, bool>();
            callbackLookup = new Dictionary<string, UnityAction>();
            deregesterCallbackOptionLookup = new Dictionary<Delegate, bool>();
        }

        #endregion Instantiation

        #region Polling Management

        /// <summary>
        /// Register a new Keyboard Key to be polled for input events every frame. If the Key is
        /// already being polled, nothing will change.
        /// </summary>
        /// <param name="code">the code for the keyboard key you wish to poll</param>
        public void RegisterKeyToPoll(KeyCode code)
        {
            if (!registeredKeys.ContainsKey(code))
            {
                registeredKeys.Add(code, true);
                keysToPoll.Add(code);
            }
            else if (!registeredKeys[code])
            {
                registeredKeys[code] = true;
                keysToPoll.Add(code);
            }
        }

        /// <summary>
        /// Register a new Input Button to be polled for input events every frame.  If the Button is
        /// already being polled, nothing will change.
        /// </summary>
        /// <param name="button">the string name of the button you wish to poll</param>
        public void RegisterButtonToPoll(string button)
        {
            if (!registeredButtons.ContainsKey(button))
            {
                registeredButtons.Add(button, true);
                buttonsToPoll.Add(button);
            }
            else if (!registeredButtons[button])
            {
                registeredButtons[button] = true;
                buttonsToPoll.Add(button);
            }
        }

        #endregion

        #region Delegate Management

        /// <summary>
        /// Adds a callback for a specified event key.  When you would like to target
        /// A specific type of event, such as a key press, be sure to use the proper preface
        /// to your event key.
        /// </summary>
        /// <param name="key">The event key for the input event you wish to target</param>
        /// <param name="auto_deregister">True if the function should only run one time</param>
        /// <param name="callback">The function to run when this event is triggered</param>
        public void RegisterCallback(string key, bool auto_deregister, UnityAction callback)
        {
            if (!callbackLookup.ContainsKey(key))
                callbackLookup.Add(key, callback);
            else
                callbackLookup[key] += callback;

            Delegate[] invocationList = callback.GetInvocationList();

            foreach (Delegate func in invocationList)
                deregesterCallbackOptionLookup.Add(func, auto_deregister);
        }

        /// <summary>
        /// Invokes a callback (should it exist) for a specified event key.
        /// </summary>
        /// <param name="key">the event key to try and invoke</param>
        public void ActivateCallback(string key)
        {
            if (callbackLookup.ContainsKey(key))
            {
                callbackLookup[key].Invoke();

                Delegate[] invocationList = callbackLookup[key].GetInvocationList();

                foreach (Delegate func in invocationList)
                    if (deregesterCallbackOptionLookup[func])
                        Delegate.Remove(callbackLookup[key], func);
            }

        }

        #endregion Delegate Management

        #region Input Polling

        /// <summary>
        /// We use 'LateUpdate' because we don't want to do this while normal components update.
        /// LateUpdate is essentially a 'between updates' function from our perspective.
        /// </summary>
        void LateUpdate()
        {
            //run through all keys to poll for input events
            for (int i = 0; i < keysToPoll.Count; i++)
            {
                if (Input.GetKeyDown(keysToPoll[i]))
                    ActivateCallback("KDown:" + keysToPoll[i].ToString());
                else if (Input.GetKey(keysToPoll[i]))
                    ActivateCallback("KHold:" + keysToPoll[i].ToString());
                else if (Input.GetKeyUp(keysToPoll[i]))
                    ActivateCallback("KUp:" + keysToPoll[i].ToString());
            }

            //run through all buttons to poll for input events
            for (int i = 0; i < buttonsToPoll.Count; i++)
            {
                if (Input.GetButtonDown(buttonsToPoll[i]))
                    ActivateCallback("BDown:" + buttonsToPoll[i].ToString());
                else if (Input.GetButton(buttonsToPoll[i]))
                    ActivateCallback("BHold:" + buttonsToPoll[i].ToString());
                else if (Input.GetButtonUp(buttonsToPoll[i]))
                    ActivateCallback("BUp:" + buttonsToPoll[i].ToString());
            }

            //mouse picking (finding where the mouse intersects the board at)
            //get a plane to represent the board (since it will always be a plane)
            Plane board = new Plane(Vector3.up, 0);
            //get a ray to represent the angle of the mouse if it were coming through the camera
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            //to store the distance to the board plane
            float distance;
            board.Raycast(r, out distance);
            //calculate the intersect position in world space
            Vector3 worldIntersect = r.origin + r.direction * distance;
            //reformulate the world intersection point to be in tile coords
            MouseOverTile = new Vector2Int((int)worldIntersect.x, (int)Math.Abs(worldIntersect.z));
        }

        #endregion Input Polling
    }
}