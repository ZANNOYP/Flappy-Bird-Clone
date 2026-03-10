using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 开始面板
/// </summary>
public class BeginPanel : BasePanel<BeginPanel>
{
    // 开始按钮
    public Button btnStart;
    // 鸟
    public Bird bird;

    protected override void Init()
    {
        btnStart.onClick.AddListener(() =>
        {
            SFXMgr.Instance.PlaySFX("btnEff", 0.5f);
            // 开始游戏
            GameMgr.Instance.StartGame();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
