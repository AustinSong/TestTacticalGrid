using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private int playerX;
    private int playerZ;
    private Color defaultColor;
    private GameObject[,] gameBoard;
    private int boardLength;


    private void Start()
    {
        GameController gameController = GameObject.FindGameObjectWithTag("GameBoard").GetComponent<GameController>();
        gameBoard = gameController.gameBoard;
        boardLength = gameController.boardLength;

        playerX = 0;
        playerZ = 0;
        transform.position = gameBoard[playerX, playerZ].GetComponent<Transform>().position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Moving to new X indice " + (playerX - 1));
            movePlayerPos(playerX - 1, playerZ);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Moving to new Z indice " + (playerZ + 1));
            movePlayerPos(playerX, playerZ + 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Moving to new X indice " + (playerX + 1));
            movePlayerPos(playerX + 1, playerZ);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Moving to new Z indice " + (playerZ - 1));
            movePlayerPos(playerX, playerZ - 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION_ENTER");

        defaultColor = other.GetComponent<Renderer>().material.color; 

        Renderer tempRenderer = other.gameObject.GetComponent<Renderer>();
        tempRenderer.material.color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("COLLISION_EXIT");

        other.GetComponent<Renderer>().material.color = defaultColor;
    }

    private void movePlayerPos(int newX, int newZ)
    {
        playerX = (newX >= boardLength || newX < 0) ? playerX : newX;
        Debug.Log("New playerX: " + playerX);
        playerZ = (newZ >= boardLength || newZ < 0) ? playerZ : newZ;
        Debug.Log("New playerZ: " + playerZ);

        Transform newPosTransform= gameBoard[playerX, playerZ].GetComponent<Transform>();
        transform.position = newPosTransform.position;
    }
}
