using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;


public class UniTaskTest : MonoBehaviour
{
    async void Start()
    {
        await Awaiting1();
    }

    async UniTask Awaiting1()
    {
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime;
            await UniTask.Yield();
        }
        Debug.Log("Done");
    }
}
