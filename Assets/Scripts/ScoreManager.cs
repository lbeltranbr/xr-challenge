using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public AudioSource pickUpAudio;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup"))
        {
            AddPoints(other.GetComponent<Pickup>().GetPickedUp());
            UpdateText();
            other.GetComponent<CapsuleCollider>().enabled = false;
            pickUpAudio.Play();
        }
    }

    private void AddPoints(int points)
    {
        score += points;
    }
    private void UpdateText()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
