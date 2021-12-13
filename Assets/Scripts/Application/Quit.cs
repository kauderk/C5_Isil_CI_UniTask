using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    // quit game corroutine
    public IEnumerator QuitGameCoroutine()
    {
        yield return new WaitForSeconds(1);
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
