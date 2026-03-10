using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBootstrap : MonoBehaviour
{
    [SerializeField]
    private KeyboardInputService keyboardInputService;
    [SerializeField]
    private TouchInputService touchInputService;
    [SerializeField]
    private Bird bird;

    private BirdLogic birdLogic;
    private void Awake()
    {
#if UNITY_STANDALONE_WIN
        birdLogic = new BirdLogic(keyboardInputService, bird);
#elif UNITY_ANDROID
        birdLogic = new BirdLogic(touchInputService, bird);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        birdLogic.Tick();
    }
}
