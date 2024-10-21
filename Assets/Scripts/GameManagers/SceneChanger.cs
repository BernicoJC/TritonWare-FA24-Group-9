using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(int scene_id)
    {
        SceneManager.LoadScene(scene_id);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
