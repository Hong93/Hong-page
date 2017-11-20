using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiseScopeDemo.New
{
    

    public class Test
    {
        private List<string> abc;

        public List<string> ABC
        {
            get { return abc; }
            set { abc = value; }
        }


        //private ConcurrentQueue<string> queue_test;

        //public ConcurrentQueue<string> Queue_test
        //{
        //    get
        //    {
        //        return queue_test;
        //    }

        //    set
        //    {
        //        queue_test = new ConcurrentQueue<string>();
        //        queue_test.Enqueue("Queue");
        //        queue_test.Enqueue("Queueueueueueueu");

        //        queue_test.ToList<string>();
        //        queue_test = value;
        //    }
        //}
        private List<string> qtolist;

        public List<string> Qtolist
        {
            get { return qtolist; }
            set {qtolist = value; }
        }

        //private Queue<int> qint;

        //public Queue<int> Qint
        //{
        //    get { return qint; }
        //    set { qint = value; }
        //}




        private string[] array_test;

        public string[] Array_test
        {
            get { return array_test; }
            set { array_test = value; }
        }

        //private Stack<int> intStack;

        //public Stack<int> IntStack
        //{
        //    get { return intStack; }
        //    set { intStack = value; }
        //}

        //private Dictionary<string, int> dictionary;

        //public Dictionary<string, int> Dictionary
        //{
        //    get { return dictionary; }
        //    set { dictionary = value; }
        //}

        

        

    }



}

