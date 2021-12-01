using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
        //Managers
        //protected static GameManager _GM { get { return GameManager.INSTANCE; } }
     


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
