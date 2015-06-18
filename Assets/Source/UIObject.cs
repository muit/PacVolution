using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class UIObject : MonoBehaviour {
    public bool enabledOnStart = true;
    public bool disableOnAction = true;
    public StartEvent onStart;
    [Space(20)]
    public string[] listenKeys;
    public float actionDelay = 0.0f;
    public KeyPressEvent onKeyPress;

    private bool enabled = true;

    void Start()
    {
        enabled = enabledOnStart;
        onStart.Invoke();
    }

    void Update() {
        if (enabled)
        {
            for (int i = 0; i < listenKeys.Length; i++)
            {
                if (Input.GetKeyDown(listenKeys[i]))
                {
                    StartCoroutine(KeyPress());
                    return;
                }
            }
        }
    }

    IEnumerator KeyPress()
    {
        yield return new WaitForSeconds(actionDelay);
        onKeyPress.Invoke();

        if (disableOnAction) enabled = false;
    }



    [System.Serializable]
    public class StartEvent : UnityEvent { };

    [System.Serializable]
    public class KeyPressEvent : UnityEvent { };

    public void Enable(bool value = true) {
        enabled = value;
    }
}
