using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{


    public GameObject[,] squares = new GameObject[10, 10];

    private int currRow;
    private int currCol;

    private int greenRow;
    private int greenCol;

    // Start is called before the first frame update
    void Start()
    {
        squares[0, 0] = GameObject.Find("Square");

        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }


                int val = 10 * j + i;
                squares[j, i] = GameObject.Find("Square " + "(" + val + ")");
                Debug.Log("Square" + "(" + val + ")");
            }
        }


        SelectTile(9, 9, 1);
        SelectTile(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer1();
        CheckPlayer2();
    }


    void SelectTile(int row, int column, int status)
    {
        var cubeRenderer = squares[row, column].GetComponent<Renderer>();
        if (status == 0)
        {
            ClearCurrentSquare();
            cubeRenderer.material.SetColor("_Color", Color.red);
            currRow = row;
            currCol = column;
        } else
        {
            ClearGreenSquare();
            cubeRenderer.material.SetColor("_Color", Color.green);
            greenRow = row;
            greenCol = column;
        }
    }


    /*
        Red player
    */
    void CheckPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if  (CheckUp(currRow, currCol))
            {
                SelectTile(currRow - 1, currCol, 0);
            }
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if  (CheckDown(currRow, currCol))
            {
                SelectTile(currRow + 1, currCol, 0);
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CheckLeft(currRow, currCol))
            {
                SelectTile(currRow, currCol - 1, 0);
            }
        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if  (CheckRight(currRow, currCol))
            {
                SelectTile(currRow, currCol + 1, 0);
            }
        }
    }


    /*
        Green player
    */
    void CheckPlayer2()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (CheckUp(greenRow, greenCol))
            {
                SelectTile(greenRow - 1, greenCol, 1);
            }
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            if  (CheckDown(greenRow, greenCol))
            {
                SelectTile(greenRow + 1, greenCol, 1);
            }
        } else if (Input.GetKeyDown(KeyCode.A))
        {
            if  (CheckLeft(greenRow, greenCol))
            {
                SelectTile(greenRow, greenCol - 1, 1);
            }
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            if (CheckRight(greenRow, greenCol))
            {
                SelectTile(greenRow, greenCol + 1, 1);
            }
        }
    }


    void ClearCurrentSquare()
    {
        var cubeRenderer = squares[currRow, currCol].GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.white);
    }


    void ClearGreenSquare()
    {
        var cubeRenderer = squares[greenRow, greenCol].GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.white);
    }


    bool CheckUp(int row, int col)
    {
        if (row > 0)
        {
            return true;
        }

        return false;
    }


    bool CheckDown(int row, int col)
    {
        if (row < 9)
        {
            return true;
        }

        return false;
    }

    bool CheckLeft(int row, int col)
    {
        if (col > 0)
        {
            return true;
        }

        return false;
    }


    bool CheckRight(int row, int col)
    {
        if (col < 9)
        {
            return true;
        }

        return false;
    }
}
