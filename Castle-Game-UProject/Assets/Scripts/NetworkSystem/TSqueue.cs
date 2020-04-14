using System.Collections.Generic;
using System.Threading;

namespace NetworkSystem{
    public class TSqueue<T>{
        private readonly object cLock = new object();

        private Queue<T> _content = new Queue<T>();
        
        private bool isReady = false;
        public TSqueue(){
            lock (cLock){
                isReady = true;
            } 
        }

        /// <summary>
        /// Enqueue an object into the queue and wait until the resource is free
        /// </summary>
        /// <returns></returns>
        public bool enqueue(T obj){
            lock (cLock){
                _content.Enqueue(obj);
            }
            return true;
        }

        /// <summary>
        /// Dequeue an object from the queue without waiting for the resource to free
        /// </summary>
        /// <returns></returns>
        public bool dequeue(){
            return true;
        }

        /// <summary>
        /// Try to enqueue and object onto the queue but timeout and return control if it
        /// is already taken
        /// </summary>
        /// <returns></returns>
        public bool tryEnqueue(){
            return true;
        }

        
        /// <summary>
        /// Try to dequeue an object but time out if the lock is taken already
        /// </summary>
        /// <returns></returns>
        public bool tryDequeue(out T ret){
            bool canEnter = false;
            bool result = false;
            try{
                Monitor.TryEnter(cLock, 100, ref canEnter);
                if (canEnter){
                    if (_content.Count > 0){
                        ret = _content.Dequeue();
                        result = true;
                    }
                    else{
                        ret = default(T);
                    }
                }
                else{
                    ret = default(T);
                }
            }
            finally{
                if (canEnter){
                    Monitor.Exit(cLock);
                }
            }
            return result;
        }
        
        
    }
}