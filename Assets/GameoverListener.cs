using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverListener : SingletonMonoBehavior<GameoverListener>
{

    [SerializeField] CommonUIText TimePassedText;
    [SerializeField] CommonUIText TimesText;
    [SerializeField] GameObject GlobalCanvas;

    public void OnGameOver()
    {
        Saver.ClearSave();
        Destroy(gameObject);
        StatusControll.ToNewStatus(new GameoverStatus());
        TimePassedText.UpdateText();
        TimesText.UpdateText();
        GlobalCanvas.SetActive(false);
    }
}
