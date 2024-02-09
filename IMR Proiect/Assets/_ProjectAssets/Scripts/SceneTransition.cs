namespace SceneTransitionNamespace
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using System.Collections;

    public class SceneTransition : MonoBehaviour
    {
        public float fadeDuration = 4f;
        string sceneName;

        public void ChangeSceneWithFade(string sceneName)
        {
            this.sceneName = sceneName;
            StartCoroutine(FadeIn());
        }

        IEnumerator FadeIn()
        {
            float elapsedTime = 0f;
            Color screenColor = Color.black; 

            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                screenColor.a = alpha;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            StartCoroutine(FadeOut());
        }

        IEnumerator FadeOut()
        {
            float elapsedTime = 0f;
            Color screenColor = Color.black; 

            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                screenColor.a = alpha;
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}
