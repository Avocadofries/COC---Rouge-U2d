using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptionsController : MonoBehaviour {
    GameObject OptionsMenu;
	// Use this for initialization
	void Start () {
        OptionsMenu = GameObject.Find("Main Camera/PlayerCanvas/OptionsMenu");


        GameObject Options = GameObject.Find("Main Camera/PlayerCanvas/Options");
        Button OptionsButton= (Button)Options.GetComponent<Button>();
        OptionsButton.onClick.AddListener(ShowMenu);

        GameObject Continue = GameObject.Find("Main Camera/PlayerCanvas/OptionMenu/ContinueButton");
        Button ContinueButton = (Button)Continue.GetComponent<Button>();
        ContinueButton.onClick.AddListener(GoContinue);

        GameObject Settings = GameObject.Find("Main Camera/PlayerCanvas/OptionMenu/SettingsButton");
        Button SettingsButton = (Button)Settings.GetComponent<Button>();
        SettingsButton.onClick.AddListener(GoSettings);

        GameObject Load = GameObject.Find("Main Camera/PlayerCanvas/OptionMenu/LoadButton");
        Button LoadButton = (Button)Load.GetComponent<Button>();
        SettingsButton.onClick.AddListener(GoLoading);

        GameObject Save = GameObject.Find("Main Camera/PlayerCanvas/OptionMenu/SaveButton");
        Button SaveButton = (Button)Settings.GetComponent<Button>();
        SettingsButton.onClick.AddListener(GoSaving);

        GameObject Exit = GameObject.Find("Main Camera/PlayerCanvas/OptionMenu/ExitButton");
        Button ExitButton = (Button)Settings.GetComponent<Button>();
        SettingsButton.onClick.AddListener(GoExiting);





    }

    void ShowMenu()
    {
        OptionsMenu.SetActive(true);
    }

    void GoContinue()
    {

    }

    void GoSettings()
    {

    }

    void GoSaving()
    {

    }

    void GoLoading()
    {

    }

    void GoExiting()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
