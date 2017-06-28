using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject mapTile;
    public int boardLength;
    public GameObject[,] gameBoard;

	// Use this for initialization
	void Awake() {
        gameBoard = new GameObject[boardLength,boardLength];
        CreateGrid();
	}

    void CreateGrid()
    {
        float distanceBetweenTiles = 1f;
        float tileBorder = .01f;

        for(int i = 0; i < boardLength; i++)
        {
            for(int j = 0; j < boardLength; j++)
            {
                Vector3 currentPos = new Vector3(transform.position.x + (i+tileBorder), transform.position.y, transform.position.z + (j + distanceBetweenTiles));
                gameBoard[i,j] = Instantiate(mapTile, currentPos, Quaternion.identity);
                gameBoard[i, j].transform.parent = this.transform; 
            }
        }
    }
}
