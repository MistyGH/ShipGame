using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShipMovement : MonoBehaviour
{
    
    
    [SerializeField]
    private float forwardVelocity;
    private float moveTime;
    private float rotationAmount = 0;

    private float allowedRange = 3;

    private bool rotating = false;
    private bool dodging = false;

    private bool enteredArea = false;
    private Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enteredArea) {
            bool hittingWhirlpool = false;
            Collider2D frontView = Physics2D.OverlapCircle(transform.up + transform.position, 0.5f);

            if (frontView != null) {
                if (frontView.tag != null) {
                    hittingWhirlpool = frontView.tag == "Whirlpool";
                }
            }
            
            if (Vector2.Distance(transform.position, Vector2.zero) < allowedRange && !hittingWhirlpool) {
                rotating = false;
                if (Time.time >= moveTime) {
                    changeMotion();
                }
            }
            else if (!rotating){
                dodging = hittingWhirlpool;
                rotateBack();
            }
            
            transform.position += transform.up*forwardVelocity*Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, rotationAmount*Time.deltaTime));
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1*Time.deltaTime);
            Vector2 direction = player.transform.position - transform.position;
            float turnAngle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(turnAngle-90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100*Time.deltaTime);

            if (Vector2.Distance(transform.position, Vector2.zero) < allowedRange) enteredArea = true;
        }
    }

    void changeMotion() {
        rotationAmount = Random.Range(-50.0f, 50.0f);
        moveTime = Time.time + Random.Range(1.0f, 3.0f);
    }

    void rotateBack() {
        rotationAmount = (dodging? rotationAmount < 0: rotationAmount > 0)?100:-100;
        rotating = true;
    }

}
