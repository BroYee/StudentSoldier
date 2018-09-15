using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitInfo : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerInfo>().hp = col.gameObject.GetComponent<PlayerInfo>().maxHp;

            transform.parent.GetComponent<ItemManager>().itemUsed[1] = true;

            Destroy(gameObject);
        }
    }
}
