using System;
using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PinboardController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] cards;

    private int moveMult = 245;

    [SerializeField]
    private float xMin, xMax,
        yMin, yMax;

    private int currGridX = 0, currGridY = 0;


    public enum ControllerLock
    {
        LOCKED,
        UNLOCKED
    };

    public ControllerLock boardlock;

    private UnityEngine.Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allConnections();
        boardlock = ControllerLock.UNLOCKED;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (boardlock == ControllerLock.UNLOCKED){
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");

            MoveBoard();

            if (Input.GetKeyDown("space") && ValidGridSpace()){
                // *** valid card selected: trigger the details panel ***
            }
        }
    }

    void MoveBoard(){

        Transform tr = this.transform;

        if (movement.x > 0) {
            Vector2 v = new Vector2(-moveMult, 0);
            MoveOnGrid(1, 0);
            MoveBoardTo(tr, new Vector2(
                Mathf.Clamp(tr.localPosition.x + v.x, xMin, xMax), tr.localPosition.y));
        }
        if (movement.x < 0){
            Vector2 v = new Vector2(moveMult, 0);
            MoveOnGrid(-1, 0);
            MoveBoardTo(tr, new Vector2(
                Mathf.Clamp(tr.localPosition.x + v.x, xMin, xMax), tr.localPosition.y));
        }

        if (movement.y > 0) {
            Vector2 v = new Vector2(0, -moveMult);
            MoveOnGrid(0, 1);
            MoveBoardTo(tr, new Vector2(
                tr.localPosition.x, Mathf.Clamp(tr.localPosition.y + v.y, yMin, yMax)));
        }
        if (movement.y < 0) {
            Vector2 v = new Vector2(0, moveMult);
            MoveOnGrid(0, -1);
            MoveBoardTo(tr, new Vector2(
                tr.localPosition.x, Mathf.Clamp(tr.localPosition.y + v.y, yMin, yMax)));
        }
    }

    private bool ValidGridSpace(){
        int i;

        for (i = 0; i < cards.Length; i++){
            if (currGridX == cards[i].GetComponent<CardNode>().getGridX() &&
             currGridY == cards[i].GetComponent<CardNode>().getGridY()){
                return true;
             }
        }

        return false;
    }

    private void MoveBoardTo(Transform objectToMove, Vector3 targetPosition)
{
    StopCoroutine(MoveBoard(objectToMove, targetPosition));
    StartCoroutine(MoveBoard(objectToMove, targetPosition));
}

    private void MoveOnGrid(int x, int y){
        if (-2 < currGridX && currGridX < 1){ currGridX += x;}
        if (-1 < currGridY && currGridY < 1){ currGridY += y;}
    }

    public static IEnumerator MoveBoard(Transform objectToMove, Vector2 targetPosition)
{
    float currentProgress = 0;
    Vector3 cashedObjectPosition = objectToMove.transform.localPosition;

    while (currentProgress <= 1)
    {
        currentProgress += 2 * Time.deltaTime;
        
        objectToMove.localPosition = Vector2.Lerp(cashedObjectPosition, targetPosition, currentProgress);

        yield return null;
    }
}

    void allConnections(){
        int i, j;
                        
        for (i = 0; i < cards.Length; i++){
            GameObject[] connections = cards[i].GetComponent<CardNode>().getConnections();
            //print(cards[i].name + "--->");
            if (connections != null && connections.Length > 0){
                for (j = 0; j < connections.Length; j++){
                    //print(connections[j].name);
                }
            }
            
        }
        
    }
}
