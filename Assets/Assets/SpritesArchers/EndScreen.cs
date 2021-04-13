using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour {

    public GameObject screen;
    public Boss isDeath;


    void Start()
    {
        isDeath = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
    }


    private void Update()
    {
        if(isDeath.isDead == true)
        {
            screen.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }

}
