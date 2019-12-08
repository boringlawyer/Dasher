using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#else
using UnityEngine.SceneManagement;
#endif
// Caleb Katzenstein
// Dasher
// List of essential methods that all scripts have access to
public static class EventSystem
{
	public static void GameOver(ReasonForDying.Reason reason)
	{
        ReasonForDying reasonAsset = Resources.Load("Reason For Dying") as ReasonForDying;
        reasonAsset.reason = reason;
#if UNITY_EDITOR
        EditorSceneManager.LoadScene(4);
#else
        SceneManager.LoadScene(4);
#endif
    }
}
