using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures {
    class HashTable<K,V> {
        public class KVP {
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
        HashFunc hash = null;
        public void HashTable(int numBuckets, HashFunc hash) {
            this.hash = hash;
            buckets = SLinkedList<KVP>[numBuckets](); // why is this an error?
        }
        public SLinkedList<K> Keys {
            get {
                return new SLinkedList<K>();
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
