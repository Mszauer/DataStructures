using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    class HashTable<K,V> {
        public class KVP<K,V> {
            public K Key;
            public V Value;
            public KVP(K key, V value) {
                Key = key;
                Value = value;
            }
        }
        public delegate int HashFunc(K key);
        private SLinkedList<KVP>[] buckets = null;
        int size = 0;
        HashFunc hash = default(int);
        public void HashTable(int numBuckets, HashFunc hash) {

        }
        public SLinkedList<K> Keys {
            get {
                return K;
            }
        }
        public int Size {
            get {
                return size;
            }
        }
        public void Add(K key, V value) {

        }
        public void Remove(K key) {

        }
        public int Hash(K key) {
            return 0;
        }
        public V this[K key] {

        }
    }
}
