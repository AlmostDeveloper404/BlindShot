using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public static bool isDead;
    public bool isLaunched = false;

    [Header("References")]
    [SerializeField] GameObject DeathParticle;
    [SerializeField] GameObject LaunchParticle;
    [SerializeField] CircleCollider2D CircleCollid;
    [SerializeField] Text hintText;
    public Transform MouseTrail;

    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;
    SpriteRenderer _spriteRenderer;
    LineRenderer _lineRenderer;
    TrailRenderer _trailRenderer;

    Color _startColor;

    Vector2 _startPosition;
    Vector2 _flyDirection;
    Vector2 _desiredPosition;

    float _powerImpulse;
    float _speedMultiplier = 5f;
    float _range = 3f;
    float _minImpulse=5f;
    


    [Header("For Predicted line")]
    public GameObject Point;
    public GameObject[] Points;
    public int AmountOfPoints;

    void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _lineRenderer = GetComponent<LineRenderer>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (hintText != null)
        {
            hintText.text = PlayerPrefs.GetString("FirstHint", "Use your finger to launch a ball.");
        }
        _gameManager = GameManager.instance;
        _startPosition = _rigidbody2D.position;
        isDead = false;
        _startColor=_spriteRenderer.color;
        _rigidbody2D.isKinematic = true;


    }
    void Update()
    {
        _flyDirection = _startPosition-_desiredPosition;
        _powerImpulse = Mathf.Clamp(_powerImpulse,0,46);
    }
    void OnMouseDown()
    {
        if (isLaunched)
        {
            return;
        }
        if (hintText != null)
        {
            hintText.text = "";
            PlayerPrefs.SetString("FirstHint","");

        }
        FindObjectOfType<AudioManager>().PlaySound("Tension");

        Points = new GameObject[AmountOfPoints];
        for (int i = 0; i < AmountOfPoints; i++)
        {
            Points[i] = Instantiate(Point,_startPosition,Quaternion.identity); 
        }
        _spriteRenderer.color = Color.white;
    }
    void OnMouseDrag()
    {
        if (isLaunched)
        {
            return;
        }
        for (int visualpoints = 0; visualpoints < AmountOfPoints; visualpoints++)
        {
            Points[visualpoints].transform.position = PointsPosition(visualpoints * 0.05f);
        }
        
        _powerImpulse = _flyDirection.magnitude* _speedMultiplier + _minImpulse;


        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _desiredPosition = mousePosition;

        float distance = Vector2.Distance(_desiredPosition,_startPosition);


        if (_desiredPosition.x > _startPosition.x)
        {
            _desiredPosition.x = _startPosition.x;
        }
        if (distance > _range)
        {
            Vector2 maxDistance = _desiredPosition - _startPosition;
            _desiredPosition =  _startPosition+ maxDistance.normalized * _range;
        }

        MouseTrail.position = _startPosition-Vector2.right * _range/2;


        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, _startPosition);
        _lineRenderer.SetPosition(1,_desiredPosition);
        
    }
    void OnMouseUp()
    {
        if (isLaunched)
        {
            return;
        }

        FindObjectOfType<AudioManager>().PlaySound("Throwing");

        GameObject launchPart= Instantiate(LaunchParticle,_rigidbody2D.transform.position,LaunchParticle.transform.rotation);
        Destroy(launchPart, 1f);
            
        
        _rigidbody2D.velocity = _flyDirection.normalized * _powerImpulse;
        isLaunched = true;

        CircleCollid.enabled = false;

        _rigidbody2D.isKinematic = false;
        

        _lineRenderer.enabled = false;


        _spriteRenderer.color = _startColor;
    }
    public void Dead()
    {

        isDead = true;

        FindObjectOfType<AudioManager>().PlaySound("Death");

        _trailRenderer.emitting = false;
        _spriteRenderer.enabled = false;
        _rigidbody2D.simulated = false;


        Instantiate(DeathParticle, transform.position, transform.rotation);
        StartCoroutine(AfterDeathCollision());
    }

    IEnumerator AfterDeathCollision()
    {
        yield return new WaitForSeconds(1.5f);
        _gameManager.Restart();
    }

    Vector2 PointsPosition(float t)
    {
        Vector2 pos = _startPosition + (_flyDirection.normalized* _powerImpulse * t) + (Physics2D.gravity * 0.5f * t * t);
        return pos;
    }

}
