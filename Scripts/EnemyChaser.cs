using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    private GameObject Player;

    private float damage = 1;
    public float boatSpeed = 0.1f;
    public float rotateSpeed = 10f;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerHealth>() != null) other.GetComponent<PlayerHealth>().takeDamage(damage);
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,Player.transform.position,boatSpeed*Time.deltaTime);

        Vector2 direction = Player.transform.position - transform.position;
        
        float turnAngle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(turnAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed*Time.deltaTime);
    }
}
