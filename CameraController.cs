using UnityEngine;

public class CameraController : MonoBehaviour
{
    // holds gameObject player as a transform variable
    private Transform player;
    // vector of how far the camera is from the player
    private Vector3 offset;
    // vector of the direction of the player and camera
    private Vector3 direction;
    // vector for camera position for end of game
    private Vector3 endGame;

    // Start is called before the first frame update
    void Start(){
        player = GameObject.Find("Player").transform;
        offset = new Vector3(0, 0, -2);
        endGame = new Vector3(0, 50, 0);
    }

    // Update is called once per frame
    void Update(){
        if (GameController.lives > 0)
        {
            direction = player.transform.forward;
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            direction = endGame;
            transform.position = endGame;
            transform.rotation = player.transform.rotation;
        }
    }
}
