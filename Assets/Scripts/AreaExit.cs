﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

    public string areaToLoad;
    public string areaTransitionName;

    public AreaEntrance entrance;

    // Start is called before the first frame update
    void Start() {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(areaToLoad);
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}