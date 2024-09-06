using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites1, sprites2, sprites3, sprites4;
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;
    bool oil;
    float timer;

    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private int spriteIndex;
    [SerializeField] GameObject damage;
    [SerializeField] GameObject OilEffect;
    bool ActiveCol = false;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        oil = false;
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }

        // Примените гравитацию и обновите положение
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // Наклоняйте птицу в зависимости от направления
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
        if (oil) 
        {
            OilEffect.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 10) 
            {
                oil = false;
                timer = 0;
                OilEffect.SetActive(false);
            }
        }
    }

    private void AnimateSprite()
    {
        switch (PlayerPrefs.GetInt("skin"))
        {
            case 1:
                spriteIndex++;

                if (spriteIndex >= sprites1.Length)
                {
                    spriteIndex = 0;
                }

                if (spriteIndex < sprites1.Length && spriteIndex >= 0)
                {
                    spriteRenderer.sprite = sprites1[spriteIndex];
                }
                break;
            case 2:
                spriteIndex++;

                if (spriteIndex >= sprites2.Length)
                {
                    spriteIndex = 0;
                }

                if (spriteIndex < sprites2.Length && spriteIndex >= 0)
                {
                    spriteRenderer.sprite = sprites2[spriteIndex];
                }
                break;
            case 3:
                spriteIndex++;

                if (spriteIndex >= sprites3.Length)
                {
                    spriteIndex = 0;
                }

                if (spriteIndex < sprites3.Length && spriteIndex >= 0)
                {
                    spriteRenderer.sprite = sprites3[spriteIndex];
                }
                break;
            case 4:
                spriteIndex++;

                if (spriteIndex >= sprites4.Length)
                {
                    spriteIndex = 0;
                }

                if (spriteIndex < sprites4.Length && spriteIndex >= 0)
                {
                    spriteRenderer.sprite = sprites4[spriteIndex];
                }
                break;
            default:
            
                spriteIndex++;

                if (spriteIndex >= sprites1.Length)
                {
                    spriteIndex = 0;
                }

                if (spriteIndex < sprites1.Length && spriteIndex >= 0)
                {
                    spriteRenderer.sprite = sprites1[spriteIndex];
                }
                break;
               
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<Collider2D>().enabled = false;
            if (!oil)
            {
                if (!ActiveCol)
                {
                    GameManager.Instance.GameOver();
                    GameObject damag = Instantiate(damage, transform.position, Quaternion.identity);
                    damag.transform.SetParent(gameObject.transform);
                    OilEffect.SetActive(false);
                    ActiveCol = true;
                }
                
            }
           
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            for (int i = 0; i < 3; i++)
            {
                GameManager.Instance.GameOver();
                OilEffect.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("bird"))
        {
            if (!oil) 
            {
                for (int i = 0; i < 3; i++)
                {
                    GameManager.Instance.GameOver();
                    OilEffect.SetActive(false);
                }
            }
            
        }
        else if (other.gameObject.CompareTag("oil"))
        {
            if (oil)
            {
                timer = 0;
            }
            else
            {
                oil = true;
            }
            
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("money"))
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1);
            Destroy(other.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ActiveCol = false;
    }

}
