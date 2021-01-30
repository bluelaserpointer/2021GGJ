using UnityEngine;
using UnityEngine.SceneManagement;

public class TransportSpot : MonoBehaviour
{
    [Header("来自<<<")]
    public string comeFromScene;

    [Header("去往>>>")]
    public string gotoScene;
    public bool needInteraction;

    void Start()
    {
        if (comeFromScene == Player.lastScene)
        {
            Instantiate(Resources.Load("PlayerVer1"), transform, false);
        }
    }
    public void Transport()
    {
        SceneManager.LoadScene(gotoScene);
    }
}
