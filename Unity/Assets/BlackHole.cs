using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHole : MonoBehaviour
{
    public string transportScene;

    public void Transport()
    {
        SceneManager.LoadScene(transportScene);
    }

}
