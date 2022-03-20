using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    
    private bool _isDragging;
    private Vector2 _startTouch, _swipeDelta;

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        if (Input.touches.Length > 0)
        {
            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    tap = true;
                    _isDragging = true;
                    _startTouch = Input.touches[0].position;
                    break;
                
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isDragging = false;
                    Reset();
                    break;
            }
        }
        
        //Calculate the distance
        _swipeDelta = Vector2.zero;
        if (_isDragging)
        {
            if (Input.touches.Length < 0)
                _swipeDelta = Input.touches[0].position - _startTouch;
            else if (Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
        }

        //Did we cross the distance?
        if (!(_swipeDelta.magnitude > 100)) 
            return;
        
        //Which direction?
        float x = _swipeDelta.x;
        float y = _swipeDelta.y;
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            //Left or Right
            if (x < 0)
                swipeLeft = true;
            else
                swipeRight = true;
        }
        else
        {
            //Up or Down
            if (y < 0)
                swipeDown = true;
            else
                swipeUp = true;
        }

        Reset();

    }

    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDragging = false;
    }
}