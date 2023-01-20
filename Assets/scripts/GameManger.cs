using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject StartPanel;
    bool getStarted = false;
    public GameObject pipe;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetKeyDown(KeyCode.Mouse0)) && ( getStarted == false))
        {
            Time.timeScale = 1;
            StartCoroutine(creatPipe());
            getStarted = true;
            StartPanel.SetActive(false);
        }
        
        
    }
    
    IEnumerator creatPipe()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = new Vector3(6, Random.Range(-0f, 6f), 0);

        StartCoroutine(creatPipe());
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
        
    
}
