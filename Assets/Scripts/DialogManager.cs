using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;

    public static DialogManager instance;

    private bool _justStarted;
    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        if (dialogBox.activeInHierarchy) {
            if (Input.GetButtonUp("Fire1")) {
                if (!_justStarted) {
                    currentLine++;

                    if (currentLine >= dialogLines.Length) {
                        dialogBox.SetActive(false);
                        PlayerController.instance.canMove = true;
                    } else {
                        CheckIfName();

                        dialogText.text = dialogLines[currentLine];
                    }
                } else {
                    _justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines) {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();
        
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        _justStarted = true;
        PlayerController.instance.canMove = false;
    }

    public void CheckIfName() {
        if (dialogLines[currentLine].StartsWith("n-")) {
            nameText.text = dialogLines[currentLine].Replace("n-", string.Empty);
            currentLine++;
        }
    }
}