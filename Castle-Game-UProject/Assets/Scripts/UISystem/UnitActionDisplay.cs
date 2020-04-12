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
        public void setAction(UnitActionData uad){
            actionTitleText.text = uad.actionTitle;
            apCostText.text = $"Cost: {uad.apCost}";
            actionButton.onClick.AddListener(uad.onClick);
        }
        
        
    }
}
