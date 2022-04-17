using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMain : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneLoader.instance.Load(SceneLoader.Scene.MainMenu);
    }
}
