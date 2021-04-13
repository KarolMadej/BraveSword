using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour {

    string readMeText;
    public void PlayGame()
    {
        SceneManager.LoadScene("MapaPierwsza");
        File.WriteAllText("Save.txt", "1");
    }

    public void LoadGame()
    {
        using (StreamReader readtext = new StreamReader("Save.txt"))
        {
            readMeText = readtext.ReadLine();
        }
    
        if(readMeText == "1")
        SceneManager.LoadScene("MapaPierwsza");
        if (readMeText == "2")
        SceneManager.LoadScene("MapaDruga");
        if (readMeText == "3")
        SceneManager.LoadScene("MapaTrzecia");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
