using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public GameObject backgroundPrefab;
    public int numberOfBackgrounds = 2;

    private List<GameObject> backgrounds = new List<GameObject>();
    private float backgroundWidth;

    void Start()
    {
        if (backgroundPrefab == null)
        {
            Debug.LogError("Background prefab is not assigned!");
            return;
        }

        // Get the width of the background
        backgroundWidth = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        // Spawn initial backgrounds
        for (int i = 0; i < numberOfBackgrounds; i++)
        {
            SpawnBackground(i * backgroundWidth);
        }
    }

    void Update()
    {
        // Move all backgrounds
        for (int i = backgrounds.Count - 1; i >= 0; i--)
        {
            GameObject bg = backgrounds[i];
            bg.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // If a background has moved off screen, destroy it and spawn a new one
            if (bg.transform.position.x < -backgroundWidth)
            {
                backgrounds.RemoveAt(i);
                Destroy(bg);
                SpawnBackground(backgrounds[backgrounds.Count - 1].transform.position.x + backgroundWidth);
            }
        }
    }

    void SpawnBackground(float xPosition)
    {
        GameObject newBg = Instantiate(backgroundPrefab, new Vector3(xPosition, 0, 0), Quaternion.identity);
        newBg.transform.SetParent(transform);
        backgrounds.Add(newBg);
    }
}