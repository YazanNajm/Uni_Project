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
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= arrayByte.Length) throw new IndexOutOfRangeException();
                return arrayByte[index];
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
                var fnv_prime = 0x01000193;
                var hash = 0;
                foreach (var element in arrayByte)
                {
                    hash *= fnv_prime;
                    hash = (hash ^ element);
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
                result += arrayByte[i - 1];
                if (i == arrayByte.Length)
                    result += "]";
                else
                    result += ", ";
            }
            return result == "[" ? "[]" : result;
        }
    }
}
