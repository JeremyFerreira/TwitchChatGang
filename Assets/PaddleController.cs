using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosPaddleLeft(positionPaddleLeft);
        ChangePosPaddleRight(positionPaddleRight);
    }
    public void ChangePosPaddleLeft(int pos)
    {
        paddleLeft.position = new Vector2(paddleLeft.position.x, PositionsY[pos].position.y);
    }
    public void ChangePosPaddleRight(int pos)
    {
        paddleRight.position = new Vector2(paddleRight.position.x,PositionsY[pos].position.y);
    }
}
