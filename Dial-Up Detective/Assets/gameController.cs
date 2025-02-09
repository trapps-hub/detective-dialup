using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameController : MonoBehaviour
{

    TextMeshProUGUI textbox;
    private float rollInSpeed = 0.06f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textbox = GameObject.Find("SpeakBox").GetComponent<TextMeshProUGUI>();
        RollInText("RollingRollingRolling RollingRolling RollingRollingRollingRollingRollingRollingRollingRollingRollingRollingRollingRollingRollingRollingRollingRolling");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to start rolling in the text slowly
    public void RollInText(string newText)
    {
        // Start the coroutine to reveal text character by character
        StartCoroutine(RollInTextCoroutine(newText));
    }

    // Coroutine that handles the slow roll-in effect
    private IEnumerator RollInTextCoroutine(string newText)
    {
        textbox.text = "";  // Clear the text initially

        for (int i = 0; i < newText.Length; i++)
        {
            textbox.text += newText[i];  // Append each character one by one
            yield return new WaitForSeconds(rollInSpeed);  // Wait for a specified time before showing the next character
        }
    }
}
