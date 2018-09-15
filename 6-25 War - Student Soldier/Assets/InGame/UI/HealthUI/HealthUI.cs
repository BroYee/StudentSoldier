using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    public PlayerInfo player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float tempHp = player.hp;
        tempHp /= 300;
        gameObject.GetComponent<UnityEngine.UI.Slider>().value = tempHp;
	}
}
