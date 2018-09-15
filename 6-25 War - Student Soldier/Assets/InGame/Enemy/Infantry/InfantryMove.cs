using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryMove : MonoBehaviour {

    private Rigidbody2D rb;

    private GameObject[] entrances;

    private Vector3 destination;

    public float speed;
    [HideInInspector]public bool isMoving;
    public float headBackTime;

    private bool enteredSchool;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();

        if (entrances == null)
        {
            entrances = GameObject.FindGameObjectsWithTag("Entrance");
        }

        double tempEntranceDistance = 100.0f;

        for (int i = 0; i < entrances.Length; i++)
        {
            double tempDis = Vector3.Distance(entrances[i].transform.position, transform.position);

            if (tempDis < tempEntranceDistance)
            {
                tempEntranceDistance = tempDis;

                destination = entrances[i].transform.position;
            }
        }

        StartToGoToDestination();

        isMoving = true;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isMoving)
        {
            rb.AddForce(transform.right * speed);
        }
	}

    void StartToGoToDestination()
    {
        Vector3 rightVec = (destination - transform.position).normalized;

        transform.right = rightVec;

        //float z = Mathf.Atan2((destination.y - transform.position.y),
        //    (destination.x - transform.position.x)) * Mathf.Rad2Deg;

        //transform.eulerAngles = new Vector3(0, 0, z);
        
        isMoving = true;
    }

    public IEnumerator HeadBack()
    {
        yield return new WaitForSeconds(headBackTime);
        StartToGoToDestination();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Entrance"))
            destination = new Vector3(2.8f, 0, 0);
    }

}
