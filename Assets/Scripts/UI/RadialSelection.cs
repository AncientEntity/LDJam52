using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RadialSelection : MonoBehaviour
{
    public static bool radialActive { get { return radialCount > 0; } }
    private static int radialCount = 0;

    [Range(0f, 1f)]
    public float radiusPercent = 0.45f;
    public int segmentCount = 0;
    public float degreeOffset = 0f;
    [Space]
    public KeyCode openKey = KeyCode.F;
    public Color defaultColor = Color.white;
    public Color hoverColor = new Color(0.25f, 0.25f, 0.25f);
    public Color pressColor = new Color(0.5f, 0.5f, 0.5f);
    public Sprite defaultSprite;
    public string[] segmentNames;
    [Space]
    public GameObject optionParent;
    public GameObject regularTransform;
    public RadialPressedEvent onClick = new RadialPressedEvent();
    [Space]
    public TMPro.TextMeshProUGUI titleText;
    public TMPro.TextMeshProUGUI toolTipText;

    private int lastSegmentIndex = -1;
    private bool active = false;
    private Animator wheelAnim;

    private List<Image> segmentRenderers = new List<Image>();
    private List<Image> iconRenderers = new List<Image>();

    private Transform center;
    private Canvas canvas;

    private void Awake()
    {
        Init();
    }



    private void Update()
    {
        Toggle();
        if (active)
        {
            Radial();
        }
    }

    void Toggle()
    {
        if (Input.GetKeyDown(openKey))
        {
            ForceOpen(null);
        }
        else if (Input.GetKeyUp(openKey))
        {
            ForceClose();
        }
    }

    public void ForceOpen(Transform center)
    {
        this.center = center;
        OpenRadial();
        radialCount++;
    }
    public void ForceClose()
    {
        CloseRadial();
        radialCount--;
    }

    private void Radial()
    {
        Vector2 mousePos = Input.mousePosition - new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

        if (lastSegmentIndex != -1)
        {
            segmentRenderers[lastSegmentIndex].color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, segmentRenderers[lastSegmentIndex].color.a);
            lastSegmentIndex = -1;
        }

        if (InsideRadial(mousePos))
        {

            int segmentIndex = DetermineSegment(mousePos);

            toolTipText.text = segmentNames[segmentIndex];
            toolTipText.enabled = true;
            toolTipText.transform.position = GUIUtility.ScreenToGUIPoint(Input.mousePosition);//Camera.main.ScreenToViewportPoint();
            //Vector2 toolTipPos;
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,Input.mousePosition,Camera.main,out toolTipPos);
            //toolTipText.transform.position = toolTipPos;

            bool leftClickDown = Input.GetMouseButtonDown(0);
            bool leftClickActive = Input.GetMouseButton(0);

            if (leftClickDown || leftClickActive)
            {
                segmentRenderers[segmentIndex].color = new Color(pressColor.r, pressColor.g, pressColor.b, segmentRenderers[segmentIndex].color.a);

                if (leftClickDown)
                {
                    onClick.Invoke(segmentIndex);
                }
            }
            else
            {
                segmentRenderers[segmentIndex].color = new Color(hoverColor.r, hoverColor.g, hoverColor.b, segmentRenderers[segmentIndex].color.a);
            }



            lastSegmentIndex = segmentIndex;
        }
    }

    private bool InsideRadial(Vector2 mousePosition)
    {
        //Vector2 screenPositionOption = Camera.main.WorldToScreenPoint(regularTransform.transform.position);

        float xPos = mousePosition.x - center.transform.position.x;//screenPositionOption.x;
        float yPos = mousePosition.y - center.transform.position.y; //screenPositionOption.y;

        return Mathf.Sqrt(xPos* xPos + yPos * yPos) < radiusPercent * Screen.width;
    }

    private int DetermineSegment(Vector2 mousePosition)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float xPos = mousePosition.x - center.transform.position.x;
        float yPos = mousePosition.y - center.transform.position.y; 

        float angleDegrees = Mathf.Rad2Deg * Mathf.Atan2(yPos, xPos) + degreeOffset;
        if (angleDegrees < 0) { angleDegrees = 360f + angleDegrees; }
        //Debug.Log(angleDegrees);
        return (int)(angleDegrees / 360f * segmentCount);

    }

    private void Init()
    {
        for (int i = 0; i < segmentCount; i++)
        {
            segmentRenderers.Add(optionParent.transform.GetChild(i).GetComponent<Image>());
            iconRenderers.Add(optionParent.transform.GetChild(i).GetChild(0).GetComponent<Image>());
        }
        //optionParent.SetActive(active);
        wheelAnim = optionParent.GetComponent<Animator>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void SetSegmentSprite(int index, Sprite s)
    {
        if (s != null)
        {
            iconRenderers[index].sprite = s;
        }
        else
        {
            iconRenderers[index].sprite = defaultSprite;
        }
    }

    public void RemoveSegmentSprite(int index)
    {
        SetSegmentSprite(index, null);
    }

    private void OpenRadial()
    {
        active = true;
        wheelAnim.Play("Open");
        wheelAnim.SetBool("DoOpen", true);
    }

    private void CloseRadial()
    {
        if (!active) { return; }
        active = false;
        wheelAnim.SetBool("DoOpen", false);
        
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            CloseRadial();
        }
    }



    [System.Serializable]
    public class RadialPressedEvent : UnityEvent<int> { }
}