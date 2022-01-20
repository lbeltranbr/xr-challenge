using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 1f;
    public float height = 1f;

    private bool isPlaying = false;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        if (!sound)
            Debug.LogError("Sound not found");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-20.7f, Mathf.Lerp(0f, height, Mathf.Sin(Time.time * speed)), 2f);
        if (transform.position.y > 0.05 && !isPlaying)
        {
            sound.Play();
            isPlaying = true;
        }
        if (transform.position.y <= 0.05)
        {
            sound.Stop();
            isPlaying = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.gameObject.transform.parent = null;
    }
}
