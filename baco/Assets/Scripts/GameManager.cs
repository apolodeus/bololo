using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class GameManager : MonoBehaviour
{

    [SerializeField] private string guiName; // nome da fase do interface

    [SerializeField] private string Levelname; // nome da fase do jogo
    // Start is called before the first frame update
    [SerializeField] private GameObject playerAndCameraPrefab;
    
    
    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(guiName);
        //SceneManager.LoadScene(Levelname, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(Levelname, LoadSceneMode.Additive).completed += operation =>
        {
            Scene levelScene = default;
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == Levelname)
                {
                    levelScene = SceneManager.GetSceneAt(i);
                    break;
                }
            }

            if (levelScene != default) SceneManager.SetActiveScene(levelScene);

            Vector3 playerStartPosition = GameObject.Find("PlayerStart").transform.position;
            Instantiate(playerAndCameraPrefab, playerStartPosition, Quaternion.identity);
        };


    }
    
    

}
