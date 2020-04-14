using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UISystem{
    public class UnitActionDisplay : MonoBehaviour{

        public UnitActionData selection;
        
        public Text actionTitleText;
        public Text apCostText;
        public Button actionButton;
        
        /// <summary>
        /// Set the action to the passed parameters
        /// </summary>
        public void setAction(UnitTask ut){
            
            // Make sure nothing else is on the listener to avoid repeated usage
            actionButton.onClick.RemoveAllListeners();
            
            // Set the display title
            actionTitleText.text = ut.displayName;
            
            // Set the cost display of the action
            apCostText.text = $"Cost: {ut.APcost}";
            
            // Set the onclick to call back to the function 
            actionButton.onClick.AddListener(ut.ua);
        }
        
        
    }
}
