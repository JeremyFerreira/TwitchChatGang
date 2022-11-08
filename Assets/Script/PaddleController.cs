using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PaddleController : MonoBehaviour
{
    public static PaddleController instance;
    [SerializeField] Transform[] PositionsY;
    [SerializeField] Transform paddleLeft;
    [SerializeField] Transform paddleRight;
    [Range(0, 7)]
    [SerializeField] int positionPaddleLeft;
    [Range(0, 7)]
    [SerializeField] int positionPaddleRight;
    [SerializeField] Vector2 posToGoRight;
    [SerializeField] Vector2 posToGoLeft;
    public float timeSinceLastMove;
    [SerializeField] float speed;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastMove < 1)
        {
            Debug.Log("yo");
            paddleLeft.transform.position = new Vector2(paddleLeft.transform.position.x, Vector2.Lerp(transform.position, posToGoLeft, timeSinceLastMove).y);
            paddleRight.transform.position = new Vector2(paddleRight.transform.position.x, Vector2.Lerp(transform.position, posToGoRight, timeSinceLastMove).y);
            timeSinceLastMove += Time.deltaTime * speed;
        }
        else
        {
            paddleLeft.transform.position = new Vector2(paddleLeft.position.x, posToGoLeft.y);
            paddleRight.transform.position = new Vector2(paddleRight.position.x, posToGoRight.y);
        }
    }
    public void ChangePosPaddleLeft(int pos)
    {
        posToGoLeft = new Vector2(paddleLeft.position.x, PositionsY[pos].position.y);
        timeSinceLastMove = 0;
    }
    public void ChangePosPaddleRight(int pos)
    {
        posToGoRight = new Vector2(paddleRight.position.x, PositionsY[pos].position.y);
        timeSinceLastMove = 0;
    }
}

