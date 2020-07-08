using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HitEnemyBonusSunset : MonoBehaviour
{
    [SerializeField] Sprite spriteDie, spriteLive;

    [SerializeField] private Texture2D cursorOver, cursorDie;
    
    [SerializeField] Animator anim;

    [SerializeField] bool die;

    [SerializeField] AudioClip audioHit, audioDie;
    
    
    private BoxCollider2D box2d;

    private void Update()
    {
        anim.SetBool("Die", die);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        box2d = GetComponent<BoxCollider2D>();
    }

    void OnMouseDown()
    {
        die = true;
        box2d.enabled = false;
        PlayHit();
        StartCoroutine(Reset());
    }

    public void PlayHit()
    {
        AudioSource.PlayClipAtPoint(audioHit, transform.position, 1);
    }

    public void PlayDie()
    {
        // AudioSource.PlayClipAtPoint(audioDie, transform.position, 1);
    }
    
    IEnumerator Reset()
    {
        box2d.enabled = false;
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        die = false;
        anim.SetBool("Die", false);

        box2d.enabled = true;
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorOver, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    
    void Die()
    {
        die = false;
        box2d.enabled = true;
        
        Cursor.SetCursor(cursorDie, Vector2.zero, CursorMode.Auto);
    }
}