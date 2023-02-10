using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // rotation of player
    private Quaternion rotation;
    // vector for player spawn
    private Vector3 spawn;
    // vector for teleport wall B
    private Vector3 TeleB;
    // vector for teleport wall A
    private Vector3 TeleA;

    // Start is called before the first frame update
    void Start(){
        rotation = transform.rotation;
        spawn = new Vector3(17, 1, 0);
        TeleB = new Vector3(0, 1, 24);
        TeleA = new Vector3(0, 1, -24);
    }

    // Update is called once per frame
    void LateUpdate(){
        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.forward * 3 * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S)){
            transform.position -= transform.forward * 3 * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A)){
            transform.position -= transform.right * 2 * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)){
            transform.position += transform.right * 2 * Time.deltaTime;
        }


        if(Input.GetKeyDown(KeyCode.E)){
            rotation *= Quaternion.AngleAxis(90, Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            rotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    // used when pac runs into a ghost or a wall
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ghost") {
            if (GameController.op == false)
            {
                ResetPosition();
                GameController.lives -= 1;
            }
            if (GameController.op == true)
            {
                Destroy(other.gameObject);
                GameController.score += 500;
            }
        }
        else if (other.gameObject.tag == "Teleport")
        {
            transform.position = TeleA;
        }
        else if (other.gameObject.tag == "TeleportB")
        {
            transform.position = TeleB;
        }
        else { 
        transform.position -= transform.forward * .5f;
        }
    }

    // used when pac runs into any orb
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "SmallOrb") {
            Destroy(other.gameObject);
            GameController.score += 100;
        }
        if (other.gameObject.tag == "BigOrb") {
            Destroy(other.gameObject);
            GameController.op = true;
        }
    }

    // reset pac position to spawn
    void ResetPosition() {
        transform.position = spawn;
    }
}
