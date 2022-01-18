using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0f, 9, -7);
    }
}
