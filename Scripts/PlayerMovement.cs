using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float forwardVelocity;

    [SerializeField]
    private KeyCode leftButton;

    [SerializeField]
    private KeyCode rightButton;

    [SerializeField]
    private float rotationSpeed;

    private float zRotation = 0;

    private bool rotateRight = false;// = Input.GetKey(leftButton);
    private bool rotateLeft = false;// = Input.GetKey(rightButton);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Border") SceneManager.LoadScene("StartingScene");
    }

    public void TurnLeft() {
        rotateRight = !rotateRight;
    }

    public void straight() {
        rotateRight = false;
        rotateLeft = false;
    }

    public void TurnRight() {
        rotateLeft = !rotateLeft;
    }

    // Update is called once per frame
    void Update()
    {   
        // rotateRight = rotateRight|| Input.GetKey(leftButton);
        // rotateLeft = rotateLeft|| Input.GetKey(rightButton);
        
        if (rotateRight) zRotation = 1;
        if (rotateLeft) zRotation = -1;

        zRotation = (rotateRight == rotateLeft)? 0: zRotation;
        Vector3 rotationVector = new Vector3(0, 0, zRotation);


        transform.position += transform.up*forwardVelocity*Time.deltaTime;
        transform.Rotate(rotationVector*rotationSpeed*Time.deltaTime);
    }
}
