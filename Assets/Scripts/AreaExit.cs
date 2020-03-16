using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string nextArea;
    public string transitionName;
    public AreaEntrance entrance;

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    void Start()
    {
        entrance.transitionName = this.transitionName;
    }

    void Update()
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(nextArea);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D _collider)
    {
        if(_collider.tag == "Player")
        {
            shouldLoadAfterFade = true;
            UIFade.instance.FadeToBlack();
            PlayerController.instance.lastTransition = transitionName;
        }
    }
}
