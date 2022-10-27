
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public bool DonotShoot = false;

    public float projectileSpeed;
    public float shootRate;
    private float lastShootTime;
    private int Credits;
   
    private int ShootLevel;
    private int ShootLevelMax;
    public TextMeshProUGUI ShootMultiplier;
    public GameObject core;
    public GameObject placeCoreButton;
    public TextMeshProUGUI CreditsUpdate;

   

    private Camera cam;

    public static Shooting instance;
    void Awake() { instance = this; }

    void Start()
    {
        ShootLevel = 1;
        ShootLevelMax = 20;
        Credits = PlayerPrefs.GetInt("gold");
        cam = Camera.main;
        core.SetActive(false);
    }

    void Update()
    {     
        CreditsUpdate.text = Credits.ToString();
        // shoot a projectile when we touch the screen
        if (Input.touchCount > 0 && DonotShoot == false)
        {
            
            if (Time.time - lastShootTime >= shootRate)
                Shoot();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            DonotShoot = true;
            return;
        }

    }

    // shoots a new projectile out from the camera
    void Shoot()
    {
        lastShootTime = Time.time;

        GameObject proj = Instantiate(projectilePrefab, cam.transform.position, Quaternion.identity);
        Credits = Credits - ShootLevel;
        

        proj.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
       
        
        Destroy(proj, 3);
    }

    // called when the "Place Core" button is pressed
    // places down the core and begins the game
 
    public void ChangeShootLevel()
    {
        DonotShoot = true;
            ShootLevel++;

            if (ShootLevel == ShootLevelMax)
            {
                ShootLevel = 0;
            }
        
        ShootMultiplier.text = ShootLevel.ToString();
        DonotShoot = false;
        
    }
}