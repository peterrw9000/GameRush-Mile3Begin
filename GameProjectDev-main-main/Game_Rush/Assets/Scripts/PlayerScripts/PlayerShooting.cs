using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShooting : MonoBehaviour {

    public int laserDPS = 1;

    [SerializeField]
    float range = 1000;

    [SerializeField]
    float fireRate = 0.50f;

    [SerializeField]
    Image overHeat;

    [SerializeField]
    Image overHeat2;

    float timer;

    LineRenderer laserFire;

    RaycastHit hit;
    Ray ray;

    public float effectdisplay = 0.1f;

    public Transform laserOrigin;
    public Camera camera;
    public Text hitText;
    public TMP_Text TMPHitText;
  
    AudioManager audioManagement;
    AudioSource laserSound;

    int layerMask = 1 << 7;

    public bool paused;
    void OnPauseGame() {
        paused = true;
    }

    void OnResumeGame() {
        paused = false;
    }

    private void Awake()
    {
        audioManagement = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start() {
        laserFire = GetComponent<LineRenderer>();
        laserSound = GetComponent<AudioSource>();
        layerMask = ~layerMask;
    }

    void Update() {

        Vector3 mousePosition = Input.mousePosition;
        ray = camera.ScreenPointToRay(Input.mousePosition);

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= fireRate && Time.timeScale != 0 && !paused) {
            Shoot();
        }
        if (timer >= fireRate * effectdisplay) {
            laserFire.enabled = false;
        }   
    }

    public void Shoot() {
        laserFire.SetPosition(0, laserOrigin.position);
        timer = 0f;
        laserFire.enabled = true;
        laserSound.PlayOneShot(audioManagement.soundEffects[0]);
        if (Physics.Raycast(ray, out hit, 1000, layerMask)) {

            //Debug.Log(hit.collider.gameObject.name.ToString());

            if (hit.collider.tag == "WeakSpot")
            {
                WeakSpot weakspot = hit.collider.GetComponent<WeakSpot>();
                if (weakspot != null)
                {
                    weakspot.DamageToEnemy(laserDPS);
                    //DisplayCriticalText(weakspot.weakSpotDmg);
                    DisplayDamageText(weakspot.weakSpotDmg);
                }
            }
            if (hit.collider.tag == "EnemyRocket")
            {
                HomingRocket homingRocket = hit.collider.GetComponent<HomingRocket>();
                if(homingRocket != null)
                {

                    homingRocket.RocketDamage(laserDPS);
                    
                }
           
            }
            if (hit.collider.tag == "Enemy") {
                if (hit.collider.TryGetComponent(out EnemyHealth eH)) {
                    EnemyHealth enemyHealth = eH;
                    if (enemyHealth != null) {
                        enemyHealth.TakeDamage(laserDPS);
                        DisplayDamageText(laserDPS);
                    }
                }
                else if(hit.collider.TryGetComponent(out BossCore bC)) { 
                    BossCore bossCore = bC;
                    if (bossCore != null) {
                        bossCore.TryDamage(laserDPS);
                    }
                }
                else {
                    Debug.Log(hit.collider.gameObject.name.ToString());
                }  
            }
            laserFire.SetPosition(1, hit.point);
        }
        return;
    }

    public void DisplayDamageText(int damage) {
        if(hit.collider.tag == "Enemy")        { 

            Vector3 mousePosition = Input.mousePosition;
            //hitText.gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y + 10f, mousePosition.z);
            TMPHitText.gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y + 10f, mousePosition.z);
            //hitText.text = damage.ToString() + " Damage!";
            TMPHitText.text = damage.ToString() + " Damage!";

        }
        else if(hit.collider.tag == "WeakSpot")
        {
            Vector3 mousePosition = Input.mousePosition;
            //hitText.gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y + 10f, mousePosition.z);
            TMPHitText.gameObject.transform.position = new Vector3(mousePosition.x, mousePosition.y + 10f, mousePosition.z);
            //hitText.text = damage.ToString() + " Critical Hit!";
            TMPHitText.text = damage.ToString() + " Critical Hit!";            
        }
       
        
    }

}
/*                    Ray shootRay = new Ray();
    RaycastHit shootHit;
 *                shootRay.origin = camera.transform.position;
      shootRay.direction = transform.forward;

      if (Physics.Raycast(shootRay, out shootHit, range)) {
          if (shootHit.collider.tag == "Enemy") {
              EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
              if (enemyHealth != null) {
                  enemyHealth.TakeDamage(laserDPS);
              }
          }
          Debug.Log(shootHit.collider.gameObject.name.ToString());
          laserFire.SetPosition(1, shootHit.point);
      }*/