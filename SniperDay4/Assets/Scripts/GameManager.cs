using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static Canvas canvas;

    public int stageNum;

    public int total;
    public int score;
    public GameObject player;
    public string sceneName;
    public GameObject unitychan;
    public Animator animator;
    GameObject child2;
    GameObject child3;

    // AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindAnyObjectByType<Canvas>();
        SceneManager.sceneLoaded += OnSceneLoaded;
        child2 = canvas.transform.GetChild(2).gameObject;
        child3 = canvas.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "Title")
        {
            child2.SetActive(false);
            child3.SetActive(false);

            if (Input.GetButtonDown("Submit"))
            {
                SceneManager.LoadScene("StageMenu");
                
                // hide image
                GameObject child0 = canvas.transform.GetChild(0).gameObject;
                if(child0 != null) 
                {
                    child0.SetActive(false);
                }

                // hide text
                GameObject child1 = canvas.transform.GetChild(1).gameObject;
                if(child1 != null) 
                {
                    child1.SetActive(false);
                }
            }
        }
        else if(sceneName == "Stage1")
        {
            // when Lose
            if (player != null)
            {
                if (!player.gameObject.activeInHierarchy)
                    SceneManager.LoadScene("Lose");
            }   

            // when Win
            if(total == score) 
            {
                Debug.Log("Win ¾À ·Îµå");
                SceneManager.LoadScene("Win");
            }

            // score show
            child2.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
            child2.SetActive(true);

            // left ball show
            child3.GetComponent<TextMeshProUGUI>().text = "Left ball: " + (total - score).ToString();
            child3.SetActive(true);

        }
        else if(sceneName == "Stage2")
        {            
            // when Lose
            if (player != null)
            {
                if (!player.gameObject.activeInHierarchy)
                    SceneManager.LoadScene("Lose");
            }   

            // when Win
            if(total == score) 
            {
                Debug.Log("Win ¾À ·Îµå");
                SceneManager.LoadScene("Win");
            }

            // score show
            child2.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
            child2.SetActive(true);

            // left ball show
            child3.GetComponent<TextMeshProUGUI>().text = "Left ball: " + (total - score).ToString();
            child3.SetActive(true);

        }
        else if(sceneName == "Win")
        {
            child2.SetActive(false);
            child3.SetActive(false);
            animator.SetBool("Win", true);
            
            // AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            
            if (Input.GetButtonDown("Submit"))
                SceneManager.LoadScene("StageMenu");
        }
        else if(sceneName == "Lose")
        {
            child2.SetActive(false);
            child3.SetActive(false);
            animator.SetBool("Lose", true);

            // AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            
            if(Input.GetButtonDown("Submit"))
                SceneManager.LoadScene("StageMenu");
        }
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode Mode)
    {

        sceneName = SceneManager.GetActiveScene().name;
        total = GameObject.FindGameObjectsWithTag("Ball").Length;
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        unitychan = GameObject.FindGameObjectWithTag("unitychan");
        if(unitychan != null) 
        {
            animator = unitychan.GetComponent<Animator>();
            // audioSource = unitychan.GetComponent<AudioSource>();
        }
        child2 = canvas.transform.GetChild(2).gameObject;
        child3 = canvas.transform.GetChild(3).gameObject;
    }
}
