﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Glympse.EnRoute.Android
{
    public class Array<T> : GArray<T>
    {
        private com.glympse.android.core.GArray _raw;       

        public Array(com.glympse.android.core.GArray array)
        {
            _raw = array;        
        }

        public int length()
        {
            return _raw.length();
        }

        public T at(int index)
        {
            return (T)ClassBinder.bind(_raw.at(index));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this); 
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new Enumerator(this); 
        }

        public object raw()
        {
            return _raw;
        }

        private class Enumerator : IEnumerator<T>
        {
            private Array<T> _array;

            private int _index;

            public Enumerator(Array<T> array)
            {
                _array = array;
                _index = 0;
            }

            public T Current 
            { 
                get
                {
                    return _array.at(_index);
                }
            }

            Object System.Collections.IEnumerator.Current 
            { 
                get
                {
                    return _array.at(_index);
                }
            }  
                
            public bool MoveNext()
            {
                ++_index;
                return ( _index < _array.length() );
            }

            public void Reset()
            {
                _index = 0;
            }

            public void Dispose()
            {
                _array = null;
            }                        
        }
    }
}
