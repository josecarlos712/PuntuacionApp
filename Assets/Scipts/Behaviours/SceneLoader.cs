using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string sceneName = "";

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ChangeSceneButton);
    }

    private void ChangeSceneButton()
    {
        //SceneManager.UnloadSceneAsync para descargar una escena
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {

    }
}