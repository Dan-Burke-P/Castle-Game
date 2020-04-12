using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple class used to reset built clients without having to reopen
/// </summary>
public class EscapeReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("MainMenu");
        }
    }
}
