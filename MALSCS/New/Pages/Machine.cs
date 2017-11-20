using log4net;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Serialization;
using WiseScopeDemo.New;

namespace WiseScopeDemo.New.Pages
{
    [Serializable]
    public class Machine
    {
        public MALSController mals_ctr;
        public LightingController lighting_ctr;
        public Test listest;

        public Machine()
        {

            mals_ctr = new MALSController();
            lighting_ctr = new LightingController();
            listest = new Test();

            if (listest.ABC == null)
            {
                listest.ABC = new List<string>();

                listest.ABC.Add("qkrwoghd");
                listest.ABC.Add("nihao");

                //for (int i = 0; i < 2; i++)
                //{
                //    Console.WriteLine("{0}", listest.ABC[i]);
                //}
                //foreach(var testlist in listest.ABC)
                //{
                //    Console.WriteLine("{0}", listest.ABC.ToArray());
                //}
            }



            if (listest.Array_test == null)
            {
                listest.Array_test = new string[3] { "dfa", "asdf", "feww" };
                //for (int i = 0; i < 3; i++)
                //{
                //    Console.WriteLine("{0}", listest.Array_test[i]);
                //}
            }




            //if (listest.IntStack == null)
            //{
            //    listest.IntStack = new Stack<int>();
            //    listest.IntStack.Push(1);
            //    listest.IntStack.Push(2);

            //    foreach (var testStack in listest.IntStack)
            //    {
            //        Console.WriteLine("{0}", testStack);
            //    }
            //}

            //if (listest.Dictionary == null)
            //{
            //    listest.Dictionary = new Dictionary<string, int>()
            //{
            //    {"Hi", 1},
            //    {"bye",2}
            //};
            //    foreach (var testDictionary in listest.Dictionary)
            //    {
            //        Console.WriteLine("{0},{1}", testDictionary.Key, testDictionary.Value);
            //    }
            //}


            //if (listest.Queue_test == null)
            //{
            //    listest.Queue_test.ToList<string>();
            //}

            if (listest.Qtolist == null)
            {
                Queue<string> q = new Queue<string>();
                q.Enqueue("dTKFKFFKFKFK");
                q.Enqueue("diododododododododo");

                List<string> list = new List<string>(q);
                listest.Qtolist = list;
            }

            //if(listest.Qint == null)
            //{
            //    Queue<int> q = new Queue<int>();
            //    q.Enqueue(1);
            //    q.Enqueue(2);

            //    listest.Qint = q;
            //}

        }



    }

}
