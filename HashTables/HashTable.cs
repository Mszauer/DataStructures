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
            //initialize the array
            SLinkedList<KVP>[] buckets = new SLinkedList<KVP>[numBuckets];
            //put linked list into each of the array spots
            for (int i = 0 ; i < buckets.Length ; i++){
                buckets[i] = new SLinkedList<KVP>();
            }
            //fill in the list with data
            for (int i = 0 ; i < buckets.Length ; i++){
                for (int j = 0 ; j < numBuckets ; j++){
                    buckets[i].AddHead(null);// what do i add?
                }
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
            KVP val = new KVP(key, value);
            //how do i add to what, what coditions no clue
            if (buckets[hash(key)] != null) {
                buckets[hash(key)].AddHead(val);
            }
            else {

            }
            size++;
        }
        public void Remove(K key) {
            //loop until key is found, remove key
            for (int i = buckets.Length -1; i >= 0 ; i--) {
                if (buckets[i]/*returns slinked list*/ == key) { //what? what do I even compare
                    buckets[i] = buckets[i - 1];
                }
            }
            size--;
        }
        public int Hash(K key) {
            return hash(key) ;
        }
        public V this[K key] {
            get {
                for (int i = 0; i < buckets.Length; i++) {
                    if (buckets[i] == hash(key)) { //still have no clue how to compare
                        return buckets[i].Value; //what
                    }
                    else {
                        throw new SystemException();
                    }
                }
            }
            set {
                for (int i = 0; i < buckets.Length; i++) {
                    if (buckets[i] == hash(key)) {
                        buckets[i].Value = value; //yep no clue here either
                    }
                    else {
                        throw new SystemException();
                    }
                }
            }
        }
    }
}
