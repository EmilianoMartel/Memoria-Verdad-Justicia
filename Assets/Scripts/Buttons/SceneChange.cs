using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private float _waitForChange = 0.5f;

    public void ChangeScene(string name)
    {
        StartCoroutine(Change(name));   
    }

    public void Close()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    private IEnumerator Change(string name)
    {
        yield return new WaitForSeconds(_waitForChange);
        SceneManager.LoadScene(name);
    }
}
