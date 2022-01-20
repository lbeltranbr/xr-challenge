using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject star;

    private bool activateStar = false;
    private AudioSource button;
    private void Start()
    {
        button = gameObject.GetComponent<AudioSource>();

        if (!button)
            Debug.LogError("Sound not found");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !activateStar)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Vector4(0.5f, 0, 0, 1));
            activateStar = false;
            star.SetActive(true);
            button.Play();
        }

    }


}
