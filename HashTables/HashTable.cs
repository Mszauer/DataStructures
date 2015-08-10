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
        public HashTable(int numBuckets, HashFunc hash) {
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
                //make list
                SLinkedList<K> keys = new SLinkedList<K>();
                //loop through buckets
                for (int i = 0; i < buckets.Length; i++) {
                    //loop through individual bucket
                    SLinkedList<KVP> bucket = buckets[i];
                    for (int j = 0; j < buckets[i].Size; j++) {
                        //add key to list
                        keys.AddHead(bucket[j].Key);                        
                    }
                }
                    return keys;
            }
        }
        public bool Contains(K key) {
            //hash key and find bucket
            SLinkedList<KVP> bucket = buckets[hash(key)];
            if (bucket.Size != 0) {
                for (int i = 0; i < bucket.Size; i++) {
                    int comparer = System.Collections.Generic.Comparer<K>.Default.Compare(key, bucket[i].Key);
                    if (comparer == 0) {
                        return true;
                    }
                }
                return false;
            }
            else {
                return false;
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
            for (int i = bucket.Size-1; i >= 0; i--){
                int result = System.Collections.Generic.Comparer<K>.Default.Compare(bucket[i].Key, key);
                if (result == 0) {
                    bucket.RemoveAt(i);
                    size--;
                    return;
                }
            }
            throw new System.Exception();
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
                }
                throw new System.Exception();
            }
            set {
                SLinkedList<KVP> bucket = buckets[hash(key)];
                for (int i = 0; i < bucket.Size; i++) {
                    int result = System.Collections.Generic.Comparer<K>.Default.Compare(bucket[i].Key, key);
                    if (result == 0) {
                        bucket[i].Value = value;
                        return;
                    }
                }
                throw new SystemException();
            }
        }
    }
}
