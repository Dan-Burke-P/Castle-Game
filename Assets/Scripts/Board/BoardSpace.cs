using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public List<BoardPiece> pieces;
    public int boardWidth = 5, boardHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pieces != null)
        {
            // We have pieces in our board space so render them
            foreach (BoardPiece bp in pieces)
            {
                bp.t.localPosition = new Vector3(bp.x,bp.y,5);
            }
        }
    }

    void addGamepiece(BoardPiece piece)
    {
        pieces.Add(piece);
    }
}
