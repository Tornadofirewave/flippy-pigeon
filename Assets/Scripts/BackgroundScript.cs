using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private GameObject backgroundPrefab;
    [SerializeField] private int numberOfBackgrounds = 2;

    private List<GameObject> backgrounds = new List<GameObject>();
    private float backgroundWidth;

    private void Start()
    {
        if (backgroundPrefab == null)
        {
            Debug.LogError("Background prefab is not assigned!");
            return;
        }

        InitializeBackgrounds();
    }

    private void Update()
    {
        MoveBackgrounds();
    }

    private void InitializeBackgrounds()
    {
        backgroundWidth = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        for (int i = 0; i < numberOfBackgrounds; i++)
        {
            SpawnBackground(i * backgroundWidth);
        }
    }

    private void MoveBackgrounds()
    {
        for (int i = backgrounds.Count - 1; i >= 0; i--)
        {
            GameObject bg = backgrounds[i];
            bg.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            if (bg.transform.position.x < -backgroundWidth)
            {
                RecycleBackground(bg, i);
            }
        }
    }

    private void SpawnBackground(float xPosition)
    {
        GameObject newBg = Instantiate(backgroundPrefab, new Vector3(xPosition, 0, 0), Quaternion.identity, transform);
        backgrounds.Add(newBg);
    }

    private void RecycleBackground(GameObject bg, int index)
    {
        backgrounds.RemoveAt(index);
        float newXPosition = backgrounds[backgrounds.Count - 1].transform.position.x + backgroundWidth;
        bg.transform.position = new Vector3(newXPosition, 0, 0);
        backgrounds.Add(bg);
    }
}