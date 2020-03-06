using System;
using System.Collections;
using System.Collections.Generic;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        private readonly byte[] arrayByte;
        public readonly int Length;
        public ReadonlyBytes(params byte[] values)
        {
            if (values == null) throw new ArgumentNullException();
            arrayByte = values;
            Length = values.Length;
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
                return arrayByte[index];
            }
            set
            {
                if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
                arrayByte[index] = (byte)value;
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is ReadonlyBytes)) return false;
            var array = obj as ReadonlyBytes;
            return array == obj;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return arrayByte[Length]*10 ;
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach(var e in arrayByte)
            {
                yield return e;
            }
        }

        IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
