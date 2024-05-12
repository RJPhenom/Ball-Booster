using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string mainSceneName = "SampleScene";

    public void StartGame() {
        Debug.Log("Starting...");
        SceneManager.LoadScene(mainSceneName);
    }
}
