using UnityEngine;

public class Lighting : MonoBehaviour
{
    public GameObject _objectWithAnim;
    Animation anim;

    float _soundReloading;

    private void Start()
    {
        _soundReloading = 0f;
    }

    public void Awake()
    {
        anim = _objectWithAnim.GetComponent<Animation>();
    }

    private void Update()
    {
        _soundReloading -= Time.deltaTime;
        _soundReloading = Mathf.Clamp(_soundReloading,0f,2.5f);
    }
    public void Light()
    {
        if (_soundReloading == 0f)
        {
            FindObjectOfType<AudioManager>().PlaySound("Light");
            _soundReloading = 2f;
        }
        anim.Play();
    }

    
}
