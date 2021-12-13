using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CircleCollider2D))]
public class TriggerMeChangeLevel : MonoBehaviour
{
    public int levelToLoad = 5;
    // if the player enters the trigger zone, load the next level

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            NewMethod();
        }
    }

    private async UniTask NewMethod()
    {
        await SceneController.Instance.LoadScene(levelToLoad);
    }
}
