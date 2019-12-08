using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#else
using UnityEngine.SceneManagement;
#endif
public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    public void LoadScene()
    {
#if UNITY_EDITOR
        EditorSceneManager.LoadScene(sceneIndex);
#else
        SceneManager.LoadScene(sceneIndex);
#endif
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadScene();
        }
    }
}
