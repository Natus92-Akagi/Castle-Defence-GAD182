using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour
{
     public static buttonManager Instance;
     public static int chosenWeaponType;

    public static void buttonArrow()
    {
        SceneManager.LoadScene("SampleScene"); 
        chosenWeaponType = 1;
    }

        public static void buttonBurst()
        {
            SceneManager.LoadScene("SampleScene"); 
            chosenWeaponType = 2;
        }

            public static void buttonExplosion()
            {
                SceneManager.LoadScene("SampleScene"); 
                chosenWeaponType = 3;
            }

                public static void buttonSnipe()
                {
                    SceneManager.LoadScene("SampleScene"); 
                    chosenWeaponType = 4;
                }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}