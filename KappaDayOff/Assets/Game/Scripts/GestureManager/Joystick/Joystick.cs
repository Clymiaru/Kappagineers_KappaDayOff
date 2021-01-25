using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	public Image JoystickParent;
	public Image Stick;

	public Vector2 JoystickVector { get; private set; }

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 locPosition;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickParent.rectTransform,
		                                                            eventData.position,
		                                                            eventData.pressEventCamera,
		                                                            out locPosition))
		{
			float half_width  = JoystickParent.rectTransform.rect.width  / 2;
			float half_height = JoystickParent.rectTransform.rect.height / 2;

			float x = locPosition.x / half_width;
			float y = locPosition.y / half_height;

			JoystickVector = new Vector2(x, y);

			if (JoystickVector.magnitude > 1.0f)
			{
				JoystickVector = JoystickVector.normalized;
			}

			Stick.rectTransform.localPosition =
					new Vector2(JoystickVector.x * half_width, JoystickVector.y * half_height);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		JoystickVector                    = Vector2.zero;
		Stick.rectTransform.localPosition = Vector2.zero;
	}
}

// public class Joystick : MonoBehaviour
// {
//     public GameObject crosshair;
//     public float speed = 5f;
//     private bool touchStart = false;
//     private Vector2 startPoint;
//     private Vector2 endPoint;
//
//     public Transform innerCircle;
//     public Transform outerCircle;
//
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.touchCount > 0)
//         {
//             Vector2 touchLocation = Input.GetTouch(0).position;
//             if (!touchStart && touchLocation.x < Screen.width  / 2)
//             {
//                 
//                 startPoint = Camera.main.ScreenToWorldPoint(new Vector3
//                     (touchLocation.x, touchLocation.y, Camera.main.transform.position.z));
//                 touchStart = true;
//
//                 innerCircle.transform.position = startPoint;
//                 outerCircle.transform.position = startPoint;
//                 innerCircle.GetComponent<SpriteRenderer>().enabled = true;
//                 outerCircle.GetComponent<SpriteRenderer>().enabled = true;
//             }
//             else
//             {
//                 endPoint = Camera.main.ScreenToWorldPoint(new Vector3
//                     (touchLocation.x, touchLocation.y, Camera.main.transform.position.z));
//             }
//         }
//         else
//             touchStart = false;
//     }
//
//     private void FixedUpdate()
//     {
//         if (touchStart)
//         {
//             Vector2 offset = endPoint - startPoint;
//             Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
//             moveCharacter(direction);
//
//             innerCircle.transform.position = new Vector2(startPoint.x + direction.x, startPoint.y + direction.y);
//         }
//         else
//         {
//             innerCircle.GetComponent<SpriteRenderer>().enabled = false;
//             outerCircle.GetComponent<SpriteRenderer>().enabled = false;
//         }
//     }
//
//     void moveCharacter(Vector2 direction)
//     {
//         crosshair.transform.Translate(direction * speed * Time.deltaTime);
//     }
// }