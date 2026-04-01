using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class TileMapStaff : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform highlight;
    public Tile flower;
    public CinemachineImpulseSource ImpulseSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3Int cellPos = tilemap.WorldToCell(mousePos);
        Vector3 pos = tilemap.GetCellCenterWorld(cellPos);

        highlight.position = pos;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            tilemap.SetTile(cellPos, flower);
            ImpulseSource.GenerateImpulse();
        }
    }
}
