using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour {

    [HideInInspector]public Vector3 firstPos;

    [HideInInspector]public string shootersTag;

    public float speed;
    public float range;
    public int damage;
	
	// Update is called once per frame
	void Update () {
        
        double tempMoveDistance = Vector3.Distance(firstPos, transform.position);

        if (tempMoveDistance >= range)
        {
            gameObject.SetActive(false);
        }

        transform.Translate(Vector2.up * speed);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag(shootersTag) || col.gameObject.CompareTag("Radar") || col.gameObject.CompareTag("Entrance")
            || col.gameObject.CompareTag("WindowPane") || col.gameObject.CompareTag("Item") || col.gameObject.CompareTag("Col")) return;
        gameObject.SetActive(false);
    }
}
