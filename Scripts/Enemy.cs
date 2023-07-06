using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float health;
    public int expAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
       if (health <= 0) {
            GameObject Player = GameObject.FindGameObjectWithTag("Cannon");
            Destroy(gameObject.transform.parent.gameObject);
            Player.GetComponent<ShootCanon>().recieveXP(xpAmount: expAmount);
       } 
    }

    public void takeDamage(float _damage) {
        health -= _damage;
    }

    public float getHealth() {
        return health;
    }
}
