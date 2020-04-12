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

        /// <summary>
        /// This is the static instance of this class, used to invoke the non-static methods and 
        /// maintain a single instance.
        /// </summary>
        public static FInput Instance;

        /// <summary>
        /// The callbackLookup Dictionary is given an event invocation code, and stores a UnityAction for
        /// invocation.
        /// </summary>
        private Dictionary<string, UnityAction> callbackLookup;

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
        /// Called by UnityEngine when the program starts, all this does here is instantiate the FInput class.
        /// </summary>
        void Awake()
        {
            Instance = new FInput();
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
            if (!registeredKeys[code])
            {
                keysToPoll.Add(code);
                registeredKeys[code] = true;
            }
        }

        /// <summary>
        /// Register a new Input Button to be polled for input events every frame.  If the Button is
        /// already being polled, nothing will change.
        /// </summary>
        /// <param name="button">the string name of the button you wish to poll</param>
        public void RegisterButtonToPoll(string button)
        {
            if (!registeredButtons[button])
            {
                buttonsToPoll.Add(button);
                registeredButtons[button] = true;
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
        /// <param name="callback">The function to run when this event is triggered</param>
        public void RegisterCallback(string key, UnityAction callback) => callbackLookup[key] += (callback);

        /// <summary>
        /// Invokes a callback (should it exist) for a specified event key.
        /// </summary>
        /// <param name="key">the event key to try and invoke</param>
        public void ActivateCallback(string key) => callbackLookup[key]?.Invoke();

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
                    ActivateCallback("BDown:" + keysToPoll[i].ToString());
                else if (Input.GetButton(buttonsToPoll[i]))
                    ActivateCallback("BHold:" + keysToPoll[i].ToString());
                else if (Input.GetButtonUp(buttonsToPoll[i]))
                    ActivateCallback("BUp:" + keysToPoll[i].ToString());
            }
        }

        #endregion Input Polling
    }
}