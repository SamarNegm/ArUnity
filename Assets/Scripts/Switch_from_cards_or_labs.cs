using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_from_cards_or_labs : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");

        }
    }
    public void learn_scene()
    {

        SceneManager.LoadScene("labLayout2");
    }
    public void cards()
    {

        SceneManager.LoadScene("cards");
    }


}
