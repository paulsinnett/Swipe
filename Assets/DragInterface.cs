using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragInterface : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	RectTransform rectangle;
	Vector2 rectanglePosition;
	Vector2 centrePosition;
	Vector2 startDrag;

	void Start () {

		rectangle = GetComponent<RectTransform> ();
		centrePosition = rectangle.position;
	}

	void Update () {

		rectangle.position = Vector2.Lerp (rectangle.position, centrePosition, 0.1f);
	}

	public void OnBeginDrag (PointerEventData eventData){
		
		startDrag = eventData.pressPosition;
		rectanglePosition = rectangle.position;
	}

	public void OnDrag (PointerEventData eventData){
		
		Vector2 drag = eventData.position - startDrag;
		rectangle.position = rectanglePosition + drag;
	}
		
	public void OnEndDrag (PointerEventData eventData){
	}
}
