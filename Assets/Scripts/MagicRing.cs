using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MagicRing : MonoBehaviour
{
    public GameObject bonfireText;
    // Start is called before the first frame update
    private ScoreManager scoreManager;
    private ParticleSystem ring;
    private AudioSource portal;
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        ring = gameObject.GetComponent<ParticleSystem>();
        portal = gameObject.GetComponent<AudioSource>();
        if (!scoreManager)
            Debug.LogError("ScoreManager not found");
        if (!ring)
            Debug.LogError("Particle System not found");
        if (!portal)
            Debug.LogError("Sound System not found");

        ring.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.GetScore() >= 500 && !ring.isPlaying)
        {
            ring.Play();
            portal.Play();
            bonfireText.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(ring.isPlaying)
            SceneManager.LoadScene("Init", LoadSceneMode.Single);
    }
}
