using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class weapon : MonoBehaviour
{

    public GameObject pistolet;
    public GameObject projectile;
    public SpriteRenderer pistoletImage;
    private int angle;

    public int Angle { get => angle; set => angle = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Angle = 0;
    }
    // voir pixel art rotation
    // Update is called once per frame
    void Update()
    {
        RotateWeapon();
        FlipWeapon();
        FireWeapon();
    }

    private void RotateWeapon()
    {
        var position = Camera.main.WorldToScreenPoint(pistolet.transform.position);
        var dir = Input.mousePosition - position;
        angle = Mathf.RoundToInt(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        pistolet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void FlipWeapon()
    {
        var position = Camera.main.WorldToScreenPoint(pistolet.transform.position);
        var directionForFlip = Input.mousePosition.x - position.x;
        bool isFliped = directionForFlip > 0 ? false : true;
        pistoletImage.flipY = isFliped;
        //car l'image est dans le mauvais sens
        pistoletImage.flipX = true;

    }
    private void FireWeapon() {
        // Ctrl was pressed, launch a projectile
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the projectile at the position and rotation of this transform
            GameObject clone;
            //offset par rapport au canon
            Vector3 positionClone = pistolet.transform.position;
            positionClone.y += 0.4f;
            clone = Instantiate(projectile, positionClone, pistolet.transform.rotation);
            Destroy(clone, 3f);
            // Give the cloned object an initial velocity along the current
            // object's Z axis
            clone.transform.Translate(Vector3.forward * 10);
        }
    }
}
