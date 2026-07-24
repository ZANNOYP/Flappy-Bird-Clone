using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 退出游戏按钮
/// </summary>
public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void ExitGame()
    {
        MusicManager.Instance.PlayButtonEff(1f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
