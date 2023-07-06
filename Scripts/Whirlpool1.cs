using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool1 : MonoBehaviour
{
    public GameObject secondStage;
    public float growthDelays;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        StartCoroutine("GrowPool");
    }

    IEnumerator GrowPool()
    {
        float iterator = 0.2f;
        while(transform.localScale.x < 1)
        {
            yield return new WaitForSeconds(growthDelays);
            transform.localScale = new Vector3(iterator,iterator,iterator);
            iterator += 0.1f;
        }
        Instantiate(secondStage,transform.position,transform.rotation);
        Destroy(this.gameObject);

    }
}
