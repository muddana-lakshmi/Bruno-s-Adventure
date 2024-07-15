using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Panel : MonoBehaviour
{
    // Start is called before the first frame update
    public float animationDuration = 1.0f;
    public void PLAY()
    {
        SceneManager.LoadScene("Second Scene");
    }
    public void start()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void story()
    {
        SceneManager.LoadScene("Story");
    }
    public void Next()
    {
        SceneManager.LoadScene("Instruction2");
    }
    public void Play()
    {
        SceneManager.LoadScene("Second Panel");
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void close()
    {
        SceneManager.LoadScene("Main Panel");
    }
}
