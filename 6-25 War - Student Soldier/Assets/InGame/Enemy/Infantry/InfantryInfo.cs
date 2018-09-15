using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryInfo : MonoBehaviour {

    public int hp;    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("AllyBullet"))
        {
            hp -= col.GetComponent<BulletInfo>().damage;
            col.GetComponent<BulletInfo>().gameObject.SetActive(false);
            if (hp <= 0)
            {
                hp = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
