using UnityEngine;
using UnityEngine.UI;

public class MaskChecking : MonoBehaviour
{
    [SerializeField] Text _hintText;
    public GameObject MaskObject;
    private void Start()
    {
        FindObjectOfType<AudioManager>();
        if (_hintText != null)
        {
           _hintText.text = PlayerPrefs.GetString("Delete", "There are dangerous invisible obstacles.In order to reveal them, click on the screen. ");

        }
    }
    private void OnMouseDown()
    {
        if (_hintText != null)
        {
            _hintText.text = "";
            PlayerPrefs.SetString("Delete","");
        }
        FindObjectOfType<AudioManager>().PlaySound("Mask");
        Vector2 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject createdMask=Instantiate(MaskObject, mouseClickPosition, transform.rotation);
        Destroy(createdMask,2f);
    }
}
