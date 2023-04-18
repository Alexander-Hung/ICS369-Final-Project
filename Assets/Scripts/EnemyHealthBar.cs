using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    RectTransform canvasTransform;
    public Canvas canvas;

    public Transform enemyPosition;
    public Vector3 offset;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        canvasTransform = canvas.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = enemyPosition.TransformPoint(offset);

        Vector3 viewportPoint = cam.WorldToViewportPoint(worldPos);

        viewportPoint -= 0.5f * Vector3.one;
        viewportPoint.z = 0;

        Rect rect = canvasTransform.rect;
        viewportPoint.x *= rect.width;
        viewportPoint.y *= rect.height;

        if (transform.localPosition != (viewportPoint))
        {
            transform.localPosition = viewportPoint;
        }
    }
}
