using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBulletUI : MonoBehaviour {

    public PlayerGunInfo playerGun;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = playerGun.bulletNum.ToString();
    }
}
