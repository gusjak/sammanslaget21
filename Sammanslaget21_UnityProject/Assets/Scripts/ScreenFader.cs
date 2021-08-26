
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenFader : MonoBehaviour
{

    public static ScreenFader instance;

    private Animator animator;

    public string levelToLoad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        

    }

    public void FadeToLevel(string levelName)
    {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeIn");

    }


}
