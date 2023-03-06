using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerHeartUI : MonoBehaviour
{
    [SerializeField] float heartGap; 
    [SerializeField] Sprite Heart;
    [SerializeField] Sprite NoHeart;

    Character player;

    List<Image> hearts = new List<Image>();

    public void Start()
    {
        player = Character.GetPlayer();

        for(int i = 0; i < player.statsHandler.GetStat("Max Hearts"); i++)
        {
            Image heart = UiManager.GetImage(Heart);
            heart.transform.SetParent(transform);
            heart.transform.localPosition = new Vector3(i * heartGap, 0);

            hearts.Add(heart);
        }

        player.eventManager.OnDamaged.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        foreach (Image o in hearts) o.sprite = Heart;

        for(int i = 0; i < player.statsHandler.GetStat("Max Hearts")-player.statsHandler.GetStat("Hearts"); i++)
        {
            hearts[i].sprite = NoHeart; 
        }
    }
}
