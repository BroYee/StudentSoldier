using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfantryGunInfo : MonoBehaviour {

    public GameObject bullet;

    private List<GameObject> bullets;

    private int currentBulletNum;
    private bool isReloading;

    [HideInInspector]public bool shoot;
    public float shotRate;
    public float inaccuracy;
    public float reloadingTime;
    public int magazineSize;
    public bool automatic;

    private float prevShootTime;


    // Use this for initialization
    void Start()
    {
        bullets = new List<GameObject>();

        for (int j = 0; j < magazineSize; j++)
        {
            GameObject temp = (GameObject)Instantiate(bullet); // 프리팹 오브젝트를 생성하고 obj에 넣는다.
            temp.name += j + 1;  // 생성된 Cube의 이름에 i번째를 추가한다.
            //temp.transform.parent = this.transform; // 생성된 Cube의 부모를 지금 스크립트를 가지고 있는 오브젝트로 선정한다.
            temp.SetActive(false);
            temp.transform.position = transform.position;
            bullets.Add(temp); // 리스트에 저장
        }

        currentBulletNum = magazineSize;
        isReloading = false;

        prevShootTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isReloading)
        {
            if (automatic)
            {
                if (shoot)
                {
                    float tempShootTime = Time.realtimeSinceStartup - prevShootTime;
                    if (tempShootTime >= shotRate)
                    {
                        Shoot();
                    }
                }
            }
            else
            {
                if (shoot)
                {
                    float tempShootTime = Time.realtimeSinceStartup - prevShootTime;
                    if (tempShootTime >= shotRate)
                    {
                        Shoot();
                    }
                }
            }
        }

        if (currentBulletNum == 0)
        {
            if (!isReloading)
                StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (currentBulletNum != 0)
        {
            int tempIndex = currentBulletNum;
            if (currentBulletNum == magazineSize) tempIndex = 0;

            bullets[tempIndex].transform.position = transform.position;
            bullets[tempIndex].GetComponent<BulletInfo>().firstPos = transform.position;
            bullets[tempIndex].GetComponent<BulletInfo>().shootersTag = gameObject.transform.parent.gameObject.tag;
            bullets[tempIndex].transform.rotation = transform.rotation;
            Quaternion target = Quaternion.Euler(Random.Range(-inaccuracy, inaccuracy), Random.Range(-inaccuracy, inaccuracy), 0);
            // give some inaccurateness
            bullets[tempIndex].transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Random.Range(-inaccuracy, inaccuracy));
            // make bullet look toward the target
            bullets[tempIndex].SetActive(true);

            --currentBulletNum;
            if (currentBulletNum < 0) currentBulletNum = 0;

            prevShootTime = Time.realtimeSinceStartup;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadingTime);

        currentBulletNum = magazineSize;

        isReloading = false;
    }
}
