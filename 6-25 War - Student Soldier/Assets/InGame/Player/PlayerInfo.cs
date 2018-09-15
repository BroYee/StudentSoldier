using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    [HideInInspector]public int maxHp;
    public int hp;

	// Use this for initialization
	void Start () {
        maxHp = hp;
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBullet"))
        {
            hp -= col.GetComponent<BulletInfo>().damage;
            col.GetComponent<BulletInfo>().gameObject.SetActive(false);
            if (hp <= 0)
            {
                hp = 0;
                GameObject gameOver = GameObject.FindGameObjectWithTag("UI").transform.GetChild(3).gameObject;
                gameOver.SetActive(true);

                gameObject.SetActive(false);
            }
        }
    }

}
