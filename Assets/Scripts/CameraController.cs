using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Tilemap map;

    private Vector3 _bottomLeftLimit;
    private Vector3 _topRightLimit;
    private float _halfHeight;
    private float _halfWidth;

    // Start is called before the first frame update
    void Start() {
        target = PlayerController.instance.transform;
        Bounds localBounds = map.localBounds;

        _halfHeight = Camera.main.orthographicSize;
        _halfWidth = _halfHeight * Camera.main.aspect;
        
        // Gets the furthest to the left on the x axis and furthest down on the y axis
        _bottomLeftLimit = localBounds.min + new Vector3(_halfWidth, _halfHeight, 0f); 
        _topRightLimit = localBounds.max - new Vector3(_halfWidth, _halfHeight, 0f);
    }

    // LateUpdate is called once per frame after update
    void LateUpdate() {
        Vector3 position = transform.position;

        position = new Vector3(target.position.x, target.position.y, position.z);

        // Keep the camera inside the bounds
        position = new Vector3(
            Mathf.Clamp(position.x, _bottomLeftLimit.x, _topRightLimit.x),
            Mathf.Clamp(position.y, _bottomLeftLimit.y, _topRightLimit.y), position.z);
        transform.position = position;
    }
}