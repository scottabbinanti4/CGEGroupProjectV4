using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int nextSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with player");
            Debug.Log("next Scene Index = " + nextSceneIndex.ToString());
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
