using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Whirlpool2 : MonoBehaviour
{

    private bool playerLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerLeft = false;
        if (other.GetComponent<CanonBallCollision>() == null) StartCoroutine(pullIn(other));
    }

    void OnTriggerExit2D(Collider2D other) {
        
        if (other.tag == "Player") playerLeft = true;
    }

    IEnumerator pullIn(Collider2D _other) {
        float time = 0;
        float pullForce = 0;
        bool end = false;
        while (_other != null && !end) {
            if (playerLeft == true && _other.tag == "Player") yield break;
            if (Vector3.Distance(transform.position, _other.transform.position) > 0.1) {
                Vector3 direction = (transform.position - _other.transform.position).normalized;
                GameObject movingBody = _other.gameObject;
                if (_other.tag != "Player") {
                    movingBody = (_other.transform.parent.gameObject != null) ?_other.transform.parent.gameObject :_other.gameObject;
                }
                movingBody.transform.position += direction * pullForce * Time.deltaTime;
                time += Time.deltaTime/2;
                if (time > 1) time = 1;
                pullForce = Mathf.Lerp(0, 15, time);
                yield return null;
            }
            else end = true;
        }
        if (_other != null) {
            if (_other.tag == "Player") SceneManager.LoadScene("StartingScene");
            else Destroy((_other.transform.parent.gameObject != null) ?_other.transform.parent.gameObject :_other.gameObject);
        }
    }
}
