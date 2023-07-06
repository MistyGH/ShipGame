using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreMonster : MonoBehaviour
{
    public GameObject OuterCircle;
    public GameObject InnerCircle;
    public float growthDelays;
    public GameObject SpawnedMonster;
    // Start is called before the first frame update
    void Start()
    {
        OuterCircle.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        InnerCircle.transform.localScale = new Vector3(0f,0f,0f);
        StartCoroutine("GrowOuter");  
    }

    IEnumerator GrowOuter()
        {
            float iterator = 0.2f;
            while(OuterCircle.transform.localScale.x < 1)
            {
                yield return new WaitForSeconds(growthDelays);
                OuterCircle.transform.localScale = new Vector3(iterator,iterator,iterator);
                iterator += 0.1f;
            }
            StartCoroutine(GrowInner());
        }
    IEnumerator GrowInner()
        {
           float iterator = 0.1f;
           InnerCircle.transform.localScale = new Vector3(0.05f,0.05f,0.05f);
            while(InnerCircle.transform.localScale.x < 0.45)
            {
                yield return new WaitForSeconds(growthDelays);
                InnerCircle.transform.localScale = new Vector3(iterator,iterator,iterator);
                iterator += 0.1f;
                
            }
            Instantiate(SpawnedMonster,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
}
