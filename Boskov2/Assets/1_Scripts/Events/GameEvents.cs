using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov
{
    public class GameEvents : MonoBehaviour
    {
        private void OnEnable()
        {
            GameCoreData.events.Register(this);
        }

        private void OnDisable()
        {
            GameCoreData.events.Unregister(this);
        }

        public virtual void EventE() { }
        public virtual void PlayMusic() { }
        public virtual void Coffeenjection() { }
    }

    public class Events
    {
        public List<GameEvents> events = new List<GameEvents>();

        /// <summary>
        /// Register the entities
        /// </summary>
        /// <param name="evnt">Entity you want to register</param>
        public void Register(GameEvents evnt)
        {
            events.Add(evnt);
        }

        /// <summary>
        /// Register the entities
        /// </summary>
        /// <param name="ent">Entity you want to unregister</param>
        public void Unregister(GameEvents evnt)
        {
            events.Remove(evnt);
        }

        public void CallEventE()
        {
            for (int i = 0; i < events.Count; i++)
            {
                events[i].EventE();
            }
        }

        public void CallPlayMusic()
        {
            for (int i = 0; i < events.Count; i++)
            {
                events[i].PlayMusic();
            }
        }

        public void CallCoffeenjection()
        {
            for (int i = 0; i < events.Count; i++)
            {
                events[i].Coffeenjection();
            }
        }
    }
}