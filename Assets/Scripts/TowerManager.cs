using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance; //de�i�tirilmez

    private void Awake() //start fonksiyonundan �nce ger�ekle�ir
    {
        instance = this; //this script anlam�nda
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

            if (Input.GetMouseButtonDown(0)) // kuleleri mape koymam�za yar�yor
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
