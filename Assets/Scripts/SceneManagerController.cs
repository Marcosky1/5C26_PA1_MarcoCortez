using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SceneManagerController : MonoBehaviour
{
    public static SceneManagerController Instance {get; private set;}
    [Header("Fade Components")]
    [SerializeField] private Image foreground;
    [Header("Fade In")]
    [SerializeField] private float fadeInTime;
    [SerializeField] private Color fadeInColor;
    [Header("Fade Out")]
    [SerializeField] private float fadeOutTime;
    [SerializeField] private Color fadeOutColor;

    private Action _onFade;
    private Action _onLoadScene;
    private Color _imageColor;
    private string _scenNameToLoad;
    

    private void Awake() {
        if(Instance != this && Instance != null){
            Destroy(this.gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start() {
        _imageColor = foreground.color;
        StartCoroutine(FadeCoroutine(fadeOutTime, fadeOutColor));
    }
    
    public void LoadScene(string newSceneName){
        
        _scenNameToLoad = newSceneName;
        _onFade = CallLoadScene;
        _onLoadScene = CallFadeOut;

        CallFadeIn();
    }

    public void ExitGame(){
        _onFade = Application.Quit;

        CallFadeIn();
    }

    private void CallFadeOut(){
        StartCoroutine(FadeCoroutine(fadeOutTime, fadeOutColor));
    }

    private void CallFadeIn(){
        StartCoroutine(FadeCoroutine(fadeInTime, fadeInColor));
    }

    private void CallLoadScene(){
        StartCoroutine(LoadSceneCoroutine(_scenNameToLoad));
    }

    private IEnumerator FadeCoroutine(float targetTime, Color targetColor){
        float totalTime = 0f;
        while (totalTime < targetTime)
        {
            totalTime += Time.deltaTime;
            float t = totalTime / targetTime;

            yield return new WaitForSeconds(Time.deltaTime);

            foreground.color = Color.Lerp(_imageColor, targetColor, t);
        }

        _imageColor = targetColor;
        
        _onFade?.Invoke();
        _onFade = null;
    }

    private IEnumerator LoadSceneCoroutine(string sceneName){
        yield return new WaitForSeconds(fadeInTime);

        AsyncOperation asyncLoadLevel = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!asyncLoadLevel.isDone){
            yield return null;
        }

        _onLoadScene?.Invoke();
        _onLoadScene = null;
    }
}
