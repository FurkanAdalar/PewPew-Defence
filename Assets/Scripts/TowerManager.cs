using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance; //deðiþtirilmez

    private void Awake() //start fonksiyonundan önce gerçekleþir
    {
        instance = this; //this script anlamýnda
    }

    public Tower activeTower;

    public Transform indicator;
    public bool isPlacing;

    public LayerMask whatIsPlacement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlacing)
        {
            indicator.position = GetGridPosition();

            if (Input.GetMouseButtonDown(0)) // kuleleri mape koymamýza yarýyor
            {
                isPlacing = false;

                Instantiate(activeTower, indicator.position,activeTower.transform.rotation);

                indicator.gameObject.SetActive(false);
            }
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;

        isPlacing = true;

        indicator.gameObject.SetActive(true);
    }

    public Vector3 GetGridPosition()
    {
        Vector3 location = Vector3.zero; //no values

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 200f,Color.red);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 200f, whatIsPlacement))
        {
            location = hit.point;
        }
        location.y = 0f;

        return location;
    }
}
