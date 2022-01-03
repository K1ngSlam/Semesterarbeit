using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ControllerKeyboardThirdLevel : SuperController
{
    // Start is called before the first frame update
    void Start()
    {
        List<KeyCode> codes = new List<KeyCode>();
        codes.Add(KeyCode.A);
        codes.Add(KeyCode.W);
        codes.Add(KeyCode.S);
        codes.Add(KeyCode.D);
        codes.Add(KeyCode.UpArrow);
        codes.Add(KeyCode.DownArrow);
        codes.Add(KeyCode.LeftArrow);
        codes.Add(KeyCode.RightArrow);
        codes.Add(KeyCode.Space);
        Debug.Log("Keyboard Level 3 Start");
        _key_codes = codes;
        Starter(KeyCode.Space, "Keyboard");
        nextButtonPressEnabled = true;
    }

    void Update()
    {
        if (Input.anyKeyDown && Isdone && nextButtonPressEnabled)
        {
            PlayerPrefs.SetFloat("LatestKeyboard3", reactionTimeAverage.Average());
            SceneManager.LoadScene("Main Menu");
        }
        else if (Input.anyKeyDown && nextButtonPressEnabled) //TODO: Nicht bei irgendeinem Key sondern nur bei den bestimmten Keys
        {
            Updater();
            StartCoroutine("DelayNextInput");
        }
    }
}