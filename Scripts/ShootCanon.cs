using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCanon : MonoBehaviour
{

    [SerializeField]
    private GameObject canonBall;

    [SerializeField]
    private float fireRate;

    [SerializeField]
    private float canonBallSpeed;

    private int level = 1;
    public float XP = 0;
    public int TotalXP = 0;
    private float neededXP = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
    }

    IEnumerator fire() {
        yield return new WaitForSeconds(1/fireRate);
        GameObject canonBall1 = Instantiate(canonBall, transform.position-transform.right*0.2f, transform.rotation);
        GameObject canonBall2 = Instantiate(canonBall, transform.position+transform.right*0.2f, transform.rotation);
        canonBall1.GetComponent<CanonBallCollision>().canonBallSpeed = -canonBallSpeed;
        canonBall2.GetComponent<CanonBallCollision>().canonBallSpeed = canonBallSpeed;
        if (XP >= neededXP) {
            level += 1;
            fireRate +=1;
            XP = XP-neededXP;
        }
        StartCoroutine(fire());
    }

    public void recieveXP(int xpAmount) {
        XP += xpAmount;
        TotalXP += xpAmount;
    }

    public int returnXP() {
        return TotalXP;
    }

}
