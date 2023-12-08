namespace SceneTransitionNamespace
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using System.Collections;


    public class SceneTransition : MonoBehaviour
    {
        public Image image; 
        public float fadeDuration = 4f; 
        string sceneName;

        public void ChangeSceneWithFade(string sceneName)
        {
            this.sceneName = sceneName;
            StartCoroutine(FadeIn());
        }

       IEnumerator FadeIn() {
        image.canvasRenderer.SetAlpha(0.0f); 

        image.gameObject.SetActive(true); 
        image.CrossFadeAlpha(1.0f, fadeDuration, false); 
        yield return new WaitForSeconds(fadeDuration); 

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() {
        image.CrossFadeAlpha(0.0f, fadeDuration, false); 
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(fadeDuration); 

        image.gameObject.SetActive(false); 
        
    }
    }

}

