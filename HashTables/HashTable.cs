using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

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
            //initialize the array
            buckets = new SLinkedList<KVP>[numBuckets];
            //put linked list into each of the array spots
            for (int i = 0 ; i < buckets.Length ; i++){
                buckets[i] = new SLinkedList<KVP>();
            }
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
            SLinkedList<KVP> bucket = buckets[hash(key)];
            for (int i = 0 ; i < bucket.Size ; i++){
                int result = System.Collections.Generic.Comparer<K>.Default.Compare(bucket[i].Key, key);
                if (result == 0) {
                    throw new System.Exception();
                }
            }
            KVP val = new KVP(key, value);
            buckets[hash(key)].AddHead(val);
            size++;
        }
        public void Remove(K key) {
            SLinkedList<KVP> bucket = buckets[hash(key)];
            size--;
        }
        public int Hash(K key) {
            return hash(key) ;
        }
        public V this[K key] {
            get {
                SLinkedList<KVP> bucket = buckets[hash(key)];
                for (int i = 0; i < bucket.Size; i++) {
                    int result = System.Collections.Generic.Comparer<K>.Default.Compare(bucket[i].Key, key);
                    if (result == 0) {
                        return bucket[i].Value;
                    }
                    else {
                        throw new SystemException();
                    }
                }
                //what to return as default?
                return V;
            }
            set {
                SLinkedList<KVP> bucket = buckets[hash(key)];
                for (int i = 0; i < buckets.Length; i++) {
                    if (buckets[i] == bucket) {
                        bucket.AddHead(); //what do I add?
                    }
                    else {
                        throw new SystemException();
                    }
                }
            }
        }
    }
}
