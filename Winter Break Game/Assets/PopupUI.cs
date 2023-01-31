using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class PopupUI : MonoBehaviour
{
    private static PopupUI _instance;
    public static PopupUI Instance { get { return _instance; } }

    [Header("UI")]
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI header;
    [SerializeField] TextMeshProUGUI text;

    Vector2 Origin;
    Vector2 PopPos;
    RectTransform rectTransform; 


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        rectTransform = GetComponent<RectTransform>();

        Origin = transform.position;
        PopPos = new Vector2(transform.position.x - rectTransform.rect.width, transform.position.y);
    }

    public async Task Pop(PopupUiData data, float transitionSpeed, float displayTime)
    {
        SetData(data);
        await Popin(transitionSpeed);
        await Task.Delay((int)(displayTime*1000));
        await Popout(transitionSpeed);
    }

    void SetData(PopupUiData data)
    {
        image.sprite = data.image;
        header.text = data.header;
        text.text = data.text;
    }

    async Task Popin(float speed)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        while(percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            rectTransform.position = Vector3.Lerp(Origin, PopPos, percentComplete);

            await Task.Yield();
        }
    }

    async Task Popout(float speed)
    {
        float elapsedTime = 0;
        float percentComplete = 0;

        while (percentComplete < 1)
        {
            elapsedTime += Time.deltaTime;
            percentComplete = elapsedTime / speed;

            rectTransform.position = Vector3.Lerp(PopPos, Origin, percentComplete);

            await Task.Yield();
        }
    }
}
