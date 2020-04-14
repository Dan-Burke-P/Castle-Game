using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PromptObjectController : MonoBehaviour{

    public GameObject responsePanel;

    public Button _yes, _no;
    public Text _questionString;
    
    public void getResponse(UnityAction yes, UnityAction no, string question){
        responsePanel.SetActive(true);
        _yes.onClick.AddListener(yes);
        _yes.onClick.AddListener(resetPanel);
        
        _no.onClick.AddListener(no);
        _no.onClick.AddListener(resetPanel);

        _questionString.text = question;
    }

    public void resetPanel(){
        _yes.onClick.RemoveAllListeners();
        _no.onClick.RemoveAllListeners();
        responsePanel.SetActive(false);
    }
}
