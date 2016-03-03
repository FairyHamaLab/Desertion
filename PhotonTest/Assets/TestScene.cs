using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TestScene : MonoBehaviour {

    public void Push()
    {
        SceneManager.LoadSceneAsync("BossScene",LoadSceneMode.Single);
    }
}
