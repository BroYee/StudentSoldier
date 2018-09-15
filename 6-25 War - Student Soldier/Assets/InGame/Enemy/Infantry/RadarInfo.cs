using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarInfo : MonoBehaviour {
    
    private bool allyIsSurrounded;
    private Vector3 nearestAllyPos;

    public float rotateSpeed;

    public float shootRange;

    // Use this for initialization
    void Start () {
        allyIsSurrounded = false;

        nearestAllyPos = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (allyIsSurrounded && (nearestAllyPos.x != 0))
        {
            Vector2 dir = nearestAllyPos - transform.parent.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.parent.transform.rotation = Quaternion.Slerp(transform.parent.transform.rotation, rot, rotateSpeed * Time.deltaTime);
     

            double tempDistance = Vector3.Distance(nearestAllyPos, transform.position);

            if (tempDistance <= shootRange)
            {
                transform.parent.GetComponent<InfantryMove>().isMoving = false;
                transform.parent.GetChild(1).GetChild(2).GetComponent<InfantryGunInfo>().shoot = true;
            }
            else
            {
                StartCoroutine(transform.parent.GetComponent<InfantryMove>().HeadBack());
                transform.parent.GetChild(1).GetChild(2).GetComponent<InfantryGunInfo>().shoot = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ally") || col.gameObject.CompareTag("Player"))
            allyIsSurrounded = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ally") || col.gameObject.CompareTag("Player"))
            allyIsSurrounded = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ally") || col.gameObject.CompareTag("Player"))
        {
            allyIsSurrounded = true;
            nearestAllyPos = col.transform.position;
        }
    }
}
