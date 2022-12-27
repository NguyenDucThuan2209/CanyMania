using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ulti : MonoBehaviour
{

    public static List<JewelObj> ListPlus(List<JewelObj> l1, List<JewelObj> l2, JewelObj bonus)
    {
        List<JewelObj> tmp = new List<JewelObj>();
        for (int i = l1.Count - 1; i >= 0; i--)
        {
            tmp.Add(l1[i]);
        }
        if (bonus != null)
            tmp.Add(bonus);

        for (int i = 0; i < l2.Count; i++)
        {
            tmp.Add(l2[i]);
        }

        return tmp;
    }    

    public static IEnumerator IEDrop(GameObject obj, Vector2 NewPos, float speed)
    {
        JewelObj script = obj.GetComponent<JewelObj>();
        Collider2D coll = obj.GetComponent<Collider2D>();
        if (obj != null)
        {
            Transform _tranform = obj.transform;
            coll.enabled = false;
            script.isMove = true;
            while (_tranform != null && _tranform.localPosition.y - NewPos.y > 0.1f)
            {
                _tranform.localPosition -= new Vector3(0, Time.smoothDeltaTime * speed);
                yield return null;
            }
            if (_tranform != null)
            {
                _tranform.localPosition = new Vector3(NewPos.x, NewPos.y);

                script.Bounce();
                script.RuleChecker();
                yield return new WaitForSeconds(0.2f);
                if (coll != null)
                {
                    coll.enabled = true;
                    script.isMove = false;
                }
            }
        }
    }

    public static IEnumerator IELocalMoveTo(Transform obj, Vector3 start, Vector3 end, float duration)
    {
        float countDown = 0;
        while (countDown < duration)
        {
            if (obj == null)
                yield break;

            countDown += Time.deltaTime;
            obj.localPosition = Vector3.Lerp(start, end, countDown / duration);

            yield return null;
        }
        if (obj != null)
            obj.position = end;
    }    
    public static IEnumerator IEMoveTo(Transform obj, Vector3 start, Vector3 end, float duration)
    {
        float countDown = 0;
        while (countDown < duration)
        {
            if (obj == null) yield break;

            countDown += Time.deltaTime;
            obj.position = Vector3.Lerp(start, end, countDown / duration);
            
            yield return null;
        }
        if(obj != null) obj.position = end;
    }
    public static IEnumerator IEScaleTo(Transform obj, Vector3 start, Vector3 end, float duration)
    {
        float countDown = 0;
        while (countDown < duration)
        {
            if (obj == null) yield break;

            countDown += Time.deltaTime;
            obj.localScale = Vector3.Lerp(start, end, countDown / duration);

            yield return null;
        }
        if (obj != null) obj.localScale = end;
    }
    public static IEnumerator IETransparentTo(Color lerpColor, float start, float end, float duration)
    {
        float countDown = 0;
        while (countDown < duration)
        {
            if (lerpColor == null) yield break;

            countDown += Time.deltaTime;
            lerpColor.a = Mathf.Lerp(start, end, countDown / duration);

            yield return null;
        }
        if (lerpColor != null) lerpColor.a = end;
    }
}