using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    //Managers
    protected static GameManager _GM { get { return GameManager.INSTANCE; } }
    protected static UIManager _UI { get { return UIManager.INSTANCE; } }
    protected static DialogueManager _DM { get { return DialogueManager.INSTANCE; } }
    protected static AudioManager _AM { get { return AudioManager.INSTANCE; } }
    //Player
    protected static Player _P { get { return Player.INSTANCE; } }
    protected static PlayerMovement _PM { get { return PlayerMovement.INSTANCE; } }

    //Universal Functions

    /// <summary>
    /// Shuffles a list using Unity's Random
    /// </summary>
    /// <typeparam name="T">The data type</typeparam>
    /// <param name="_list">The list to shuffle</param>
    /// <returns>Returns a shuffled List</returns>
    public static List<T> ShuffleList<T>(List<T> _list)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                T temp = _list[i];
                int randomIndex = UnityEngine.Random.Range(i, _list.Count);
                _list[i] = _list[randomIndex];
                _list[randomIndex] = temp;
            }
            return _list;
        }
 }

public class Singleton<T> : GameBehaviour where T : MonoBehaviour
{
    public bool dontDestroy;
    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
            if (dontDestroy)
            {
                DontDestroyOnLoad(gameObject);
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}



