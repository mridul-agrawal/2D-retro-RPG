using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target;
    public Tilemap map;

    private Vector2 minBound;
    private Vector2 maxBound;
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        target = PlayerManager.instance.transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        
        minBound = map.localBounds.min + new Vector3(halfWidth, halfHeight);
        maxBound = map.localBounds.max + new Vector3(-halfWidth, -halfHeight);

        PlayerManager.instance.SetPlayerBoundaries(map.localBounds.min,map.localBounds.max);
    }

    void LateUpdate()
    {

        FollowPlayer();

    }

    private void FollowPlayer()
    {
        this.transform.position = new Vector3(Mathf.Clamp(target.position.x, minBound.x, maxBound.x),
            Mathf.Clamp(target.position.y, minBound.y, maxBound.y),
            this.transform.position.z);
    }

}
