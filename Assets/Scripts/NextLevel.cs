using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
        Panel.SetActive(false);
       
     

    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
