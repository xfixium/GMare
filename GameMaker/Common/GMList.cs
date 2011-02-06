#region MIT

// 
// GMare.
// Copyright (C) 2011 Michael Mercado
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

#endregion

using System;
using System.Collections;
using System.Collections.Generic;
using GameMaker.Resource;

namespace GameMaker.Common
{
    /// <summary>
    /// A list secifically designed for Game Maker resource type.
    /// </summary>
    [Serializable]
    public class GMList<T> : IList<T>
    {
        #region Fields

        private List<T> _items = new List<T>();
        private int _lastId = -1;
        private bool _isReadOnly = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the last GM object id used in this list.
        /// </summary>
        public int LastId
        {
            get { return _lastId; }
            set { _lastId = value; }
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Resets the Game Maker object id count.
        /// </summary>
        public void ResetIds()
        {
            // Reset the last id.
            _lastId = -1;
        }

        public T Find(Predicate<T> match)
        {
            return _items.Find(match);
        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
        }

        public void Add(T item)
        {
            // If the item is a resource, increment last resource id.
            if (item is GMResource)
            {
                _lastId++;
                (item as GMResource).Id = _lastId;
            }

            _items.Add(item);
        }

        public void AddRange(T[] items)
        {
            _items.AddRange(items);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _items.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public T[] ToArray()
        {
           return _items.ToArray();
        }

        #endregion
    }
}