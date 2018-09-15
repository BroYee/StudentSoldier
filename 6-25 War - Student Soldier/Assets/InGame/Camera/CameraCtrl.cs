using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

    public Transform playerTrans;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, -10);

        transform.position = Vector3.Lerp(transform.position, playerTrans.position + new Vector3(0, 0, -10), 4.0f * Time.deltaTime);
	}
}
