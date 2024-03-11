using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Finish : MonoBehaviour
{
    bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.gameObject.tag == "Player")
        {
            active = false;

            ScoreManager.score++;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
