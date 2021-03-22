using System;
using System.Collections.Generic;

namespace appnext
{
    public class WeakDictionary<TKey, TValue> where TValue : class
    {
        private readonly Dictionary<TKey, WeakReference> items;

        public WeakDictionary()
        {
            this.items = new Dictionary<TKey, WeakReference>();
        }

        public void Put(TKey key, TValue value)
        {
            this.items[key] = new WeakReference(value);
        }

        public bool Remove(TKey key)
        {
            WeakReference weakRef;
            if (!this.items.TryGetValue(key, out weakRef))
            {
                return false;
            }
            else
            {
                this.items.Remove(key);
                return weakRef.IsAlive;
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            WeakReference weakRef;
            if (!this.items.TryGetValue(key, out weakRef))
            {
                value = null;
                return false;
            }
            else
            {
                value = (TValue)weakRef.Target;
                return (value != null);
            }
        }
    }
}
