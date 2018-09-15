using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInfo : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.transform.GetChild(0).GetChild(2).GetComponent<PlayerGunInfo>().bulletNum += 20;

            transform.parent.GetComponent<ItemManager>().itemUsed[0] = true;

            Destroy(gameObject);
        }
    }
}
