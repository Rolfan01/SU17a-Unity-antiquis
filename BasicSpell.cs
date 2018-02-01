using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpell : MonoBehaviour
{

    public GameObject spellCaster;
    public GameObject spell;
    public float spellForce;
    private float timestamp;

    public float spellLifeTime;     // How long it takes before the spell is destroyed
    public float timeBetweenSpells = 0.3333f;  // Allows 3 shots per second

    void Update()
    {
        Cast();
    }

    void Cast()
    {
        if  (Time.time >= timestamp && (Input.GetMouseButtonDown(0)))
        {
            GameObject tempSpell;
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            tempSpell = Instantiate(spell, spellCaster.transform.position, rotation) as GameObject;

            Rigidbody2D tempRigidbody;
            tempRigidbody = tempSpell.GetComponent<Rigidbody2D>();
            
            tempRigidbody.AddForce(tempSpell.transform.right * spellForce, ForceMode2D.Impulse);      // This means that it gets diffrent force depending on where on the screen you click which is a bit trubbeling but fine for now
                                                                                                    // Wanted to test ForceMode2D and it worked fine 

            timestamp = Time.time + timeBetweenSpells;

            Destroy(tempSpell, spellLifeTime);
        }
    }

}
