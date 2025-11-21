using UnityEngine;
using UnityEngine.SceneManagement;

public class towerControl : MonoBehaviour
{
    public int towerMaxHealth;
    public int towerCurrentHealth;
    //public bool gameOver = false;
    
    void Start()
    {
        towerCurrentHealth = towerMaxHealth;
    }

    void Update()
    {
        if (towerCurrentHealth <= 0)
        {
            SceneManager.LoadScene("Title"); 
        }
    }
}
