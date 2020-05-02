using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Inst
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));


                if (FindObjectsOfType(typeof(T)).Length > 1)
                {
                    return _instance;
                }

                if (_instance == null)
                {
                    GameObject gobj = new GameObject();
                    _instance = gobj.AddComponent<T>();
                    gobj.name = typeof(T).ToString();
                }
            }
            return _instance;
        }
    }
}
