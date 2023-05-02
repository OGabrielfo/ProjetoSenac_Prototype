using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleActivator : MonoBehaviour
{
    public GameObject boss;
    public GameObject vidaBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            boss.SetActive(true);
            vidaBoss.SetActive(true);
        }
    }
}
