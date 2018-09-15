using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPaneBreak : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet") || col.gameObject.CompareTag("AllyBullet"))
            Destroy(gameObject);
    }
}
