using strange.extensions.mediation.impl;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class IconCounterView : View
{
    [SerializeField] private Transform container;
    [SerializeField] private GameObject iconPrefab;
    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Sprite emptySprite;

    private readonly List<Image> icons = new List<Image>();

    public void Initialize(int count)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }

        icons.Clear();

        for (int i = 0; i < count; i++)
        {
            GameObject icon = Instantiate(iconPrefab, container);
            Image iconImage = icon.GetComponentInChildren<Image>();
            iconImage.sprite = fullSprite;
            icons.Add(iconImage);
        }
    }

    public void SetCount(int activeCount)
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].sprite = i < activeCount ? fullSprite : emptySprite;
        }
    }
}
