using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderColision : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float pushFactor;

    private float waveRate = 0.5f;
    private float nextWave = 0;

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Time.time >= nextWave) {
            nextWave = Time.time + 1/waveRate;
            StartCoroutine(pushAway());
        }
    }

    IEnumerator pushAway() {
        float time = 0;
        float pushForce = 0;
        while (time <= 1) {
            player.transform.position += transform.right * pushForce * Time.deltaTime;
            time += Time.deltaTime;
            pushForce = Mathf.Lerp(0, pushFactor, time);
            yield return null;
        }
        time = 0;
        while (time <= 1) {
            player.transform.position += transform.right * pushForce * Time.deltaTime;
            time += Time.deltaTime;
            pushForce = Mathf.Lerp(pushFactor, 0, time);
            yield return null;
        }
    }
}

