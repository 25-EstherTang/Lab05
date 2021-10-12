using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float scorevalue;
    public float totalcoins;
    public float timeleft;

    public int timeRemaining;
    
    public Text ScoreText;
    public Text TimerText;

    private float TimerValue;


    // Start is called before the first frame update
    void Start()
    {
        ScoreText.GetComponent<Text>().text = "Score: " + scorevalue;
        scorevalue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeleft % 60);

        TimerText.text = "Timer: " + timeRemaining.ToString();

        if (scorevalue >= totalcoins)
        {

                SceneManager.LoadScene("WinScene");

        }

        else if (timeleft <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            scorevalue += 10;
            ScoreText.GetComponent<Text>().text = "Score: " + scorevalue;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("LoseScene");

        }
    }
}
