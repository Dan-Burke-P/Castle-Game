using UnityEngine;

namespace GameManagers{
    
    public partial class GameMaster{
        // This contains all the functions that are called when going between different phases

        #region FunctionRunners

        /// <summary>
        /// Runs the entering state function of the passed turn phase
        /// </summary>
        /// <param name="p"></param>
        private void runEnteringStateFunction(TurnPhase p){
            switch (p){
                case TurnPhase.PreTurn:
                    enteringPreTurn();
                    break;
                case TurnPhase.Renewal:
              
                    break;
                case TurnPhase.MainPhase:
              
                    break;
                case TurnPhase.Cleanup:
             
                    break;
                case TurnPhase.PrePass:
             
                    break;
            }
        }

        /// <summary>
        ///  Runs the exiting state function of the passed parameter
        /// </summary>
        /// <param name="p"></param>
        private void runExitingStateFunction(TurnPhase p){
            switch (p){
                case TurnPhase.PreTurn:
                
                    break;
                case TurnPhase.Renewal:
                
                    break;
                case TurnPhase.MainPhase:
                
                    break;
                case TurnPhase.Cleanup:
                
                    break;
                case TurnPhase.PrePass:
                
                    break;
            }
        }

        #endregion
        
        
        #region EnteringStateFunctions

        

        #endregion

        #region ExitingStateFunctions

        private void enteringPreTurn(){
            Debug.Log("Entering Preturn");
            changePlayerTurn();
            turnCount++;
        }

        #endregion
    }
}