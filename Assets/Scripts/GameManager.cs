using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool GameStarted { get; private set; }
    public bool GameEnded { get; private set; }

    [SerializeField] private float slowMotionfactor = 0.1f;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform goaltransform;
    [SerializeField] private BallFollow ball;


    public float enitreDistance { get; private set; }
    public float distnaceleft { get; private set; }

    private void Start()
    {
        enitreDistance = goaltransform.position.z - startTransform.position.z;
    }

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
    }

   public void StartGame()

    {
        GameStarted = true;
        Debug.Log("start");
    }

    public void EndGame(bool win)
    {
        GameEnded = true;
        Debug.Log("Game Over");
        if(!win)
        {
            Invoke("RestartGame", 2 * slowMotionfactor);
            Time.timeScale = slowMotionfactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else
        {
            Invoke("loadNextLevel", 2);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
       
    }
    public void loadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  

    private void Update()
    {
        distnaceleft = Vector3.Distance(ball.transform.position, goaltransform.position);

        if(distnaceleft > enitreDistance)
        {
            distnaceleft = enitreDistance;
        }

        if(ball.transform.position.z > goaltransform.transform.position.z)
        {
            distnaceleft = 0;
        }

    }

}
