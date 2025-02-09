using System;
using System.Numerics;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PinboardController : MonoBehaviour
{

    [SerializeField]
    private GameObject[] cards;

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
        
    }

    // Update is called once per frame
    void Update()
    {

        if (boardlock == ControllerLock.UNLOCKED){
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }
    }

    void MoveBoard(){
        
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
