using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevelObjects : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
