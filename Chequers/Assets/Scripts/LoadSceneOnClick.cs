using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

        public void LoadedByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
}
