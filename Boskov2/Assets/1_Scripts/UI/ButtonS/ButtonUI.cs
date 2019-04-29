using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boskov.UI
{
    public abstract class ButtonUI : ScriptableObject
    {
        public Sprite selectedImage;
        public Sprite unselectedImage;
        public bool selected;

        public abstract void Do();

        public Sprite activeSprite()
        {
            return selected ? selectedImage : unselectedImage;
        }
    }
}