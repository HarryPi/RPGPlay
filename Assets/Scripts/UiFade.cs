using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFade : MonoBehaviour {

    public static UiFade instance;
    
    public Image fadeScreen;
    public float fadeSpeed;

    private bool _shouldFadeToBlack;
    private bool _shouldFadeFromBlack;

    // Start is called before the first frame update
    void Start() {
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update() {
        if (_shouldFadeToBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f) {
                _shouldFadeToBlack = false;
            }
        }

        if (_shouldFadeFromBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f) {
                _shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack() {
        _shouldFadeToBlack = true;
        _shouldFadeFromBlack = false;
    }

    public void FadeFromBlack() {
        _shouldFadeToBlack = false;
        _shouldFadeFromBlack = true;
    }
}