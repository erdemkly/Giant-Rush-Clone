using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public PlayerScript playerScript;

    void Start()
    {
        StartCoroutine(FightIE());
    }

    IEnumerator FightIE()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("punch to player");
            yield return new WaitForSeconds(0.5f);
            playerScript.isMyTurn = true;
        }
    }
    
}
