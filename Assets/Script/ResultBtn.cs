using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultBtn : MonoBehaviour {

    public void RestartBtn()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Ingame");
    }

}
