using UnityEngine;

public class CardNode : MonoBehaviour
{

    [SerializeField]
    private GameObject[] connections;

    [SerializeField]
    private int gridY, gridX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] getConnections(){
        return connections;
    }

    public int getGridX(){
        return gridX;
    }

    public int getGridY(){
        return gridY;
    }

    private void HideCard(){
        this.GetComponent<Renderer>().enabled = false;
    }

    public void ShowCard(){
        this.GetComponent<Renderer>().enabled = true;
    }
}
