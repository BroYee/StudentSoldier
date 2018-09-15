using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolCol : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            transform.parent.GetChild(0).gameObject.SetActive(false);
            transform.parent.GetChild(1).gameObject.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            transform.parent.GetChild(0).gameObject.SetActive(true);
            transform.parent.GetChild(1).gameObject.SetActive(false);
        }
    }
}
