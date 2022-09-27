using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Damageable player;
    [SerializeField] GameObject gameOverObject;

    // Update is called once per frame
    void Update()
    {
        if (!player.IsAlive())
            gameOverObject.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("FirstScene");
    }
}
