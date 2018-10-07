using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTouchController : MonoBehaviour, IPointerClickHandler
{
	float test = 0.1f;
	public RectTransform m_ContainerRect;
	public RectTransform m_PointRect;
	public void OnPointerClick(PointerEventData eventData)
	{
		//RectTransformUtility.ScreenPointToLocalPointInRectangle(m_ContainerRect, eventData.pressPosition, eventData.pressEventCamera, out vc);
		//m_PointRect.localPosition = vc;

		//Vector3 vc;
		//RectTransformUtility.ScreenPointToWorldPointInRectangle(m_ContainerRect, eventData.pressPosition, eventData.pressEventCamera, out vc);
		//Debug.Log(vc);
		//Debug.Log(Input.mousePosition);
		
		Vector3 world = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Debug.Log(world);
	}

	void Update()
	{
		
	}

}
