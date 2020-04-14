using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestBoardGeneration : MonoBehaviour {

    
    public BoardSpace testBoardSpace;
    
    private string testName = "Test Board Generation";
    // Start is called before the first frame update
    void Start()
    {
        if (testBoardSpace == null) {
            Debug.LogError("Test Board Space was not attached to the test script!");
            Application.Quit();
            
            #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();      
            #endif
            
        }
    }

    private void Update(){
        if (testBoardSpace.initialized) {
            _runTests();
            
            
            Application.Quit();
            
            #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();      
            #endif
            
            Destroy(this);
        }
    }


    private void _runTests(){
        
        Debug.Log("Starting Board Space Tests!");
        
        // ReSharper disable once ReplaceWithSingleAssignment.True
        bool _passed = true;

        // Going to make a way of masking failures to adequately communicate failed tests
        //int failStatus = 0;
       
        if (!_testInitBoardSpace()) _passed = false;

        if (!_testAddUnitToBoard()) _passed = false;
        
        if (!_testGetUnitAtPos()) _passed = false;
        
        if (_passed) {
            Debug.Log(testName + ": Tests Passed" );
        }
        else {
            Debug.Log(testName + ": Tests Failed");
        }
    }

    // Runs first
    private bool _testInitBoardSpace(){
        bool _passed = true;

        if (!testBoardSpace.ToString().Equals(DTestBoardGeneration.generatedBoardSpace_EMPTY_4x4)) {
            _passed = false;
            Debug.LogError("4X4 empty board space was not generated properly");
        }
        
        
        return _passed;
    }

    // Runs second
    private bool _testAddUnitToBoard(){
        bool _passed = true;

        Dictionary<string, object> prm = new Dictionary<string, object>();
        
        prm.Add("unitData", UnitDB.UNCR_Soldier());
        prm.Add("x", 2);
        prm.Add("y", 3);

        string result = testBoardSpace.ToString();

        if (!result.Equals(DTestBoardGeneration.addedSoldierTo_x2y3_4X4)) {
            _passed = false;
            Debug.Log("add unit to board failed it's test");
        }
 
        return _passed;
    }

    private bool _testGetUnitAtPos(){
        bool _passed = true;

        BaseUnit beyondBounds = testBoardSpace.getPieceAtLoc(5,6);
        BaseUnit from_3_3 = testBoardSpace.getPieceAtLoc(3,3);
        BaseUnit from_2_3 = testBoardSpace.getPieceAtLoc(2,3);

        if (beyondBounds != null) {
            _passed = false;
            Debug.LogError("Get Unit At Pos didn't return null for out of bounds query");
        }

        if (from_2_3 == null) {
            _passed = false;
            Debug.LogError("Get Unit At Pos expected a unit back but got a null return");
        }
        else {
            if (!from_2_3.ToString().Equals("{Name: Soldier, Pos: (2,3)}")) {
                _passed = false;
                Debug.Log("Get Unit At Pos expected a certain unit back but got the wrong data");
            }
        }

        if (from_3_3 != null) {
            _passed = false;
            Debug.LogError("Get Unit At Pos expected null return for empty slot and got return");
        }
        
        
        
        return _passed;
    }
}
