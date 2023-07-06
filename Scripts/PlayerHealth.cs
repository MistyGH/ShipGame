using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image hearts;

    [SerializeField]
    private float health;

    [SerializeField]
    private float scale;
    private float fiveHearts = 0.865f;
    private float fourHearts = 0.67f;
    private float threeHearts = 0.5f;
    private float twoHearts = 0.315f;
    private float oneHeart = 0.135f;
    private float dead = 0f;

    private float[] heartList = new float[6];

    // Start is called before the first frame update
    void Start()
    {

        heartList[0] = dead;
        heartList[1] = oneHeart;
        heartList[2] = twoHearts;
        heartList[3] = threeHearts;
        heartList[4] = fourHearts;
        heartList[5] = fiveHearts;
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= 0 && health <= 5) hearts.fillAmount = heartList[(int)health];

        if (health <= 0) {
            SceneManager.LoadScene("StartingScene");
        }
    }

    public void takeDamage(float _damage) {
        health -= _damage;
    }

}
