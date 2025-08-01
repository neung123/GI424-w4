using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ImageSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform _parent;

    [SerializeField]
    private int _count;

    [SerializeField]
    private List<Sprite> _sprites;

    [SerializeField]
    private bool _useSpriteAtlas;

    [SerializeField]
    private SpriteAtlas _spriteAtlas;

    [SerializeField]
    private List<string> _atlasSpriteNames;

    private void Start()
    {
        for (int i = 0; i < _count; i++)
        {
            GameObject imgGO = new GameObject("Image_" + i, typeof(RectTransform), typeof(Image));
            imgGO.transform.SetParent(_parent, false);

            Image img = imgGO.GetComponent<Image>();

            Sprite spriteToUse = null;

            if (_useSpriteAtlas && _spriteAtlas != null && _atlasSpriteNames.Count > 0)
            {
                string spriteName = _atlasSpriteNames[i % _atlasSpriteNames.Count];
                spriteToUse = _spriteAtlas.GetSprite(spriteName);
            }
            else if (_sprites.Count > 0)
            {
                spriteToUse = _sprites[i % _sprites.Count];
            }

            img.sprite = spriteToUse;

            RectTransform rt = imgGO.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(100, 100);

            int columns = 10;
            float spacing = 10f;
            int row = i / columns;
            int col = i % columns;
            rt.anchoredPosition = new Vector2(col * (100 + spacing), -row * (100 + spacing));
        }
    }
}