using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


class Solution
{
    public static void Main(string[] args)
    {
       
         List<Orderitem> lineOrder = new(); // Thread is a separate worker whos does tasks independently from the main program
         Thread newOrderLine = new(() =>
         {
             try
             {
                 //DelayOrderProcessing();
                 Console.WriteLine("newOrderLine sleeps for 1 seconds line 28");
                 Thread.Sleep(1000); // told to sleep for 1 second simulating a delay in processing
             }
             finally //the finally block is always run even if an exception occurs in the try block
             {
                 Console.WriteLine("lock line order line 34");
                 lock (lineOrder) // ensures only one thread can execute the enclosed block of code 
                 {
                     Console.WriteLine("Monitor Pulse all line order 36");
                     Monitor.PulseAll(lineOrder); // Signals for all threads waiting on lineOrder to wake up, in the case the main thread
                     
                 } // lock is automatically released when the block inside the lock code finishes
             }
         });
         Console.WriteLine("new order line starts line 41");
         newOrderLine.Start();
         Console.WriteLine("lock line order 43");
         lock (lineOrder)
         {
            Console.WriteLine("wait lineorder 46");
            Monitor.Wait(lineOrder); //Monitor.Wait releases the lock it has  from the start of the block and allows the thread to continue before being signalled by PulseAllLineOrder to reactivate
            ;
        }

         Console.WriteLine("Order processing has been finished.");
     }



     public class Orderitem
     {
         public int id;

         public string Name;
         public string Description;
         public int Quantity = 1;
         public int UnitPrice;



     }


   }


