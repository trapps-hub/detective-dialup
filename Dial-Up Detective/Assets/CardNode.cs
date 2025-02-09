using UnityEngine;

public class CardNode : MonoBehaviour
{

    [SerializeField]
    private GameObject[] connections;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] getConnections(){
        return connections;
    }
}
