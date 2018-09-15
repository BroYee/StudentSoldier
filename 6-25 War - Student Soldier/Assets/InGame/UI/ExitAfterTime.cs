using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitAfterTime : MonoBehaviour {

    public float time;

	// Use this for initialization
	void Start () {
        StartCoroutine(ExitAfterSec());
	}

    IEnumerator ExitAfterSec()
    {
        yield return new WaitForSeconds(time);

        Application.Quit();
    }
}
