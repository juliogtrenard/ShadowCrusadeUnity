using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager instance;
    [Header("NETWORK JOIN")]
    [SerializeField] bool startGameAsClient;

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
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (startGameAsClient)
        {
            startGameAsClient = false;
            // Primero hay que apagar el host para comenzar como cliente, porque comenzamos como host en el title screen
            NetworkManager.Singleton.Shutdown();

            // Reiniciamos como cliente
            NetworkManager.Singleton.StartClient();
        }
    }
}
