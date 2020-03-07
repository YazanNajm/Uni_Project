using System;
using System.Collections;
using System.Collections.Generic;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        private readonly byte[] arrayByte;
        public int Length
        {
            get
            {
                return arrayByte.Length;
            }
        }
        public ReadonlyBytes(params byte[] values)
        {
            arrayByte = values ?? throw new ArgumentNullException();
            Length = values.Length;
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= arrayByte.Length) throw new IndexOutOfRangeException();
                return arrayByte[index];
            }
            set
            {
                if (index < 0 || index >= arrayByte.Length) throw new IndexOutOfRangeException();
                arrayByte[index] = (byte)value;
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is ReadonlyBytes)) return false;
            var array = obj as ReadonlyBytes;
            if (arrayByte.Length == array.Length)
            {
                for (var i = 0; i < arrayByte.Length; i++)
                {
                    if (arrayByte[i] != array[i])
                        return false;
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var fnv_prime = 109951;
                var hash = 0;
                for (var i = 0; i < arrayByte.Length; i++)
                {
                    hash *= fnv_prime;
                    hash = (hash ^ arrayByte[i]);
                }
                return hash;
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach (var e in arrayByte)
            {
                yield return e;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override String ToString()
        {
            String result = "[";
            for (var i = 1; i < Length + 1; i++)
            {
                if (i == arrayByte.Length)
                    result += arrayByte[i - 1] + "]";
                else
                    result += arrayByte[i - 1] + ", ";
            }
            return result == "[" ? "[]" : result;
        }
    }
}
