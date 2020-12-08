using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] GameObject misslePrefab;
    [SerializeField] GameObject missleLauncherPrefab;

    [SerializeField] private Texture2D curserTexture;
    private Vector2 cursorHotspot;


    private GameController myGameController;


    // Start is called before the first frame update
    void Start()
    {
        myGameController = GameObject.FindObjectOfType<GameController>();
        cursorHotspot = new Vector2(curserTexture.width / 2f, curserTexture.height / 2f);
        Cursor.SetCursor(curserTexture, cursorHotspot, CursorMode.Auto);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && myGameController.playerMissilesLeft > 0)
        {
            Instantiate(misslePrefab, missleLauncherPrefab.transform.position, Quaternion.identity);
            myGameController.playerMissilesLeft--;
            myGameController.UpdateMissilesLeft();
        }
    }
}
