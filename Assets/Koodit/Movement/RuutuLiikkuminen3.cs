using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using UnityEngine.SceneManagement;

public class RuutuLiikkuminen3 : MonoBehaviour
{
    public bool Kypärä;
    public int KypäränHealth;
    public bool liikkunut;
    public int PelaajanHealth;
    public string PelaajaViimeliike;
    public string l;
    public Vector3 pos;                                // For movement
    
    public float speed = 0.02f;                         // Speed of movement

    public static RuutuLiikkuminen3 Instance;

    string viimepositiox = @"C:\Tiedontallennusharjoitus\Viimepositiotiedostox.txt";
    string viimepositioy = @"C:\Tiedontallennusharjoitus\Viimepositiotiedostoy.txt";
    string viimepositioz = @"C:\Tiedontallennusharjoitus\Viimepositiotiedostoz.txt";
    string nykyinenpositio = @"C:\Tiedontallennusharjoitus\Nykyinenpositiotiedosto.txt";


    void Awake()
    {
        //SceneManager.LoadScene("HamsteriScene");
        Instance = this;
    }

        public void Start()
    {
        PelaajanHealth = 60;
        liikkunut = false;
        pos = transform.position;          // Take the initial position
 
        File.WriteAllText(viimepositiox, pos.x.ToString());
        File.WriteAllText(viimepositioy, pos.y.ToString());
        File.WriteAllText(viimepositioz, pos.z.ToString());

    }

    public void Update()
    {
        if (PelaajanHealth <= 0)
        {
            SceneManager.LoadScene("HamsteriScene");
            //Application.LoadLevel(Application.loadedLevel);
        }
        if (Kypärä == true)
        {
            
            if (KypäränHealth <= 0)
            {
                Kypärä = false;
            }
        }
    }
    public void FixedUpdate()
    {
        liikkunut = false;

        if (VihuLiikkuminen.Instance.vihuliikkunut==false)
        {
            liikkunut = true;
            return;
        }
        else if (transform.position == pos&&VihuLiikkuminen.Instance.vihuliikkunut==true)
        {
            
            l = "ei saa liikkua";
            if (Input.GetKey(KeyCode.A) && transform.position == pos)
            {        // Left

                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.left;
                PelaajaViimeliike = "vasen";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == pos)
            {        // Right
                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.right;
                PelaajaViimeliike = "oikea";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
            }
            if (Input.GetKey(KeyCode.W) && transform.position == pos)
            {        // Up
                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.up;
                PelaajaViimeliike = "ylös";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == pos)
            {        // Down
                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.down;
                PelaajaViimeliike = "alas";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
            }
        }

            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
        

        if (transform.position==pos)
        {
            File.WriteAllText(nykyinenpositio, pos.ToString());
        }

     

        
        
        




    }
 
}