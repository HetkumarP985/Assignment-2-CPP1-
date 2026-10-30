using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public float minXPos;
    public float maxXPos;
    public float cameraSpeed;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target == null)
        {
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            if (Player == null)
            {
                Debug.LogError("No Target assigned as player. Please include valid reference in the camera follow script");
                return;
            }
            target = Player.transform;
        }
    }

    // regular update function is specifically linked to the coumpters tick rate- useful for input handeling
    // fixed update runs on an exact fixed time (60FPS = 1/60 = 0.016666s0 - this is useful for physics as a proper update that is decoumpled from rendering
    // allows for more consistent physics behaviour.
    // Late update is the last update in a frame after all fixed update and update cycles have run. Unity specifics that LateUpdate is generally useful for camera movement as it is the last thing that will happen in a frame.

    // Update is called once per frame
    void LateUpdate()
    {
       if (target == null) // this is an exit condition if the object needs to run doesnt exist
        {
            return;
        }
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(target.position.x, minXPos, maxXPos);
        transform.position = Vector3.MoveTowards(transform.position, currentPos, 5 * Time.deltaTime);
    }
}
