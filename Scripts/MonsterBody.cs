using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBody : MonoBehaviour
{

    private Collider2D targetBody;

    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private GameObject underWaterMonster;

    public void setTargetRotation(Quaternion _targetRotation) {
        transform.rotation = _targetRotation;
    }

    public void setTargetBody(Collider2D _targetBody) {
        targetBody = _targetBody;
        StartCoroutine(pullIn(targetBody));
    }


    IEnumerator pullIn(Collider2D _other) {
        float time = 0;
        float pullForce = 0;
        bool end = false;
        float holdTime = 2;
        while (_other != null && !end) {
            if (Vector3.Distance(grabPoint.position, _other.transform.position) > 0.1) {
                Vector3 direction = (grabPoint.position - _other.transform.position).normalized;
                _other.transform.position += direction * pullForce * Time.deltaTime;
                time += Time.deltaTime/2;
                if (time > 1) time = 1;
                pullForce = Mathf.Lerp(0, 15, time);
                yield return null;
            }
            else if (holdTime >= 0) {
                holdTime -= Time.deltaTime;
                Vector3 direction = (grabPoint.position - _other.transform.position).normalized;
                _other.transform.position += direction * pullForce * Time.deltaTime;
                yield return null;
            }
            else end = true;
        }
        if (_other != null) {
            if (_other.tag == "Player") SceneManager.LoadScene("StartingScene");
            else {
                Destroy((_other.transform.parent.gameObject != null) ?_other.transform.parent.gameObject :_other.gameObject);
                GameObject underWater = Instantiate(underWaterMonster, transform.position, Quaternion.identity);
                float currentHealth = gameObject.GetComponent<Enemy>().getHealth();
                float maxHealth = underWater.GetComponentInChildren<MonsterUnderWater>().getMaxHealth();
                underWater.GetComponentInChildren<MonsterUnderWater>().setDamage(maxHealth - currentHealth);
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}
