using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    private TNManager tnManager;

	void Start () {
        tnManager = FindObjectOfType<TNManager>();
	}
	
	void Update () {
	    
	}
    

    /**************
     * Networking *
     **************/

    [Header("Networking")]
    public int tcpPort = 5127;
    public int udpPort = 5128;
    public string mainLevel = "Map";

    public void Play() {
        TNManager.LoadLevel(mainLevel);
    }

    public void Connect(InputField ipInput) {
        Connect(ipInput.text);
    }

    public void Connect(string ip) {
        if (ip == null || ip.Length <= 0) return;

        TNAutoJoin autoJoin = tnManager.GetComponent<TNAutoJoin>();
        autoJoin.serverPort = tcpPort;
        autoJoin.firstLevel = mainLevel;
        autoJoin.serverAddress = ip;
        autoJoin.Connect();
    }

    public void CreateSession(){
        TNServerInstance.Start(5127, 5128);
        TNManager.LoadLevel(mainLevel);
    }

}
