using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    
    [HideInInspector] public UIHealth u�Health;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameManager");
                instance = go.AddComponent<GameManager>();
               
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private int _health = 1;
    public int health
    {
        get
        {
            return _health;
        }

        set
        {
            if (_health != value)
            {
                if (_health > value)
                {
                    //can azald�
                }
                if (_health < value)
                {
                    //can art�
                }

                _health = value;

                if (_health <= 0)
                {
                    //karkter �ld�
                }

                u�Health?.UIUpdate(value);
            }
        }
    }

    private void Start()
    {
        u�Health?.UIUpdate(health);
    }

    private void Update()
    {
        u�Health?.UIUpdate(health);
    }

    public void RLoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}
