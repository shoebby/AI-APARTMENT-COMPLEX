using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;


public class SurveillanceCameraScript : MonoBehaviour
{
    [SerializeField] private bool horizontalMovement = false;
    [SerializeField] private bool verticalMovement = false;
    [SerializeField] private float borderLeft = 10;
    [SerializeField] private float borderRight = 10;
    [SerializeField] private float borderTop = 10;
    [SerializeField] private float borderBottom = 10;

    [SerializeField] private float rotSpeed = 35;

    [SerializeField] private bool canZoom = false;
    [SerializeField] private Camera cam;

    public GameObject nextCam;
    private GameObject PSXRenderer;
    private SpriteRenderer camOverlay;

    [SerializeField] private Sprite camOverlay_sprite;
    [SerializeField] private Sprite camOverlay_null;

    [SerializeField] private Volume PPVolume;

    void Start()
    {
        PSXRenderer = GameObject.FindGameObjectWithTag("PSXRenderer");
        camOverlay = PSXRenderer.GetComponentInChildren<SpriteRenderer>();
        cam = GetComponent<Camera>();

        if (camOverlay_sprite != null)
            camOverlay.sprite = camOverlay_sprite;
        else
            camOverlay.sprite = camOverlay_null;
    }

    void Update()
    {
        float currentH = transform.localRotation.eulerAngles.y;
        float currentV = transform.localRotation.eulerAngles.x;

        if (horizontalMovement)
        {
            if (Input.GetKey(KeyCode.A) && currentH >= borderLeft)
                transform.Rotate(0, -rotSpeed * Time.deltaTime, 0, Space.World);
            if (Input.GetKey(KeyCode.D) && currentH <= borderRight)
                transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
        }

        if (verticalMovement)
        {
            if (Input.GetKey(KeyCode.W) && currentV >= borderTop)
                transform.Rotate(-rotSpeed * Time.deltaTime, 0, 0, Space.Self);
            if (Input.GetKey(KeyCode.S) && currentV <= borderBottom)
                transform.Rotate(rotSpeed * Time.deltaTime, 0, 0, Space.Self);
        }

        if (canZoom)
        {
            if (Input.GetKeyDown(KeyCode.Q) && cam.fieldOfView < 60f)
                cam.fieldOfView += 15f;
            if (Input.GetKeyDown(KeyCode.E) && cam.fieldOfView > 15f)
                cam.fieldOfView -= 15f;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            nextCam.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}