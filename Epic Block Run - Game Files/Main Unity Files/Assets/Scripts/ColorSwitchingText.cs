using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwitchingText : MonoBehaviour
{
    public Text myText; // Reference to the game title text
    public float speed = 1.0f; // Speed of the color change

    private void Start()
    {
        if (myText == null)
        {
            myText = GetComponent<Text>(); // Fetch the game title's text component
        }
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        Color startColor = Color.red; // Starting color
        Color endColor = Color.blue; // Ending color

        float duration = 2.0f; // Duration for one color transition
        float time = 0;

        while (true)
        {
            time += Time.deltaTime * speed;

            // Calculate the current color based on time
            myText.color = Color.Lerp(startColor, endColor, Mathf.PingPong(time / duration, 1));

            yield return null; // Wait for the next frame
        }
    }
}