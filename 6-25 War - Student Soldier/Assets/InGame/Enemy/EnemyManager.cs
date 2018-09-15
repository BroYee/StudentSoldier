using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<GameObject> enemy;
    public List<int> enemyNum;
    private List<List<GameObject>> enemyList;

    public static EnemyManager instance;

    public float[] roundDuration;

    private int round;
    private bool rest;

    private bool allRoundIsEnd;

    // Use this for initialization
    void Start() {

        enemyList = new List<List<GameObject>>();

        for (int i = 0; i < enemy.Count; i++)
        {
            enemyList.Add(new List<GameObject>());

            for (int j = 0; j < enemyNum[i]; j++)
            {
                GameObject temp = (GameObject)Instantiate(enemy[i]);
                temp.name += j + 1;
                temp.transform.parent = this.transform;
                temp.SetActive(false);
                enemyList[i].Add(temp);
            }
        }

        round = 0;

        allRoundIsEnd = false;

        StartCoroutine(Round());
        StartCoroutine(SpawnInfantry());
        StartCoroutine(SpawnInfantry2());
    }

    // Update is called once per frame
    void Update() {

        for (int i = 0; i < enemy.Capacity; i++)
        {
            for (int j = 0; j < enemyNum[i]; j++)
            {
                if (enemyList[i][j].activeSelf == true)
                {
                    if (System.Math.Abs(enemyList[i][j].transform.position.x) >= 50 || System.Math.Abs(enemyList[i][j].transform.position.y) >= 50)
                        enemyList[i][j].SetActive(false);
                }
            }
        }

        if (allRoundIsEnd)
        {
            for (int i = 0; i < enemy.Capacity; i++)
            {
                for (int j = 0; j < enemyNum[i]; j++)
                {
                    if (enemyList[i][j].activeSelf == true) return;
                }
            }

            GameObject gameClear = GameObject.FindGameObjectWithTag("UI").transform.GetChild(4).gameObject;
            gameClear.SetActive(true);
        }
    }

    IEnumerator SpawnInfantry()
    {
        yield return new WaitForSeconds(Random.Range(10 - round, 15 - round));

        for (int i = 0; i < enemyNum[0]; i++)
        {
            if (enemyList[0][i].activeSelf == false)
            {
                Vector3[] tempSpawnPos = new Vector3[3];
                tempSpawnPos[0] = new Vector3(Random.Range(-30, 30), Random.Range(-17, -22), 0);
                tempSpawnPos[1] = new Vector3(Random.Range(30, 35), Random.Range(-20, 20), 0);
                tempSpawnPos[2] = new Vector3(Random.Range(-30, 30), Random.Range(20, 25), 0);

                if (round == 0) enemyList[0][i].transform.position = tempSpawnPos[0];
                else enemyList[0][i].transform.position = tempSpawnPos[Random.Range(0, round)];

                enemyList[0][i].GetComponent<InfantryInfo>().hp = 100 + (10 * round);

                enemyList[0][i].SetActive(true);

                break;
            }
        }

        if (!allRoundIsEnd)
            StartCoroutine(SpawnInfantry());
    }

    IEnumerator SpawnInfantry2()
    {
        yield return new WaitForSeconds(Random.Range(23 - round, 25 - round));

        for (int i = 0; i < enemyNum[1]; i++)
        {
            if (enemyList[1][i].activeSelf == false)
            {
                Vector3[] _tempSpawnPos = new Vector3[3];
                _tempSpawnPos[0] = new Vector3(Random.Range(-30, 30), Random.Range(-17, -22), 0);
                _tempSpawnPos[1] = new Vector3(Random.Range(30, 35), Random.Range(-20, 20), 0);
                _tempSpawnPos[2] = new Vector3(Random.Range(-30, 30), Random.Range(20, 25), 0);

                if (round == 0) enemyList[1][i].transform.position = _tempSpawnPos[0];
                else enemyList[1][i].transform.position = _tempSpawnPos[Random.Range(0, round)];

                enemyList[1][i].GetComponent<InfantryInfo>().hp = 200 + (10 * round);

                enemyList[1][i].SetActive(true);

                break;
            }
        }

        if (!allRoundIsEnd)
            StartCoroutine(SpawnInfantry2());
    }

    IEnumerator Round()
    {
        yield return new WaitForSeconds(roundDuration[round]);
        round++;

        StartCoroutine(Rest());
    }

    IEnumerator Rest()
    {
        yield return new WaitForSeconds(5);

        if (round != (roundDuration.Length - 1))
            StartCoroutine(Round());
        else allRoundIsEnd = true;
    }
}
