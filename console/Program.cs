
#define TRIAL

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Management;
using System.Collections.Concurrent;

namespace NamespaceTest
{
    class TestClass
    {
        NestedNamespace.TestClass t = new NestedNamespace.TestClass();
    }

    namespace NestedNamespace
    {
        class TestClass
        {

        }
        class TestClassNested
        {

        }
    }

}
// when complied they are combined together
namespace NamespaceTest
{
    class TestClass2
    {

    }
}

namespace console
{
    // extension class
    public static class ExtensionAdder // must be defined outside any classes in the namespace
    {
        public static void ToConsole(this int obj)
        {
            Console.WriteLine(obj);
        }
        public static void ToConsole(this int obj, int i)
        {
            Console.WriteLine(i);
        }
    }
    public partial class MyPartialClass
    {
        partial void Show();
    }

}
namespace console
{
    // using x = NamespaceTest.NestedNamespace.TestClassNested;

    using System.Xml;
    using System.Threading;
    using NamespaceTest;
    using NamespaceTest.NestedNamespace;
    using ally = NamespaceTest;
    using System.Diagnostics;
    using System.Runtime.Serialization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Microsoft.Win32;
    using System.Management;
    using System.Runtime.InteropServices;
    using System.Net;

    /*
* global namespace when using two different namespaces with
* the same element names, one must ::namespace 
* to use :: one must define an alias for the namespace
* you want to qualify
* */
    public class Program
    {
        volatile static int val;
        ally::TestClass t = new ally::TestClass();

        private delegate void myDel();

        static bool AcceptStream(Stream s)
        {
            return false;
        }
        static GenericClassB changeIt(GenericClassA val)
        {
            return new GenericClassB(val.s + "11111111111111");
        }
        static GenericClassB changeItB(GenericClassB val)
        {
            return new GenericClassB(val.s + "11111111111111");
        }

        static void Main(string[] args)
        {

            #region Exceptions

            /*
           foreach (string s in args)
               Console.WriteLine(s);
           try
           {
               int[] arr1 = { 1, 2, 3, 4, 5, 0 };
               int[] arr2 = { 1, 0, 0 };

               for (int i = 0; i < arr1.Length; i++)
                   try
                   {
                       int res = arr1[i] / arr2[i];
                       throw new Exception();
                   }
                   catch (DivideByZeroException e)
                   {

                       Console.WriteLine(e.Message);
                       throw new OutOfRange("hmmm",e);
                   }
                   catch (IndexOutOfRangeException e)
                   {
                       Console.WriteLine(e.Message);
                       throw;
                   }
                   catch (OutOfRange)
                   {
                       throw;
                   }
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               Console.WriteLine();
               Console.WriteLine(e.InnerException);
               Console.WriteLine();
               Console.WriteLine(e.Message);
               Console.WriteLine();
               Console.WriteLine(e.TargetSite);
               Console.WriteLine();
               Console.WriteLine("source {0}",e.Source);
               Console.WriteLine();
               Console.WriteLine(e.StackTrace);

           }
         
            #endregion

            #region Custom index array

            //RangeArray r1 = new RangeArray(-1, 2);
            //try
            //{
            //    for (int i = r1.LowerBound; i <= 55; i++)
            //    {
            //        checked//overflow exception is thrown is its overflowed
            //        {
            //            r1[i] = i * i;
            //        }

            //        unchecked//ignors overflow  for block
            //        {
            //            r1[i] = i * i;
            //        }

            //        r1[i] = checked(i * i);//overflow exception is thrown is its overflowed

            //        r1[i] = unchecked(i * i);//ignores overflow for specific expression

            //        Console.WriteLine(r1[i]);
            //    }
            //}

            //catch (OutOfRange e)
            //{
            //    Console.WriteLine(e);
            //}
            //catch (OverflowException)
            //{

            //}
            //catch (Exception)
            //{

            //}

            //ConsoleKeyInfo info = Console.ReadKey(true);
            //Console.Error.Write("hello");
            //StreamWriter sw = new StreamWriter("log.txt");
            //sw.AutoFlush = true;
            //Console.SetOut(sw);

            //for (int i = 0; i < 1000; i++)
            //    Console.Error.WriteLine("mistake");

            //Console.Error.Close();
            #endregion

            #region Anonymous Methods
            //Cacl calc = new Cacl();
            //Func<int, int, int> result = calc.Minus();

            //result = (x, y)=> x + y;

            //Func<int, Func<int, int, int>, int> complexResult =
            //    (x, f) => x * f(1, 2);
            ////recursive
            //Func<int, int> recFunc = null;
            //recFunc = x =>
            //{
            //    Console.WriteLine(x);
            //    return x == 0 ? 0 : recFunc(--x);
            //};
            ////recFunc = x => x == 0 ? 0 : recFunc(--x);

            //Console.WriteLine("result of complex, {0}",complexResult(5, result));
            //Console.WriteLine("result of simple, {0}", result(5, 2));
            //Console.WriteLine("recursive , {0}",recFunc(10));

            //Func<Task> t =
            //    async () => { Console.WriteLine("Hello World!!!!"); };

            ////IAsyncResult rs =
            ////    t.BeginInvoke(res =>
            ////    { Console.WriteLine("Method is over,{0}",res.AsyncState); }, "hello");
            // t();

            ////if not to wait till the method is over it will not work
            //Thread.Sleep(100);

            #endregion

            #region Streams
            /*There are two types of streams:character(wrappers of binary streams wher all
             * all operations of converting the symbols to bytes are made in built-in classes)
             *  and byte(binary)
             * abstract class Stream represents byte stream and is a base class for all
             * stream classes that defines a set of standard stream operations
             * */

            /*byte stream classes:
             * 1.BufferedStream
             * (wraps a byte stream and adds buffering.
             * Buffering provides a performance enhancement in many cases)
             * 2.FileStream(designed for I/O operations)
             * 3.MemoryStream(uses ram for storage(array of bytes))
             * 4.UnmanagedMemoryStream(uses unmanaged memory for storage)
             * */

            /*Character stream wrapper classes
             * at the top of hierachy abstract classes:
             * TextReader(for output) and TextWriter(for input):
             * 1.StreamReader(reads characters from a byte stream,wraps byte input stream)
             * 2.StreamWriter(writes characters to a byte stream,wraps byte output stream)
             * 3.StringReader(reads characters from a string)
             * 4.StringWriter(writes characters to a string)
             * */

            /*Binary wrappers
             * 1.BinaryWriter
             * 2.BinaryReader
             * */

            /*Console input and output
             * 1.Console.In
             * 2.Console.Out
             * 3.Console.Error
             */

            //using (StreamWriter sw = new StreamWriter(File.Create("local.txt")))
            //{
            //    Console.SetOut(sw);
            //    Console.WriteLine("hello world");
            //}

            /* when file output is performed written chunk of data
              is not immediately written to the actual physical device.
              output is buffered by operating system
              until sizable chunk of data can be written all at once
              (this improves efficiency)
              disk files are organized by sectors and if the sector is full
              then data can be written to the file from buffer
              or call flush() to send data implicitely
            */

            //FileStream fs = new FileStream("fff.txt", FileMode.Create);
            //byte[] arr = Encoding.Default.GetBytes("Hello World\n I am jack");
            //fs.Write(arr, 0, arr.Length);
            //fs.Close();

            //StreamReader sr = null;
            //try
            //{
            //    sr = new StreamReader("fff.txt");
            //    while (!sr.EndOfStream)
            //    {
            //        Console.Write(sr.ReadLine());
            //    }
            //    Console.WriteLine();
            //}
            //catch(Exception)
            //{

            //}
            //finally
            //{
            //    if (sr != null) sr.Close();
            //}

            //BinaryWriter bw = new BinaryWriter(File.Create("binary.bat"));
            //bw.Write(true);
            //bw.Write("helllo World");
            //bw.Write(5);
            //bw.Close();


            //BinaryReader br = new BinaryReader(File.Open("binary.bat", FileMode.Open, FileAccess.ReadWrite));

            //Console.WriteLine(br.ReadBoolean());
            //Console.WriteLine(br.ReadString());
            //Console.WriteLine(br.ReadInt32());

            //br.Close();
            //Console.Read();
            //Console.In.Read();  

            /*File(static),FileInfo operations on the files
             * */

            //try
            //{
            //    foreach (string s in args)
            //    {
            //        Console.WriteLine(s);
            //    }
            //    File.Copy(args[0], args[1], true); // cant overrite already existing file
            //                                       // File.Copy("binary.bat", "binary1.bat", true);
            //                                       // these functions open a file read it byte to byte and write to another file
            //                                       // from the first one
            //    Directory.GetFiles(".\\");
            //    Directory.GetDirectories(".\\");
            //    Directory.GetParent(".\\");
            //    File.Delete(args[1]);
            //}
            //catch (IOException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //if (File.Exists("binary.bat"))
            //{
            //    FileInfo f = new FileInfo("binary.bat");
            //    f.CreationTime = DateTime.Now;

            //    DateTime dt =
            //                 File.GetCreationTime("binary.bat");
            //    Console.WriteLine(dt.ToString());

            //    if (DateTime.Now - dt < TimeSpan.FromDays(5.5))
            //    {
            //        Console.WriteLine(DateTime.Now - dt);
            //      }

            #endregion

            #region Delegates,Events,Lamda expressions
            /*Use of delegates:
             * - support events
             * - executing methods at runtime without having to know wht whose 
             * methods are at compile time
             * 
             * 1.delegate  - object that can refer to methods
             * -it holds the reference to the methods and call can
             * call mehods which it referes to
             * -the same delegate can refer to different methods at runtime
             * thus the method that will be called is not determined at compile time
             * rather at runtime
             * Delegate can refer to methods of objects(instance methods),static methods  of the same method signature
             * 
             * declaration:
             * delegate return-type Name (Parameters)
             * 2. event - notification to some action that occured
             * lambda -  a streamline unit of executable code
             * */

            #region method group conversion
            // it is using sa = str.ReplaceSpaces like this without specifying new operator
            // StringOps str = new StringOps();
            //StringAction sa = str.RemoveSpaces;
            //sa = str.ReplaceSpaces;
            //Console.WriteLine(sa.Invoke(" H ellO World"));
            //sa = new StringAction(RemoveSpaces);//  method isntance 
            //Console.WriteLine(sa(" H ellO World"));
            //sa = str.ReplaceSpaces;
            //Console.WriteLine(sa(" H ellO World"));

            #endregion

            #region Multicasting
            /*allows to create a chain(list) of methods that will be automatically called
             * using += to add or - -= to delete from chain a method
             * if the delegate returns the value, then the value returned by the last method 
             * will be the value of entire delegate invocation
             * thus such a list of methods will make use of void return type
             * 
             * it is powerful mechanism because it allows to define a set of methods
             * that can be executed as a unit!!!
             * */

            //StringOpsByRef str = new StringOpsByRef() ;
            //StringChain strChn = str.RemoveSpaces;
            //strChn += str.Reverse;
            //string s1 = " H e Lll o  DD";
            //string s2 = " H e Lll o  DD";
            //strChn(ref s1);
            //Console.WriteLine(s1);

            //StringChain strChnRemove = str.ReplaceSpaces;
            //strChnRemove += str.Reverse;

            // no exception occures when extracting not belonning references to the methods or methods itself
            //strChnRemove -= str.RemoveSpaces;
            //strChnRemove -= str.RemoveSpaces;
            //strChnRemove -= str.ReplaceSpaces;

            //strChnRemove -= strChn;// extracing chains of methods from chains of methods

            //strChnRemove(ref s2);
            //Console.WriteLine(s2);

            #endregion

            #region Covariance and Contravariance

            //console.Y Yob = new console.Y();
            //ChangeIt change = Contravariance.incA;
            //console.X Xob = new console.X();

            //Xob = change(Yob);// base to derived not derived to base!!!

            //change = Contravariance.incB;
            //Yob = (console.Y)change(Yob); // this method returns Y class because of Contravariance.incB

            //Console.WriteLine(Yob);

            #endregion

            #region Anonymous functions
            /*it allows to avoid writing a method that is called only by delegates
             * Anonymous function - unnamed block of code that is passed to
             * a delegate constructor
             * They devide into:
             * -anonymous methods 
             * (it is created with keyword delegate)!!!
             * if to pass params to method must use parenthesized parameter list
             * (type arg1,type2 arg2,...)
             * -lambda expressions
             * */

            //Count c =
            //    delegate (int j)
            //    {
            //        for (int i = 0; i < j; ++i)
            //            Console.WriteLine(i);
            //    };
            //c(10);

            //Vd action = delegate { Console.WriteLine("Hello"); };
            //action();

            //CountSum cs = delegate (int times)
            //{
            //    Console.WriteLine();
            //    int sum = 0;
            //    for (int i = 0; i < times; ++i)
            //    {
            //        sum += i;
            //        Console.WriteLine(i);
            //    }
            //    return sum;
            //};
            //Console.WriteLine("Sum:{0}", cs(20));

            #region Outer Variables
            /*Outer Variables - parameter whose scope includes anonymous method
             * when that variable is used by the method that variable is said to 
             * be captured
             * that varibale will stay in existance at least
             * until the delegate that captured it
             * is subject to garbage collection(delegate referring to that method 
             * is destroyed
             * */

            //CountSum cs = counter();
            //Console.WriteLine("sum is {0}",cs(3));
            //Console.WriteLine("sum is {0}", cs(5));

            /*wrong summary because the variable was previously captured
             * by   CountSum cs = delegate (int times) 
             * // cs object which is not released afterwards
             * it stays in existance until sc is subject to garbare collerctor
             * thus its value is not destroyed when 
             *   CountSum cs = counter();
             *   counter returns
             * when we run the same delegate the second and further times
             * -----------------------
             * when an anonymous method captures a variable that variable
             * cant go out of existance until the delegate that uses it 
             * is no longer being used
             * */
            #endregion

            #endregion

            #region Lambda Expressions
            /*there are two types:
             * -expression lambda (one statement on the right side to =>)
             * -statement lamdba( a block of lamba expressions within {} and 
             * return command if the delegate returns any type )
             * all lambda expression use lambda operator =>("goes to" or "becomes")
             * input paramerter(without type specifier) or (parameters) => lambda body
             * (int i)=>i++;
             * i=>i++;
             * (i,j)=>i*j;
             * if to use {} must specify return operator if the method returns a value
             * if the body is a single expression then it is no enclosed 
             * between braces.
             * */

            //lambdaDelegate ld = (int i) => ++i;
            //lambdaDelegate<int> result =
            //    (i, l, h) => i >= l && i <= h;
            ////lambdaDelegate ld = i=> ++i;

            //Console.WriteLine(ld(1));
            //Console.WriteLine("is in range:{0}", result(1, 2, 3));
            ////Action ac = () => Console.WriteLine("FF");
            ////Task.Run(delegate() { Console.WriteLine("Hello"); });
            ////Task.Run(() => Console.WriteLine("fff"));
            //StringAction Replace = s => s.Replace(' ', '-');
            //StringAction Remove = s =>
            //{
            //    StringBuilder newString = new StringBuilder();
            //    for (int i = 0; i < s.Length; ++i)
            //    {
            //        if (s[i] != ' ')
            //            newString.Append(s[i]);
            //    }
            //    return newString.ToString();
            //};
            //StringAction Reverse = s =>
            //{
            //    StringBuilder sb = new StringBuilder();
            //    for (int i = s.Length - 1; i >= 0; --i)
            //    {
            //        sb.Append(s[i]);
            //    }
            //    return sb.ToString();
            //};
            //Console.WriteLine(Reverse("H e l lo"));
            //Console.WriteLine(Replace(Remove(Reverse("H e l lo"))));
            //Console.WriteLine(Replace("H e l lo"));

            #endregion

            #region Events
            ///* it is a notification that smth. has occured.
            // * represented by delegates
            // * form:
            // * event event-delegate event-name;
            // * where:
            // * event-delegate is the name of the delegate used to support
            // * the event
            // * */

            //MyClassWithEvent ev = new MyClassWithEvent();
            //ev.SomeEvent += () => Console.WriteLine("Hello ");
            //ev.SomeEvent += delegate () { Console.WriteLine("World"); };
            //ev.onSomeEvent();

            ///* all events are actived through the delegates
            // * thus the event delegate type defines the signature and return type
            // * for the event
            // * events support only += and -= operators
            // * like delegates events can me multicast
            // * 
            // * satatic method handlers and object method hadnlers:
            // * when static method is used like an event handler it is 
            // * applied to the class 
            // * when object method hadnler is used like an event handler it is
            // * applied to the specific object instance thus each object of a class
            // * that wants to receice notifications must register individually
            // * */

            //X x1 = new X(1);
            //X x2 = new X(2);
            //X x3 = new X(3);
            //MyClassWithEvent ev2 = new MyClassWithEvent(); // this is just a class
            //ev2.SomeEvent2 += x1.AsignNewValue;
            //ev2.SomeEvent2 += x2.AsignNewValue;
            //ev2.SomeEvent2 += x3.AsignNewValue;

            ////each object registes and receives a separate notification

            //ev2.onSomeEvent2(x3);

            ///*Event accessors
            // * to take control over event list must use expanded form
            // * of event accessors.
            // * */
            //Y y = new Y();
            //X x = new X(1);

            //ev2.SomeEventManual += y.Yhandler;
            //ev2.SomeEventManual += x.Xhandler;
            //ev2.SomeEventManual += x.Xhandler;
            //ev2.SomeEventManual += x.Xhandler;

            //ev2.onSomeEventManual();

            #region .NET Event Guidelines
            /* to succeed the component compatibility with .NET framework
             * .NET guidelines require that event handlers have to have 
             * two parameters:
             * 1. reference to the object that generated the event
             * 2. EventArgs any other additional information that required
             * by the handler;
             *  the general form:
             *  void handler(object sender,EventArgs e){...}
             *  sender param is typically passed as this by the calling code
             *  EventArgs e contains additional information and can be ignored
             *  (pass null)
             *  EventArgs doesnt contain any additional fields it serves as
             *  a base class from which one derive a class that contains the
             *  necessary fields;
             *  EventArgs.Empty contains a static member which is an
             *  EventArgs object that contains no data
             *
             * EventHandler - a delegate in which no extra additional info 
             * is needed
             * */
            //Z1 z = new Z1();
            //z.Click += HandlerCaller;
            //z.Click += (o, e) => { HandlerCaller(o, e); };
            //z.ClickWithProperArgs += (o, e) => { Console.WriteLine("value{0}",e.i); };
            //z.call();
            //z.call();
            //z.callProperArgs();
            //z.callProperArgs();

            // for (int i = 97; i <= 122; ++i)
            // {
            //     dictionary.Add((char)i, 0);
            // }

            // KeyEventPressed kp = new KeyEventPressed();
            // int countKeysPressed = 0;

            // kp.KeyPressed += (o, e) =>
            // {
            //     Console.Clear();

            //     for (int i = 0; i < dictionary.Count; i++)
            //     {
            //         if( dictionary.ContainsKey(e.ch) )
            //         {
            //             dictionary[e.ch]++;
            //             break;
            //         }
            //     }

            //     List<int> lst = dictionary.Values.ToList<int>();

            //     for (int i = 97,j=0; i <= 122; ++i)
            //     {
            //         Console.Write((char)i + ":" + lst[j++] + "; ");
            //     }

            //     Console.WriteLine();
            // };
            // //kp.KeyPressed += (o, e) => Console.WriteLine(countKeysPressed++); 

            // //kp.KeyPressed += (o, e) => Console.WriteLine("Key was pressed:{0}",e.ch);
            // //kp.KeyPressed += (o, e) => { if (e.ch == '.') Console.WriteLine(e.ch + "- this is the final charcter"); };

            // Console.WriteLine("Write character, press . to stop");
            // ConsoleKeyInfo infoKey = new ConsoleKeyInfo();

            //do
            // {
            //     infoKey = Console.ReadKey(true);
            //     kp.OnKeyPressed(infoKey.KeyChar);

            // } while (infoKey.KeyChar != '.');

            #endregion

            #endregion

            #endregion

            #region NameSpaces
            /*
             * namespace restricts the visibility of a name within the namespace
             * not to arise name conflitcts one uses namespaces:
             * if custom names(variables,classes,namespaces)
             * are the same in the same scope with 
             * the third party names or library names;
             * form:
             * namespace name_of_namespace{...}
             * 
             * there are two forms of using directive:
             * -
             * namespace Program{
             * using namespace name;
             * ...
             * }
             * or
             * using namespace name;
             * namespace Program{
             *  ...
             *  }
             * directive using can be used if it is often appears 
             * a need to use data from some namespace
             * its declared in a file pior to any other declarations
             * or at the start of the namespace body
             * and in both kinds of declaratin all within the
             * using namespace body will be in a view of the embedded
             * namespace
             * -
             * using alies = name;
             * alies becomes another name for the type(such as class type)
             *  or namespace to shorten the long namespace path
             * using namespace  alies = name; 
             * or
             * using namespace  alies = name.MyClass;
             * namespace Program{
             *  ...
             *  alies.MyClass x = new alies.MyClass();in place of name;
             *  } 
             * */

            NamespaceTest.TestClass test = new NamespaceTest.TestClass();
            console.J test2 = new J();

            #endregion

#pragma warning disable
#pragma warning restore

            #region Assemblies
            /*
             * assebmly - is a file that contains all deployment 
             * and version information about program.
             * provides mechanism that supports safe component interaction
             * defines a scope!!!
             * assembly is made of 4 sections:
             * -manifest
             *  contains info about assebmly itself
             *  as name,version number,type mapping info,cultural settings
             * -metadata
             *  info about the data types used by the program
             * -program code
             *  stored in MSIL(microsoft intermediate language) format
             *  - constitute
             *  resources used by the program;
             *  
             *  the reason so this : when compiling exe  file 
             *  is actually an assembly that contains
             *   program`s  executable code as well as other types of 
             *   info
             *   **********************************************
             *   Internal Access Modifier
             *      it declares that a memver is known throughout 
             *      all files in an assembly, but unknown outside that 
             *      assembly(known throughout the program, but not elsewhere)
             *      internal can be used with conjunction with other 
             *      access modifiers
             *   
             * */
            #endregion

            #region Runtime Type ID,Reflection, and Attributes
            /* Runtime ID - mechanism that lets to identify the type
             * at runtime;
             * (
             * one can inspect what  type of object  is being reffered to
             * by a base class refference;
             * To test in advance will the type cast succeed,preventing 
             * an invalid cast exception;
             * keywords of runtime type identification:
             * is,as,typeof;
             *is:
             * expr is type (if the same type or compatible with  or
             * boxing and undoxing conversion exists then the outcome is true);
             *as:
             * if conversion fails varible is set to null(no exception thrown)
             * typeof:
             * retrieve the characteristics of the type
             * )
             * Reflection - is the feature that enables to obtain info 
             * about the type;(it lets to add functionality during 
             * execution;
             * Attribute - describes a characteristic of some element
             * of a program.appliable for classes,methods,fields...
             * */

            #region Type checking and casting
            // is - check the type
            //int i = 0;

            //if (i is int)
            //    Console.WriteLine("Int");

            //ParentClass pClass = new ParentClass();
            //ChildClass chClass = new ChildClass();

            //if (chClass is ParentClass) // works
            //    Console.WriteLine("ParentClass");

            //if (pClass is ChildClass) // doesnt work
            //    Console.WriteLine("ChildClass");

            //if (chClass is ParentClass)
            //    pClass = chClass;
            //// or 
            //// as  - checks the type and if valid casts ot it
            //pClass = chClass as ParentClass; // check if not null
            //pClass = new ParentClass();
            //if (pClass != null)
            //    Console.WriteLine("Cast is valid");

            //chClass = pClass as ChildClass;

            //if (chClass == null)
            //    Console.WriteLine("Cast is invalid");
            //else
            //    Console.WriteLine("Cast is valid");

            #endregion

            #region Type class

            //typeof the characteristics of type
            /* working with type:
             * - obtaining info about methods
             * - invoking methods
             * - constructing objects
             * - loading types from assemblies
             * */

            //Type t = typeof(ParentClass);//Known in advance
            //ParentClass parentClass = new ParentClass();

            //Console.WriteLine(t.FullName);
            //Console.WriteLine(t.IsAbstract);
            //Console.WriteLine(t.IsSerializable);
            //Console.WriteLine(t.IsSealed);

            //if (MemberTypes.TypeInfo == t.MemberType)
            //    Console.WriteLine(t.Name);

            //foreach (var item in t.GetMethods())// get methods of the type
            //                                    // all even inherited objects will be on the list
            //{
            //    Console.Write("{0} {1} parameters:", item.ReturnType.Name, item.Name);
            //    ParameterInfo[] p = item.GetParameters();
            //    if (p != null)
            //    {
            //        Console.Write("(");
            //        foreach (var param in p)
            //        {
            //            Console.Write(param.ParameterType.Name + " " + param.Name + "");
            //        }
            //        Console.WriteLine(")");
            //    }
            //}

            ///*
            // * must specify compulsory:
            // * BindingFlags.Static or BindingFlags.Instance
            // * and 
            // * BindingFlags.Public or BindingFlags.NonPublic
            // * or the method will result into empty elements array
            // * */

            //MethodInfo[] methInfo = t.GetMethods(BindingFlags.Static |
            //                                    BindingFlags.DeclaredOnly |
            //                                    BindingFlags.Public |
            //                                    BindingFlags.DeclaredOnly);

            //foreach (MethodInfo item in methInfo)
            //{
            //    if (item.Name.Equals("Work", StringComparison.CurrentCulture)
            //        && item.GetParameters()[0].ParameterType == typeof(int))
            //        // use if else for working with each element
            //        Console.WriteLine(item.Name);
            //}

            //object[] parameters = new object[1] { 111 };
            //methInfo[0].Invoke(parentClass, parameters); //call a method using reflection
            //methInfo[0].Invoke(null, new object[] { 1111 }); //call a method using reflection
            //obj - the reference to the object on which the method
            // is invoked, for static null,
            // number of params must be the same as method supplies
            // if no arguments needed params can be null

            /* the power of reflection becomes apparent when 
             * an object is created dynamically at runtime:
             * - obtain a list of the constructors
             * - create an instance of the type by inkoing one of ctors
             * (it allows to create an object at runtime without naming it
             * in a declaration statement).
             * 
             * */

            //ConstructorInfo[] ctorInfo = t.GetConstructors();
            //foreach (ConstructorInfo item in ctorInfo)
            //{
            //    ParentClass instace;
            //    if (item.GetParameters().Length == 0)
            //        instace = item.Invoke(null) as ParentClass;
            //    else if (item.GetParameters().Length == 1)
            //        instace = item.Invoke(new object[] { 12 }) as ParentClass;
            //    // count of params and types must be compatible with args
            //}
            //Console.WriteLine("ctor:{0}", ctorInfo[0].GetParameters());
            //parameters = new object[] { 21 };
            //object obj = ctorInfo[0].Invoke(parameters);

            #endregion

            #region Obtaining types from asseblies
            /* full power of reflection is when types are avaiable to
             * the program dynamicallys by analyzing the contents
             * of other assemblies.
             * (asseblies carry info about types in it)
             * reflection allows to load asseblies and create 
             * instances of any of its publicly available types
             * */

            //Assembly assembly =
            //    Assembly
            //        .LoadFrom(@"C:\Users\Jewgeni\Documents\Visual Studio 2015\Projects\console\AssemlyReflactionClasses\bin\Debug\AssemlyReflactionClasses.exe");
            //// or a dll file

            //Type[] typeArr = assembly.GetTypes();


            //ConstructorInfo[] info = typeArr[1].GetConstructors();

            //object[] param = new object[] { "Hello World" };

            //ParameterInfo[] infoParam = info[0].GetParameters();

            //object obj = null;

            //if (infoParam[0].ParameterType == typeof(string)
            //    && infoParam.Length == 1)
            //    obj = info[0].Invoke(param);

            //MethodInfo[] methInfo = typeArr[1].GetMethods(BindingFlags.Instance |
            //                                             BindingFlags.Public |
            //                                             BindingFlags.DeclaredOnly);//methods explicitly by the class obtained
            //                                                                        // to prevent calling the methods from object
            //                                                                        // MethodInfo[] methInfo = typeArr[1].GetMethods();//all methods


            //string s = methInfo[0].Invoke(obj, null) as string;
            //Console.WriteLine(s);

            #endregion

            #region Attributes
            /* its a declarative info about,
             * defines additional info associated with class,structure,method and so on;
             * attributes are specified in square brackets,preceding the item to which 
             * they apply; supplemental info attached to an item, attr is not a member of class.
             * supported by a class that inherit System.Attribute all attr classes inherit it;
             * 
             * attribute class:
             * when attribute class is declared it si preccedeed by an attribute called
             *  AttributeUsage:specifies the types of items to which the attribute can be applied
             * */

            //UseAttribute itemAttr = new UseAttribute();

            //// obtaining an object`s attributes
            //object[] attrArray =
            //            itemAttr.GetType().GetCustomAttributes(false);

            //foreach (Attribute it in attrArray)
            //{
            //    Console.WriteLine(it);
            //}

            //// false - defined by the specified type; true - all inheritance chain
            //RemarkAttribute attrOne =
            //               Attribute.GetCustomAttribute(itemAttr.GetType(),typeof(RemarkAttribute)) as RemarkAttribute;
            //Console.WriteLine(attrOne.Remark);


            #region Positional and Named Parameters

            /*passing args to the ctor is called positional parameter
             * the arg is linked to the param by its position is the args list;
             * one can create a named parameter which can be asigned inital value
             * by using its name;
             * named parameter is supported by public field or property
             * (read-write and none-static)
             * form:
             * [attrib(positional-param-list,named-param1 = value,named-param2 = value,...]
             * positional parametes if they exist come first,then the named params
             * (similar to named params in methods example: Meth(arg1:value1,arg2:val2);
             * not necessarly to give them values, default values will be asigned
             * */

            //UseAttributeWithNamedParam NamedParam = new UseAttributeWithNamedParam();

            ////getting class`s attributes
            //RemarkAttribute attr = 
            //        Attribute.GetCustomAttribute(NamedParam.GetType(),typeof(RemarkAttribute)) as RemarkAttribute;

            //Console.WriteLine(attr.Priority);
            //Console.WriteLine(attr.Remark);
            //Console.WriteLine(attr.supplement);

            //Console.WriteLine(attrOne);

            #endregion

            #region Built-in attributes
            /*  1.AttributeUsage:
             *  specifies the types of items to which an attribute can be applied
             *  its constructor - ctor(AttributeTargets validOn)
             *  it has named params:
             *  AllowMultiple =bool(can be applied more than one time to a single item)
             *  ,Inherited =bool(attribute is inherited by derived class)
             *  
             *  2.Conditional:
             *  allows to create conditional methods it is invoked only when 
             *  a specified symbol has been defiend via #define
             *  otherwise method is bypassed
             *  if the symbol is defined when the item with attribute is encountered
             *  during compilation, the attribute is applied
             *  conditional methods must return void and must be members of a class
             *  or structure not an interface and no override keyword.
             *  
             *  3.Obsolete:lets to mark program element as obsolete
             *  (устарелый; вышедший из употребления; старомодный)
             *  when the application is compiled
             *  
             * */

            //TestAttribute testAttr = new TestAttribute();
            //testAttr.RELEASE();
            //testAttr.TRIAL();

            #endregion

            #endregion



            #endregion

            #region Generics

            /*Generics means parameterized type
             * of classes,structures,methods,delegates... in which
             * the type of data upon which they operate is specified as a paremeter
             * grants:
             * -type safety(type errors are prevented at compile time,no runtime type errors)
             * -no need boxing and unboxing
             * -code re-use;
             * 
             * Generics type differ on their argument types!!!
             *  !!!!!GenericClass<int> not the same as GenericClass<double>!!!!!
             *  
             *  if not to use generic must have using casts and type checks;
             *  form:
             *  class<T> varname= new class<T>(T)
             * */

            //GenericClass<int> genInt = new GenericClass<int>(5);
            //genInt.ShowType();

            //GenericClass<double> genDouble = new GenericClass<double>(1.2);
            //genDouble.ShowType();

            //EventHandler<int> handler = new EventHandler<int>((o, x) => { Console.WriteLine("Hello"); });

            //GenericClass<EventHandler<int>> genEventHandler = new GenericClass<EventHandler<int>>(handler);
            //genEventHandler.ShowType();

            //genEventHandler.getObj().Invoke(null, 0);


            //GenClassTwoParams<string, string> p = new GenClassTwoParams<string, string>("1","2");
            //p.ShowTypes();

            ///* constraint type:
            // // when specifying type paramters one can restrict the typess
            // // class<T> varname= new class<T>(T) where T:constraints{..}
            // naked type constaint - type parameter specifies the base class bype constraint;
            // use:
            // - can specify interfaces for implementing methods
            // - constructor constraint(parameterless ctor)  class<T> where T: new()
            // - set template variable as the reference type  class<T> where T: class
            // ( if this 
            // - set template variable as the value type  class<T> where T: struct;
            // */

            //#region BaseClassConstraint
            /////*
            //// * -it lets to use the members of the base class:methods,properties
            //// * - args types of only of the base or derived types
            //// */

            ////PhoneList<PhoneNumber> phoneList =
            ////                new PhoneList<PhoneNumber>(new Friend("Jack","123",false));
            ////// or not to mix PhoneNumber <- Friend or Supplier;
            ////phoneList.Add(new Supplier("Jack", "123", true));

            ////foreach (var item in phoneList.findByName("Jack"))
            ////{
            ////    Console.WriteLine(item);
            ////}
            ////PhoneList<Friend> friendList = new PhoneList<Friend>(new Friend("Jack", "123", false));
            ////friendList.Add(new Friend("Jack", "123", false));
            ////friendList.Add(new Friend("Jack", "123", false));
            ////PhoneList <Supplier> supplierList = new PhoneList<Supplier>(new Supplier("Jack", "123", false));
            ////supplierList.Add(new Supplier("Jack", "123", false));
            ////supplierList.Add(new Supplier("Jack", "123", false));

            //#endregion

            //#region InterfaceConstraint
            ///*  a type argument must implement:
            // *  must be the interface type 
            // *  or 
            // *  the type that implements that interface
            // */
            //#endregion

            //#region New() constraint
            ///*
            // * create an instance of a generic type parameter
            // * (normally not allowed)
            // * the default ctor provided automaically or 
            // * manually defined ctor
            // */
            //C<customObj> c = new C<customObj>();

            //#endregion

            //#region Value and Reference type constraints
            ///*
            // * class name<T> where T:class
            // * only reference type allowed not int or bool so on...
            // * will result in compilation error
            // * cannot asing null to value types
            // * */


            ////MyReferenceClass<string> s = new MyReferenceClass<string>();
            ////MyStructClass<int> i = new MyStructClass<int>();

            //#endregion

            //#region Naked type constraint
            ///*
            // *  class gen<T,V> where V:T{...}
            // *  tells that V must be identical or inherit from T
            // *  if doesnt match the compile time error happens 
            // *  when gen is declared
            // */

            ////Gen<PhoneNumber,Friend> gen = new Gen<PhoneNumber, Friend>();
            //////Gen<Friend, int> gen1 = new Gen<Friend, int>();
            ////Console.WriteLine(gen.ToString());

            //#endregion

            //#region Default Values of Type Parameter
            ///*
            // * for reference type default value can be null or class type
            // * for value type - 0 or boolean
            // * for struct  - struct type
            // * 
            // * use default(type) - to asign default values
            // * 
            // */

            //#endregion

            //#region Generic Method
            ///*
            // * can use type paramters on its own
            // * possible to create a generic method in none generic class
            // * methodName<T,...> list of type args is a comma separated list;
            // * call form:
            // * methodName<type>(args) - explicit
            // * or
            // * methodName(args) - implicit(type inference) 
            // * when args are passed then types are detemined automatically based on args types
            // * 
            // */

            ////int[] arr1 = {1,2,3,4,5};
            ////int[] arr2 = new int[6];

            ////ArrayCopy.CopyInsert(100, 4, arr1, arr2); // type inference
            ////// ArrayCopy.CopyInsert<int>(100, 4, arr1, arr2);
            ////foreach (var item in arr2)
            ////{
            ////    Console.WriteLine(item);
            ////}


            ////Holder[] arrHolder1 = new Holder[5];
            ////Holder[] arrHolder2 = new Holder[6];

            ////for (int i = 0; i < arrHolder1.Length; i++)
            ////{
            ////    Random rnd = new Random();
            ////    arrHolder1[i] = new Holder(rnd.Next(0, 10));
            ////}

            ////ArrayCopy.CopyInsert<Holder>(new Holder(), 1, arrHolder1, arrHolder2);

            ////foreach (var item in arrHolder2)
            ////{
            ////    Console.WriteLine(item);
            ////}

            //#endregion

            //#region Generic Delegates
            ///* form:
            // * delegate returnType Name<type-parameter-list>(arg-list);
            // * */
            ////GenDelegateDemo demo = new GenDelegateDemo("Hello");
            ////GenDelegateDemo you = new GenDelegateDemo("You");
            ////GenericDelegate<GenDelegateDemo> gen = demo.Do;// new GenericDelegate<GenDelegateDemo>(demo.Do);

            ////Console.WriteLine(gen(you));

            ////GenericDelegate<int> genInt = demo.AbsNumber;// new GenericDelegate<int>(demo.AbsNumber);

            ////Console.WriteLine(genInt(-20));

            //#endregion

            //#region Comparasion
            ///* a class that implemetns a generic interaface must also be generic
            // * compiler doesnt know how to compare by fields or bits or etc
            // * the  IEquatable<T> 
            // *      IComparable<T>
            // *      must implement to determine the relative order of two elements
            // * */
            //MyArr<int>[] mArr = new MyArr<int>[3];
            //MyArr<int> m1 = new MyArr<int>(3);

            //List<MyArr<int>> listMyArr = new List<MyArr<int>>();

            //Random rnd = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    listMyArr.Add(new MyArr<int>(rnd.Next(0, 100)));

            //}

            //foreach (var item in listMyArr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n");
            //listMyArr.Sort();
            //foreach (var item in listMyArr)
            //{
            //    Console.Write(item + " ");
            //}


            ////mArr[0] = new MyArr<int>(5);
            ////mArr[1] = new MyArr<int>(2);
            ////mArr[2] = new MyArr<int>(3); 

            ////foreach (var item in mArr)
            ////{
            ////    Console.Write(item + " ");
            ////}

            ////  Console.WriteLine( CompareMethod( m1, mArr ) );

            //#endregion

            //#region Hierarchy
            ///*
            // * generic derived classes must also be generic as parent classes
            // * and involve all parent hierarchy to instantiate objects
            // * */
            //Hierarchy2<string, int> sHier = new Hierarchy2<string, int>("Hello", 5);

            //Console.WriteLine(sHier.ShowValues());

            //#endregion

            //#region Ambigity
            ///*
            // * when class has a couple of argument parameters
            // * */

            //AmbigityM<int, double> ambitigy1 = new AmbigityM<int, double>(); // ok since different types
            //AmbigityM<int, int> ambitigy2 = new AmbigityM<int, int>();

            //ambitigy1.set(1);

            ////ambitigy2.set(1); ambigity of the same type
            //// Solution: one can overload the method parameters
            //// while no constructed type that results in a conflict


            //// AmbigityM<NotGeneric, NotGeneric> obj = new AmbigityM<Generic<int>,Generic<int>>();
            //// forbiden but possible through interface references
            ///*
            // * 
            //*/

            //#endregion

            //#region CoVariance
            ///*
            // * covariance and contravariance is used with generics in interfaces and delegates
            // *  covariance:
            // *  enables a method to return type that is derived from the class specified by the type parameter,
            // *  in the past because of strict type - checking the return type had to match the type parameter precisely;
            // *  ( derived class were forbidden by the reference of the base class)
            // *  type preceding out keyword - covariant type;
            // *  works if the base reference is the interace of delgate;
            // *  restrictions:
            // *  - can be applied to a method return type;
            // *  - out cant be applied to a type parameter that is used to declare method parameter;
            // *  - works with reference types;
            // *  - cant be used as a constraint in where list
            // */

            //CoVariance<GenericClassA> covar = new GenCovarince<GenericClassA>(new GenericClassA("parent"));
            //Console.WriteLine(covar.ToString());
            //covar = new GenCovarince<GenericClassB>(new GenericClassB("derived"));
            //Console.WriteLine(covar.ToString());

            //#endregion

            //#region Contravariance

            ///*
            // * lets a method to use an argument whose type is a base class of the type specified 
            // * by the type parameter for that parameter;
            // * Contravariant type is preceeded with "in" keyword;
            // * constraints:
            // * - works only with method arguments
            // * - through the interfaces
            // */
            //GenericClassA instanceA = new GenericClassA("parent");
            //GenericClassB instanceB = new GenericClassB("derived");

            //ContraVariance<GenericClassA> contraVariance =
            //    new GenCovarince<GenericClassA>(instanceA);

            //contraVariance.Do(instanceA); // accepts both types of hierchy types
            //contraVariance.Do(instanceB);

            //ContraVariance<GenericClassB> contraVariance2 =
            //    new GenCovarince<GenericClassA>(instanceB);
            //// b can be cast to a


            ///* 
            // * no matter what type is specified until the types implement the same interface
            // */

            //contraVariance2.Do(instanceB);
            ////contraVariance2.Do(instanceA); awaits GenericClassB type argument
            //contraVariance2 = contraVariance; // contravariance
            //contraVariance2.Do(instanceB);


            //#endregion

            //#region Variant delegates
            ///*
            // * works as with interfaces
            // */

            //GenericClassA instanceA1 = new GenericClassA("parent");
            //GenericClassB instanceB1 = new GenericClassB("derived");

            //MyDelegateCon1<GenericClassA> del1 = (instanceA1.IsEqualByValue);
            //MyDelegateCon1<GenericClassB> del2 = (instanceB1.IsEqualByValue);

            //del2 = del1;

            //Console.WriteLine(del1(instanceA1));
            //Console.WriteLine(del1(instanceB1));

            //// Console.WriteLine(del2(instanceA1)); // becase type param is set to  GenericClassB not ot GenericClassA
            //Console.WriteLine(del2(instanceB1));

            //MyDelegateCon2<GenericClassA, GenericClassA> parentCoveriance = changeIt;
            //MyDelegateCon2<GenericClassB, GenericClassA> derivedCoveriance = changeIt;

            //   parentCoveriance = derivedCoveriance;

            //parentCoveriance(instanceA1);// derived type is used not the type paramter
            //parentCoveriance(instanceB1);

            ////derivedCoveriance(instanceA1);// derived type is used not the type paramter
            //derivedCoveriance(instanceB1);


            //#endregion





            #endregion

            #region Linque

            int[] iarr = { 9, 2, 4, 5, 2, 1, 5, 7, 8, 56, 34, 32, 12, 22, 3, 4, 121, 1 };

            #region text
            /*
             * language integrated query;
             * unifies the queries for dataset(ADO),xml,collections;
             * query is the core of linq;
             * using a query involves two key steps:
             * - the form of the query is created
             * - the query is executed(obtain results)
             * two types of interfaces to obtain info(generic and not):
             * -IEnemerable<T>(if the datasource implemetns this interface)
             * content can be accessed one at a time in a sequence
             * 
             */

            /* Query must begin with the keyword:
             * from 
             * and end with 
             * select or group clause
             * select detemines what type of value is enumerated bythe query
             * group returns data in groups which can be enumerated individually
             * where determines the criteria
             * */



            /* xCollection is called query variable(implicit type variable)
             * refers to the set of the rules defined by querys
             * IEnumerable<int> xCollection = from n in iarr..(explicitely typed variable)
             * or 
             * var xCollection = from n in iarr...(implicitely typed variable)
             * 
             * query it is a set of rules and it is not until the query is executed
             * to execute query use foreach or an IEnumerable variable
             * 
             * can be used multiple times 
             * execution of a query produces its own results every time
             * which are obrained by enumeration the current content;
             * 
             */

            /*xCollection - query variable
             * n - range variable  (type depends upon the data source type)
             * iarr -data source
             * 
             * as long as data source implements IEnumerable<T> no need to specify the type of range variable;
             * if the data source implements none-generic verison of IEnumerable need to specify type of range variable;
             * */
            #endregion

            //var xCollection = from n in iarr
            //                  where n > -1 && n % 2 == 0// must return bool this expression is called predicate
            //                  orderby n descending
            //                  select n;

            //foreach (var item in xCollection)
            //{
            //    Console.WriteLine(item);
            //}

            //iarr[0] = 0;

            //Console.WriteLine();
            //foreach (var item in xCollection)
            //{
            //    Console.WriteLine(item);
            //}

            //ArrayList myListLinq = new ArrayList();

            //for (int i = 0; i < 100; i++)
            //{
            //    myListLinq.Add(new GenericClassA("H"));
            //}

            //var resultLinq = from GenericClassA n in myListLinq // asign the type to n !!! 
            //                 select n;

            //foreach (var item in resultLinq)
            //{
            //    Console.WriteLine(item);
            //}


            #region data type relation
            /*
             * the type of range variable must agree with 
             * the type of the elements stored in the source
             * until the data source implements IEnumarable<T> the type inference
             * can be made and no need to specify the type of the range variable
             * // no need for arrays to specify the type of range non generic variable
             *  cause all arrays implicitly implement Ienumarable
             * */

            //LinqSet<subClass>[] arr = new LinqSet<subClass>[100];

            //var xSet1 = from LinqSet<subClass> n in arr
            //            select n;
            //// type n must agree with type parameter of ragne variable
            //// data type could not have a name thats why 
            ////  query variable type is set as var
            //// or if such a type exists then it can be IEnumerable<T>

            //Console.WriteLine(xSet1.GetType().Name);

            #endregion

            #region Filter Values with Where
            /* multiple where clauses are allowed for use
             */
            //int[] iarr2 = { 9, 2, 4, 5, 2, 1, 5, 7, 8, 56, 34, 32, 12, 22, 3, 4, 121, 1 };

            //var resultIarr2 = from x in iarr2
            //                  where x > 2
            //                  where x % 2 == 0
            //                  where x < 10
            //                  select x;
            //foreach (var item in resultIarr2)
            //{
            //    Console.WriteLine(item);
            //}

            //string[] addresses =
            //    {
            //    "google.com","facebook.com",".net","test",
            //        ".network", "IO.net"
            //    };

            //IEnumerable<string> resString =
            //    from string x in addresses
            //    where x.EndsWith(".net") && x.Length > 2
            //    select x;

            //foreach (var item in resString)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion

            #region Orderby
            /* 
             * can be used on one or more creteria
             * can be used as inclusive as the entire element
             * stored in the data source or as a restricted 
             * as a portion of a single field withing an element;
             * usage:
             * orderby sort-on how
             * multiple usage:
             * orderby sort-on1 how,sort-on2 how,...
             * how:ascending or descending
             * 
             * 
             */
            //int[] iarr3 = { 9, 2, 4, 5, 2, 1, 5, 7, 8, 56, 34, 32, 12, 22, 3, 4, 121, 1 };

            //var result_iarr3 =
            //    from x in iarr3
            //    orderby x descending
            //    select x;

            //string[] addresses2 =
            //  {
            //    "google.com","facebook.com",".net","test",
            //        ".network", "IO.net",".net!"
            //    };

            //var res_addresses2 = from x in addresses2
            //                     orderby x ascending, x.Length descending
            //                     select x;
            //Console.WriteLine();

            //foreach (var item in res_addresses2)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Select
            /*
             * determines what type of elements are obrained by the query
             * usage:
             * select expression
             * can return specific range of the range variable, applying 
             * some operation or transformation to the range variable
             * this is called projecting
             */

            //double[] arrdouble = { 11.2, 2.3, 5.6 };
            //var res_arrdouble = from i in arrdouble
            //                    where i > 0
            //                    select Math.Sqrt(i);

            //Console.WriteLine();
            //foreach (var item in res_arrdouble)
            //{
            //    Console.WriteLine(item);
            //}

            //Email[] em =
            //{
            //    new Email("me",".com"),
            //      new Email("you",".ru"),
            //        new Email("they",".uk"),
            //          new Email("she",".ukr")
            //};

            //var res_em = from Email x in em
            //             where x.name.Contains("e")
            //             orderby x.name,x.email
            //             select x.email;//list of emails
            //                            // type of the sequence returned is determined by the select clause

            //var res_contList = from Email x in em
            //             select new ContactList(x.name,x.email,"111");//list of emails

            #endregion

            #region Nested from clause
            /*
             * query can contain more than one from clause;
             * common use of nested from clause when a qurty needs to obtain data from 
             * different resources;
             * 
             * another use is to iterate over data source that is contained within another data source
             * 
             */
            //char[] chr1 = { 'A', 'B', 'C' };
            //char[] chr2 = { 'a', 'b', 'c' };

            //var res_chrs = from n1 in chr1
            //               from n2 in chr2
            //                   // where n2.Equals('a')
            //               select new PairChar(n1, n2);

            //foreach (PairChar item in res_chrs)
            //{
            //    Console.WriteLine(item);
            //}

            //List<List<int>> list = new List<List<int>>();

            //List<int> lst1 = new List<int>(new int[] { 1, 2, 3 });
            //List<int> lst2 = new List<int>(new int[] { 4, 5, 6 });
            //List<int> lst3 = new List<int>(new int[] { 7, 8, 9 });


            //list.Add(lst1);
            //list.Add(lst2);
            //list.Add(lst3);


            //var res_lst = from List<int> xcollection in list
            //              from int xelem in xcollection
            //              where xelem % 2 == 0
            //              select xelem;

            //foreach (var item in res_lst)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Group
            /*
             * enables to create results groupped by keys;
             * sequences of related items are easy to iterate over
             * 
             * group clause can end a query as the select clause
             * 
             * usage:
             * group range-variable by key;
             * 
             * the result of group is a sequence that contains elements of type IGrouping<Tkey,Telement> (system.linq)
             * defines a collection of object that share the common key.The type of query variable of a query returns a group 
             * is Ienumerable<IGrouping<Tkey,Telement>>;
             * IGrouping defined property  which returns a key associated with each group;
             * 
             */

            //string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
            //              "hsNameD.com", "hsNameE.org", "hsNameF.org",
            //              "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

            //var res_websites = from addr in websites
            //                   where addr.LastIndexOf('.') != -1 // doesnt contain a period
            //                   group addr by addr.Substring(addr.LastIndexOf('.'));

            //foreach (IGrouping<string,string> sites in res_websites) // by group 
            //{
            //    Console.WriteLine("Web domain: " + sites.Key + "; Type:" + sites.GetType().Name);

            //    foreach (string site in sites)// by values within a group
            //            {
            //                Console.WriteLine(site);
            //            }
            //}


            #endregion

            #region Continuation
            /*
             * temporary result that will be used by a subsequent part of the query to produce the final result;
             * usage:
             * into name query-body;
             * name is name of the range variable that iterates over the temporary result 
             * and is used by continuinig query
             * into is called query continuation
             * used with select or group clause to continue a query
             */

            //string[] websites2 = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
            //              "hsNameD.com", "hsNameE.org", "hsNameF.org",
            //              "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

            //var res_websites2 = from addr in websites2
            //                    where addr.LastIndexOf('.') != -1 // doesnt contain a period
            //                    group addr by addr.Substring(addr.LastIndexOf('.'))
            //                    into ws
            //                    where ws.Count<string>() > 1 // continuation
            //                    orderby ws.Key ascending
            //                    select ws;// ws will range over group obtained by group

            //foreach (IGrouping<string, string> sites in res_websites2) // by group 
            //{
            //    Console.WriteLine("Web domain: " + sites.Key + "; Type:" + sites.GetType().Name);

            //    foreach (string site in sites)// by values within a group
            //    {
            //        Console.WriteLine(site);
            //    }
            //}


            #endregion

            #region Let
            /*
             * retains a value temporarily;
             * usage:
             * let name = expression
             * can create another enumerable data source
             */
            //string[] strArr = { "abc", "dfccfg", "tyabu" };

            //var res_strArr = from str in strArr
            //                 let chr = str.ToArray<char>()
            //                 from letter in chr
            //                 orderby letter
            //                 group letter by letter;

            //foreach (IGrouping<char, char> sites in res_strArr) // by group 
            //{
            //    Console.WriteLine("Web domain: " + sites.Key + "; Type:" + sites.GetType().Name);

            //    //foreach (char site in sites)// by values within a group
            //    //{s
            //    //    Console.WriteLine(site);
            //    //}
            //}


            #endregion

            #region Joins

            /*
             * each data source must contain data in common wiht another one data source
             * and that the data can be compared for equality;
             * allows  to create a new list out of multiple data sources
             * usage:
             * from range-varA in data-sourceA
             *  join range-varB in data-sourceB
             *  on range-varA.property equals data-sourceA.property
             *  
             * possible to use with into and so on 
             */

            //Item[] items = {
            //         new Item("Pliers", 1424),
            //         new Item("Hammer", 7892),
            //         new Item("Wrench", 8534),
            //         new Item("Saw", 6411)
            //    };

            //InStockStatus[] statusList = {
            //         new InStockStatus(1424, true),
            //         new InStockStatus(7892, false),
            //         new InStockStatus(8534, true),
            //         new InStockStatus(6411, true)
            //    };

            //var resstatusList = from item in items
            //                    join entry in statusList
            //                    on item.ItemNumber equals entry.ItemNumber
            //                    select new Temp(item.Name, entry.InStock);

            //foreach (var item in resstatusList)
            //{
            //    Console.WriteLine(item.Name + " is in stock:" + item.InStock);
            //}

            #endregion

            #region Anonymous Type

            /*
             * it s a class that has no name
             * its  primary use to  create objects from select clause[operator]
             * general form of creating anonymous type variable:
             * new{ nameA= val1, nameB = val2,...}
             * object initializers provied a way to initlize an object without explicitly invoking constructor
             * anonymous type variable cant explicitly invoke contrtuctor
             * when anonymous type is specified its members become read-only public properties;
             * protection initializer:
             * new{ val1,val2,...}
             * 
             * 
             */

            //Item iedsd = new Item { Name = "jack", ItemNumber = 5 }; // need to have a ctor taking none argument

            //var some = new { i = 5, s = "111" };
            //var some2 = new { s = "111" };

            //var resstatusList2 = from item in items
            //                     join entry in statusList
            //                     on item.ItemNumber equals entry.ItemNumber
            //                     select new { Name = item.Name, InStock = entry.InStock };
            ////select new { item.Name, entry.InStock }; // protection initializer

            //Console.WriteLine();

            //foreach (var item in resstatusList2)
            //{
            //    Console.WriteLine(item.Name + " " + item.InStock);
            //}

            //Console.WriteLine(some.GetType().Equals(some2.GetType()));


            #endregion

            #region Group Join

            //string[] ways = new string[] { "Land", "Air", "Sea" };

            //Transport[] transports = {
            //     new Transport("Bicycle", "Land"),
            //     new Transport("Balloon", "Air"),
            //     new Transport("Boat", "Sea"),
            //     new Transport("Jet", "Air"),
            //     new Transport("Canoe", "Sea"),
            //     new Transport("Biplane", "Air"),
            //     new Transport("Car", "Land"),
            //     new Transport("Cargo Ship", "Sea"),
            //     new Transport("Train", "Land")
            // };

            //var res_transports = from how in ways
            //                     join trans in transports.Where(x =>x.Name.Equals("Bicycle"))
            //                     on how equals trans.How
            //                     into lst // collection of items
            //                     select new { How = how, Trans = lst };

            //foreach (var way in res_transports)
            //{
            //    Console.WriteLine(way.How + ":");
            //    foreach (var item in way.Trans)
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}


            #endregion

            #region Queries and query methods
            /*
             * it is possible to create queries with lambda expression that dont use query syntax
             * instead query methods are called
             * 
             * Can be called on any Enumerable objects!!!
             * usage:
             * select
             * where
             * orderby
             * join
             * group
             */

            //int[] ar1 = { 1, 2, 3, 4, 5, 23, 21, 21, 22 };
            //int[] ar2 = { 1, 2, 3 };

            ////var v = ar1.OrderBy<int, int>(i => i)
            ////.Join<int, int, int, object>(ar2, i => i, i => i, (i1, i2) => new { i1, i2 });

            //var v = ar1.OrderByDescending<int, int>(i => i)
            //    .Distinct<int>()
            //    .GroupBy<int, int>(x => x % 2);

            ////.Select<int, int>(x => x * x);

            //// instead of anonymous type object...

            //foreach (var item in v)
            //{
            //    Console.WriteLine(item.Key + ": ");
            //    foreach (var t in item)
            //    {
            //        Console.WriteLine(t);

            //    }
            //}

            //string[] domains = { ".com", ".org" };

            //string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net",
            //              "hsNameD.com", "hsNameE.org", "hsNameF.org",
            //              "hsNameG.tv",  "hsNameH.net", "hsNameI.tv" };

            //var result_web = websites
            //      .Skip<string>(1)
            //      .Where<string>(s => s.LastIndexOf('.') != -1)
            //      .GroupBy<string, string>(s => s.Substring(s.LastIndexOf('.')))
            //      .AsParallel();

            //var get_addresses = domains
            //    .Join(websites, dom => dom, web => web.Substring(web.LastIndexOf(".")), (dom, web) => new { Domain = dom, Web = web })
            //    .GroupBy(x => x.Domain);

            //Console.WriteLine();

            //foreach (var Domain in get_addresses)
            //{
            //    Console.WriteLine(Domain.Key + ": ");
            //    foreach (var website in Domain)
            //    {
            //        Console.WriteLine(website.Web);
            //    }
            //}
            /* C# has two ways of creating queries: the query 
                syntax and the query methods
                two approaches are more closely related than 
                you might at first assume. The reason is that the query syntax is compiled into calls to the 
                query methods. Thus, when you write something like
                where x < 10
                the compiler translates it into
                Where(x => x < 10)
                Therefore, the two approaches to creating a query ultimately lead to the same place.
                Given that the two approaches are ultimately equivalent, the following question 
                naturally arises: Which approach is best for a C# program? The answer: In general, you 
                will want to use the query syntax. It is fully integrated into the C# language, supported 
                by keywords and syntax, and is cleaner.
             * */



            #endregion

            #region Extension Query Methods
            /*
               * defined for Ienumerable<T> be IEnumerable
               */

            //Console.WriteLine(ar1.Count<int>());

            //int[] iarray = ar1.Reverse<int>().ToArray<int>();

            //iarray.Concat<int>(new int[] { 1, 2, 3 });

            //iarray.Any<int>(x=>x%2==0); // any even

            //iarray.ToDictionary<int, string>(x => x.ToString()).Distinct<KeyValuePair<string,int>>();

            //var resSomeOp = from x in iarray
            //                let num = iarray.Average<int>(z=>z)
            //                where x > x
            //                select x;

            #endregion

            #region Deferred and Immediate query execution
            /*
               * there are two methods of execution:
               * immediate and deferred;
               * query defines a set of rules which are not executed until a foreach statment
               * 
               * if to use one of the extension methods that produce none sequence result then the query must be executed to obtain the result
               */
            //int[] ar3 = { 1, 2, 3, 4, 5, 23, 21, 21, 22 };

            //int i_result = (from x in ar3 // immediate execution
            //                where x > 3
            //                select x).Count();

            //var query = from x in ar3 // deferred execution
            //            where x > 3
            //            select x;

            //int someValue = query.Count(); // executes here

            #endregion

            #region Expression Trees
            /*
               * it is  representation of a lambda expression as data;
               * thus expression tree cant be executed itself;
               * though can be converted into executable form;
               * encapsulated by delegate Expression<TDelegate> class (system.linq.expressions);
               * useful when the query will be executed outside the program like a database
               * that uses sql
               *  By representing the query as data, the query can be converted into a 
                  format understood by the database.
               * mentioned earlier, when the query methods were described, but there are several others.
                  Expression trees have one key restriction: Only expression lambdas can be represented 
                  by expression trees.
                 * 
                 * You can obtain an executable form of an expression tree by calling the Compile( )
                  method defined by Expression. It returns a reference that can be assigned to a delegate and 
                  then executed.
               */

            //Expression<Func<int, bool>> isEven = x => x % 2 == 0;

            //       Expression<Del<int, bool>> isEvenOnMyDel = x => x % 2 == 0;

            //       Func<int, bool> expDel = isEven.Compile();

            //       Del<int, bool> expMyDel = isEvenOnMyDel.Compile();

            ////       isEven.Compile()(2); // usage of compile

            //       if (expDel(2))
            //           Console.WriteLine("even");

            //       Func<int, string, double, object, bool> ffff = (i, s, d, o) => { return false; };

            #endregion

            #region EXTENSION METHODS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            /*
               * 
               * provide the means by which  functionality can be added to a class without using inheritance machanism;
               * extension method must be static tha must be contained within a static,none-generic class;
               * the type of its parameter determines the type on which the extension method will be called;
               * the first parameter must be modified with  this;
               * The object on 
                  which the method is invoked is passed automatically to the first parameter. It is not explicitly 
                  passed in the argument list. A key point is that even though an extension method is declared 
                  static, it can still be called on an object, just as if it were an instance method.
              usgage:
               static re-type name(this invoked-on-type ob,param-list) 
               * or param list can be empty 
               * 
               * the first parameter is automatically passed to object on which the method is invoked
               * 
               *  an extension method must be declared within a static class. 
                  Furthermore, this class must be in scope in order for the extension methods that it contains 
                  to be used. (This is why you needed to include the System.Linq namespace to use the LINQ-
                  related extension methods.) Next, notice the calls to the extension methods. They are 
                  invoked on an object, in just the same way that an instance method is called. The main 
                  difference is that the invoking object is passed to the first parameter of the extension 
                  method. Therefore, when the expression

               */


            int ccccc = 10;

            //ccccc.ToConsole();
            //ccccc.ToConsole(5);

            #endregion

            #endregion

            #region Unsafe code,partial Classes,partial methods,dynamic types
            #region Pointers
            /*
           * unsafe code - code that doesnt run under full management of CLR(its not possible to verify 
           * that it wondt perform some type of harmful action) - code not the subjec to the 
           * supervision of CLR.
           * managed code prevents use of pointers;
           * pointer can point anywhere in the memory it is easy to misuse a pointer;
           * reference refers to an object of its type;
           * 
           */
            #endregion

            #region Nullabel types
            /*
             * it simply adds the ability to represent a value that indicates that a variable 
             * of that type is unassigned;
             * Nullable types of object of System.Nullable<T> where T
             * 
             * nullable type  - speacial version of a value type that is
             * represented by a structure.
             * underlying type of a varialbe of a value type has the same characteristics as 
             * underlying type plus can also store the value null
             * ONLY VALUE TYPES HAVE NULLABLE EQUIVALENTS;
             * can declare explicitly and implicitly
             *   Nullable<int> i = new Nullable<int>(5);
             *   
             *and implicitly:
             * 
             * type? name  
             */

            // Nullable<int> i = new Nullable<int>(1);
            // Nullable<bool> b = null;// implicit inializing

            // int? iNull = null;// explicit inializing
            // int? Result ;// implicit inializing
            // // it satisfies the constraint: variable must be initialized before the use
            // // conversion between nullable type and underlying type is predefined

            // int? idef = 100;

            // // two ways to determine if the nullable variable type was assigned a value or not
            // //if to try to get a value of from a variable that holds null - invalideoperationException
            //if( idef.HasValue)
            //     Console.WriteLine("has value");
            // if (idef !=null)
            //     Console.WriteLine("has value:{0}", idef.Value);
            // // when a nonenullable variable type is mixed in an operation with a nullable variable type
            // int iNoneNullable = 100;
            // Result = idef + iNoneNullable;

            // if (Result.HasValue)
            // {
            //     Console.WriteLine(Result.Value);
            // }

            // // if to try to cast a nullable object that contains null to its underlying type
            // // exception is thrown
            // int? nullable = null;

            // // iNoneNullable = (int)nullable; // an exception is thrown
            // /*
            //  * usage:
            //  * nullabe-object??default-value
            //  * 
            //  * it lets to specify  a default value that will be used when nullable object contains null
            //  * it also eliminates the need in cast
            //  * */

            // iNoneNullable = nullable??0; // coalescing operator??
            // int? currentBalance = null;

            // int iBalance = currentBalance ?? GetZerobalance();// if currentBalance has value then that value will be asigned

            // // when using logical and relational operators if one of the nullable type is null
            // // the result is always false
            // byte? big = 44;
            // byte? less = null;

            // if ((big>less)||(big < less)) // false
            // {
            //     Console.WriteLine("success");
            // }
            /*
             * when expression involeves bool? the result of expression can be true,false,null
             * */
            #endregion

            #region Partial Types
            /*
             * class,structure,interface can de splitted into two or more pieces
             * ressiding in a separate file;
             * form:
             * partial type typename{...}
             */



            #endregion

            #region Partial Methods
            /*
             * allows to create a declaration of a method within one part 
             * of a partial class and implementation is another one
             * */
            MyPartialClass cl = new MyPartialClass();
            cl.ShowInShow();

            #endregion

            #region Dynamic Types
            /*
             * usage:
             * -when the type of object is known only at runtime
             * -accessing COM objects;
             * -using reflection;
             * is asumed to support any operation,methods,operators...
             * it lets to compile code without errors
             * if at runtime the objects actual type doesnt support the operation
             * then an exception is thrown
             * 
             * dynamic type is similar to object can refer to any type of object
             * dynamic checking type ferred untill runtime
             * */


            // dynamic str = "qwerty";
            // dynamic val = 1;
            // val += 10;

            // string s = str;

            // str = str.ToUpper();

            // Console.WriteLine(str);
            // /*************************************************/
            // Assembly assembly = Assembly
            //   .LoadFrom(@"C:\Users\Jewgeni\Documents\Visual Studio 2015\Projects\console\ClassLibrary1\bin\Debug\ClassLibrary1.dll");

            // Type[] allTypes = assembly.GetTypes();

            // int j = 0;
            // for (; j < allTypes.Length; j++)
            //     if (allTypes[j].Name.Equals("AnotherClass"))
            //         break;

            //     if (j == allTypes.Length)
            //     {
            //         Console.WriteLine("AnotherClass not found");
            //         return;
            //     }

            //     Type myType = allTypes[j];

            //     ConstructorInfo[] ctor = myType.GetConstructors();

            //     int c = 0;
            //     for (; c < ctor.Length; c++)
            //         if (ctor[c].GetParameters().Length == 0) break; // find default ctor


            // if ( ctor.Length == c)
            //     {
            //         Console.WriteLine("def ctor not found");
            //     }
            // // dynamic object
            // dynamic obj1 = ctor[j].Invoke(null);


            // obj1.ShowMessage();

            //var vv = allTypes[j].GetMethods().Where<MethodInfo>(x => x.Name.Contains("Show")).Select<MethodInfo,MethodInfo>(x => x);

            // allTypes[j].GetMethods()[1].Invoke(null, null);//specify an instance of the class obj1
            // for a method in which it is defined
            // if method is static may pass null arg in the firsth place

            // friedn assembly InternalsVisibleTo attribute

            #endregion

            #region Miscelleonous keywords

            #region Lock
            /*
             * used for multiplethread programming;
             * when multiple threads try to use a resource that can be used by only one thread
             * at a time, - such a problem can be used by creating ctitial section:
             * lock(obj)
             * {
             * 
             * }
             * obj - on which the lock is synchronized;
             * if one thread has already entered the section the second thread will wait
             * until the first one exits the critical section;
             * here can be deadlocks...
             */
            #endregion

            #region readonly
            /* readonly
             * appliable to fields of classes
           * readonly field within a class can be given a value only by initializing
           * when it is declared or by assigning it a value with a constructor
           * once the value has been set it cant be changed outside the constructor
           * static and none static fields allowed
           */

            // ReadOnlyTestStaticClass.i = 1; not allowed to changed readonly fields
            #endregion

            #region const and volatile
            /*
             * const modifier is used to declare fields or local variable that
             * cant be changed, these variables must be given initial variables when 
             * they are declared.
             * const field cant be set within the ctor, but readonly field can
             */
            const int constVariable = 10;
            // constVariable = 1;

            /*
             * volatile:
             * fields value may be changed by two or more threads
             * one thread may not know in this case when the field has been changed
             * by another thread.
             */
            #endregion

            #region Using 
            /*
             * using include namespace
             * and 
             * has another purpose:
             * using(obj)
             * {
             * //use obj
             * }
             * 
             * using(obj = initializer)
             * {
             * //use obj
             * }
             * obj must implement system.Idisposable interface
             * 
             * in the end of block of using statement resources are disposed
             * useful when working with files it automaticaly closes the resources enctountin end
             */

            //StreamReader sr =null;
            //using ( sr = new StreamReader(File.OpenRead("..\\..\\Program.cs")))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}

            // Console.WriteLine(sr.ReadToEnd()); stream is closed here 
            // the reference is actual but resources are not


            #endregion

            #region Extern
            /*
             * has two uses:
             * 1.declaring extern methods:
             * indicates that a method is provided  by unmanaged code that is not part of 
             * the program.
             * Method is supplieb by external code;
             * to declare method as extern precede extern before method declaration
             * declaration must not include any body
             * usage:
             * extern ret-type meth-name(arg-list);
             * often used by DLLImport attribute, which specifies the dll that contains the method
             * 
             * declaring extern assembly alies:
             * if in different assemblies are the classes with the same names 
             * and when program include assemblies, to solve such a problem need to
             * create alies for assebmlies:
             * 1 specify the ales using /r compiler option
             * /r:Asm1  = test1.dll
             * /r:Asm2  = test2.dll
             * 2.   
             * extern alies Asm1; // must be on top of the file
             *  extern alies Asm2;
             */

            #endregion

            #endregion

            #endregion

            #region System Namespace
            //WeakReference w = new WeakReference(5);
            //Console.WriteLine("weak{0}",w.Target);
            //GC.Collect();
            //Console.WriteLine(w.Target);

            float f;
            float.TryParse("FF", out f);

            bool? booleanVar = false;

            MyClassComparable[] iar = {
                new MyClassComparable(2), new MyClassComparable(4),
                new MyClassComparable(3), new MyClassComparable(1),
                new MyClassComparable(5),new MyClassComparable(3),
                new MyClassComparable(6),new MyClassComparable(2)
            };

            Array.Sort<MyClassComparable>(iar);
            foreach (var item in iar)
            {
                Console.WriteLine(item.ToString());
            }

            string[] sarr = { "ff", "ssf", "saf", "baf", "bbf" };

            Array.Sort(sarr, StringComparer.CurrentCulture);

            Console.WriteLine(Array.TrueForAll<string>(sarr, x => x.Contains("ff")));

            Array.ForEach<MyClassComparable>(iar, x => Console.WriteLine(x));

            Array.Sort<MyClassComparable>(iar);
            //lst.BinarySearch(1)

            bool? bl = BitConverter.IsLittleEndian;
            Console.WriteLine(bl);

            Convert.ChangeType(5.1, typeof(int));
            //Encoding.Unicode.GetString()// works with collections
            //BitConverter;//works with simple types to get or sent into byte collection

            #region GC and Memory manegment

            Console.WriteLine(GC.GetTotalMemory(false).ToString());

            //var t = Tuple.Create(1, 2, 3, 4, 5); hold a collecion of different objects 

            #endregion

            #region Interfaces
            /*
             * Icomparable Icomparable<T>:
             * let to compae one object to another
             * 
             *int CompareTo(object obj)
             * 
             * compares invoking object to invoked
             * if this > obj return 1
             * if this < obj return -1
             * if this == obj return 0
             * 
             * IEquatable<T> or IEquatable
             * implemented by those classed that need to define how two objects should be
             * compared
             * bool Equals(T object);
             * imlementing this interface usually you ll need to override 
             * Equals(object) and GetHashCode() methods for classes;
             * 
             * IFormatProvider - need to use to return object that controls the formatting of data
             * into a human-readalbe string;
             * 
             * IObservable<T> and IObserver<T> 
             * one class provides notifications to another
             * registring an object to observer class 
             */
            #endregion

            #endregion

            #region String
            /*
             * it s a value type;
             * once a string has been created the character sequence
             * that comprises the string cant be altered!!!
             * But references can refer to different new string objects
             * StringBuilder an object of string type whose lenth of characters
             * can be variable;
             * a string literal automatically created a string object
             * that s why it is used like it
             * string s = "hello";
             */
            //string s = "hello";
            //Console.WriteLine(value: s[0]);// indexer public char this[int index]

            //string operators
            /*
             * == and !=
             * normally if == or != applies to value type it determines 
             * if two object refer to the same object;
             * this differs for String type
             * when it applies to it the content of objects are
             * compared;
             * though >=,,=,<,> compare the references;
             * to determine if one string is greater or less than another
             * user Compare() or CompareTo();
             * cultural information strings with it 
             * compare ordinal values(the binary values of character)
             * 
             * Comparation can be made in 2 ways:
             * -can reflect the customs and norms of a given culture(culture sensivite)
             * (it uses dictionary order)
             * - using only ordinal values of characters
             */

            //string.Compare("hello", "hell", StringComparison.OrdinalIgnoreCase);


            //if (0==string.Compare("hello", 0, "hell", 0, 4, StringComparison.CurrentCulture))
            //    Console.WriteLine("ok");
            /*
             * equals(string value) - is the same as ==
             * returns 0 if contains the same character sequence of chars
             * 
             * 
             */
            //string str1 = "alpha";
            //string str2 = "Alpha";
            //string str4 = "alpha";
            //int? res = null;

            //res = string.Compare(str1, str2, StringComparison.CurrentCulture);
            //{
            //    if (res == 0)
            //        Console.WriteLine("ok");

            //    if (res > 0)
            //        Console.WriteLine(str1 + " is greater " + (byte)str1[0]);

            //    if (res < 0)
            //        Console.WriteLine(str2 + " is greater " + (byte)str2[0]);

            //}

            //res = string.Compare(str1, str2, StringComparison.Ordinal);
            //{
            //    if (res == 0)
            //        Console.WriteLine("ok");

            //    if (res > 0)
            //        Console.WriteLine(str1 + " is greater " + (byte)str1[0]);

            //    if (res < 0)
            //        Console.WriteLine(str2 + " is greater " + (byte)str2[0]);
            //}

            //res = string.Compare(str1, str4, StringComparison.CurrentCulture);
            //{
            //    if (res == 0)
            //        Console.WriteLine("ok");

            //    if (res > 0)
            //        Console.WriteLine(str1 + " is greater " + (byte)str1[0]);

            //    if (res < 0)
            //        Console.WriteLine(str4 + " is greater " + (byte)str4[0]);
            //}

            //res = string.CompareOrdinal(str1, str4);
            //{
            //    if (res == 0)
            //        Console.WriteLine("ok");

            //    if (res > 0)
            //        Console.WriteLine(str1 + " is greater " + (byte)str1[0]);

            //    if (res < 0)
            //        Console.WriteLine(str4 + " is greater " + (byte)str4[0]);
            //}


            //// concat
            //string newString = string.Concat("jack", " ", " Hello");

            //// searchig a string
            //newString.IndexOfAny(new char[] { 'f', 'v' });
            ////splitting and joining

            //var varSplitter = newString.Split(' ');// array of strings

            //string singleString = string.Join(" ", varSplitter);// one string

            //string[] expr =
            //    {"100 - 1","3 * 5","65 / 3"};


            //for (int iter = 0; iter < expr.Length; iter++)
            //{
            //    string[] parts = expr[iter].Split(new char[] { });
            //    Console.WriteLine(expr[iter] + " result:");

            //    switch (parts[1])
            //    {
            //        case "-":
            //            Console.WriteLine(double.Parse(parts[0]) - double.Parse(parts[2]));
            //            break;
            //        case "/":
            //            Console.WriteLine(double.Parse(parts[0]) / double.Parse(parts[2]));
            //            break;
            //        case "+":
            //            Console.WriteLine(double.Parse(parts[0]) + double.Parse(parts[2]));
            //            break;
            //    }
            //}

            //string sIns = "Heelo";
            //sIns = sIns.Insert(sIns.Length, "Bob");
            //Console.WriteLine(sIns);
            //sIns = sIns.Remove(0, 3);
            //Console.WriteLine(sIns);
            //sIns = sIns.Replace("lo", "la");
            //Console.WriteLine(sIns);

            //Console.WriteLine(sIns.ToUpper(new System.Globalization.CultureInfo(1)));
            //Console.WriteLine(sIns.ToUpperInvariant());

            #region Formatting
            /*
             * formatting is governed by format specifier and
             * format provider;
             * format specifier is responsible for the form of output of data;
             * format provider - to handle cultural and language differences;
             * (is created by IFormatProvider interface) which defins GetFormat() 
             * method;
             * 
             * format commands:
             * WriteLine("format string",arg1,arg2..);
             * format string contains two items:
             * regular,printing characters that are displayed as -is and format items
             * {argnum,width:fmt}
             * argnum - the number of argument to display;
             * width - width of the field;
             * it is optional params
             * 
             */
            //int iDisplay = 2223;
            //Console.WriteLine(string.Format("{0:F3}", iDisplay));
            //Console.WriteLine(string.Format("{0,2:F1}", iDisplay));
            //Console.WriteLine(string.Format("{0,3:N8}", iDisplay));
            //Console.WriteLine(string.Format("{0,3:E}", iDisplay));
            //Console.WriteLine(string.Format("{0,3:e}", iDisplay));
            //Console.WriteLine(string.Format("{0,3:F}", iDisplay));
            //Console.WriteLine(string.Format("{0,3:G}", iDisplay));
            //Console.WriteLine(string.Format("{0:D15}", iDisplay));
            //Console.WriteLine(string.Format("{0:P}", iDisplay));
            //Console.WriteLine(string.Format("{0:X}", iDisplay));

            //Console.WriteLine(3.ToString("F20"));
            //#region Custom Numeric Format
            ///*
            // * need to create an exmaple
            // * (picture e.a. picture format - how
            // * the output will look like)
            // * # digit
            // * . demical point
            // * , thousands separator
            // * 0 padds with leading or trailing zeros
            // * % percentage
            // * ; separator describes the format positive,negative and zero values
            // */
            //Console.WriteLine("{0:00##.#00}", 21.37);
            //Console.WriteLine("{0:#,###.#00}", 2123.3);
            //Console.WriteLine("{0:#,###.#00}", 21231234.3);// each third is thousand separator
            //Console.WriteLine("{0:#,###.#00 \t\n money}", 21231234.3);// each third is thousand separator



            //#endregion

            //#region Datetime
            //// datetime

            //Console.WriteLine("{0:d}", DateTime.Now);
            //Console.WriteLine("{0:D}", DateTime.Now);
            //Console.WriteLine("{0:t}", DateTime.Now);
            //Console.WriteLine("{0:T}", DateTime.Now);
            //Console.WriteLine("{0:f}", DateTime.Now);
            //Console.WriteLine("{0:F}", DateTime.Now);
            //Console.WriteLine("{0:g}", DateTime.Now);
            //Console.WriteLine("{0:G}", DateTime.Now);
            //Console.WriteLine("{0:m}", DateTime.Now);
            //Console.WriteLine("{0:M}", DateTime.Now);
            //Console.WriteLine("{0:o}", DateTime.Now);
            //Console.WriteLine("{0:O}", DateTime.Now);
            //Console.WriteLine("{0:r}", DateTime.Now);
            //Console.WriteLine("{0:R}", DateTime.Now);
            //Console.WriteLine("{0:u}", DateTime.Now);
            //Console.WriteLine("{0:U}", DateTime.Now);
            //Console.WriteLine("{0:s}", DateTime.Now);
            //Console.WriteLine("{0:Y}", DateTime.Now);
            //Console.WriteLine("{0:y}", DateTime.Now);
            //#endregion

            //#region Custom Datetime format
            //Console.WriteLine();
            //Console.WriteLine("{0:d}", DateTime.Now);
            //Console.WriteLine("{0:dd}", DateTime.Now);
            //Console.WriteLine("{0:ddd}", DateTime.Now);
            //Console.WriteLine("{0:dddd}", DateTime.Now);

            //Console.WriteLine("{0:f}", DateTime.Now);
            //Console.WriteLine("{0:ff}", DateTime.Now);
            //Console.WriteLine("{0:fff}", DateTime.Now);
            //Console.WriteLine("{0:ffff}", DateTime.Now);
            //Console.WriteLine("{0:fffff}", DateTime.Now);

            //Console.WriteLine("{0:g}", DateTime.Now);
            //Console.WriteLine("{0:HH:mm}", DateTime.Now);
            //Console.WriteLine("{0:m}", DateTime.Now);
            //Console.WriteLine("{0:mm}", DateTime.Now);
            //Console.WriteLine("{0:M}", DateTime.Now);
            //Console.WriteLine("{0:MM}", DateTime.Now);
            //Console.WriteLine("{0:MMM}", DateTime.Now);
            //Console.WriteLine("{0:s}", DateTime.Now);
            //Console.WriteLine("{0:ss}", DateTime.Now);
            //Console.WriteLine("{0:t}", DateTime.Now);
            //Console.WriteLine("{0:tt}", DateTime.Now);
            //Console.WriteLine("{0:y}", DateTime.Now);
            //Console.WriteLine("{0:yy}", DateTime.Now);
            //Console.WriteLine("{0:yyy}", DateTime.Now);
            //Console.WriteLine("{0:yyyy}", DateTime.Now);
            //Console.WriteLine("{0:yyyyy}", DateTime.Now);

            //#endregion

            //#region Enumeration Formatting
            //Parts P = Parts.EAST;
            //Console.WriteLine("{0:D}", P);
            //Console.WriteLine("{0:d}", P);
            //Console.WriteLine("{0:F}", P);
            //Console.WriteLine("{0:f}", P);
            //Console.WriteLine("{0:G}", P);
            //Console.WriteLine("{0:g}", P);
            //Console.WriteLine("{0:X}", P);
            //Console.WriteLine("{0:x}", P);
            //#endregion

            #endregion



            #endregion

            #region THREADS!!!!!!!!!!!!!!!!

            #region Part1


            /*
             * there are 2 types of multitasking:
             * 1.Proccess-based
             * 2.Thread-based
             * 
             * Proccess is a program that is executing
             * (allows to run 2 or more programs concurrently,
             * thus a program is hte smallest unit of code that can be 
             * dispatched by the scheduler)
             * **************************************************************
             * Thread is a dispatchable unit of executable code.
             * program can have multiple threads
             * **************************************************************
             * Proccess based multitasking handles the concurrent execution of
             * programs;
             * Thread-based multitasking deals with concurrent execution of pieces
             * of the same program;
             * Advanrage of multithreading programs they allow to write efficient
             * programs they let to utilize the idle(useless) time.
             * ***************************************************************
             * States of thread:
             * 1.Running:
             *  can be suspended
             *  can be furhter resumed
             *  can be blocked waiting for a resource
             *  can be terminated(cant be further resumed)
             * 2.Ready
             * *********************************************
             * Types of threads:
             * 1 foreground:
             * 2.background:
             * ************************
             * by default it is foreground thread when creating,
             * one can change it to background,the difference is:
             * background thread will be stopped automatically when 
             * all foreground threads in its process have stopped;
             * ******************************************************
             * synchronization:
             * any process has at least one thead of execution - main thread
             * (the one that is executed when the program begins)
             *   ******************************************************
             *   Thread class encapsulated the thread of execution:
             *   Thread th = new Thread(Entry point e.a. delegate);
             *   
             *   delegate to some method
             *   ******************************************************
             *   to run thread use Start() or Start(object o) methods;
             *   once thread has started it will run 
             *   until the entry point method returns then thread automatically stops
             *   once the thread is stopped it cant be Started again
             *   ******************************************************
             *   thre are 2 ways to determine when thread ends:
             *   
             *   1.isAlive boolean property:
             *   
             *   2.Join() mehtod: it blocks the calling thread 
             *   until called thread has terinated
             *   
             *   
             *   
             */

            //MyThread mt1 = new MyThread("Executed thread 1");
            //MyThread mt2 = new MyThread("Executed thread 2");
            //MyThread mt3 = new MyThread("Executed thread 3");

            //while (!mt1.IsJobDone() || !mt2.IsJobDone() || !mt3.IsJobDone())
            //{
            //    Thread.Sleep(100);
            //}

            //mt1.job.Join();
            //mt2.job.Join();
            //mt3.job.Join();

            // to implement method with param pass to overloaded ctor 
            // of thread proper method to delegate
            // and call start(param);

            //MyThread jobWithParam1 = new MyThread("Executed thread 1",4);
            //MyThread jobWithParam2 = new MyThread("Executed thread 2",10);
            //MyThread jobWithParam3 = new MyThread("Executed thread 3",5);

            //jobWithParam1.job.Join();
            //jobWithParam2.job.Join();
            //jobWithParam3.job.Join();

            // to set a thread as background 
            //     jobWithParam1.job.IsBackground = true;
            // it will end when all foreground threads will end up their job

            #region Synchronization

            //int[] arr = { 1, 2, 3, 4, 5 };
            //ArraySummer s1 = new ArraySummer("THREAD#1", arr);
            //ArraySummer s2 = new ArraySummer("THREAD#2", arr);

            //s1.th.Join();
            //s2.th.Join();

            #region Thread communication
            /*
             * if thead T within a lock needs to access to R resource that is 
             * temporariely unaccessible  it can  allow another thread to run 
             * instead of holding the lock and doing nothing within the lock.
             * When the R resource is freed the T thread can be notified
             * and resume execution
             * one thread can notify that it is blocked and be notified when it
             * can resume execution.
             * Wait(),Pulse(),PulseAll() methods defined by the Monitor class
             * they can be called only within a locked blocked of code.
             * when a thread is temporarily blocked from running it calls Wait();
             * it causes thread to sleep and the lock for that object to be released; 
             * allowing another thread to acquire(get) the lock;
             * later the sleeping thread is awakened when some anoter thread
             * enters the same lock and calls Puls() or PulsAll();
             * Puls() resumes the first thread in the queue of threads waiting for
             * the lock. PulseAll() signals the release of the lock to all 
             * waiting threads.
             * if these methods are called not within lock block so then 
             * an exception is thrown
             * 
             */
            //TickTock tt = new TickTock();
            //Clock cl1 = new Clock("Tick", tt);
            //Clock cl2 = new Clock("Tock", tt);

            //cl1.th.Join();
            //cl2.th.Join();

            #endregion

            #region Deadlock and Race Conditions

            /*
             * deadlock is a situation when one thread is waiting for
             * another thread to do something, but another thread is waiting
             * on the first; thus both are suspended waiting for each other
             * and neither executes;
             * 
             * race condition occures when threads attempt to access a shared
             * resource at the same time,without proper synchronization;
             *  For example, one thread may be writing 
                a new value to a variable while another thread is incrementing the variable’s current value. 
            Without synchronization, the new value of the variable will depend on the order in which 
            the threads execute. (Does the second thread increment the original value or the new value 
            written by the first thread?) In situations like this, the two threads are said to be “racing each 
            other,”
             */

            #endregion

            #region Using MethodImplAttibute

            /*
             * to synchronize entire method use 
             * MethodImplAttribute(MethodImplOptions arg) - it a an alternavite to lock when 
             * the emtire body of method content are to be blocked;
             * arg - specifies the implementatino attribute
             * MethodImplOptions.Synchronized causes the entire method
             * to be locked on the instance(that is via this).(in case of
             * static method the type is locked) thus it must not be used on
             * public objects or with a public class
             * 
             */

            #endregion

            #region Using a Mutex and Semaphore

            #region Mutex

            /*
             *   a mutex is mutually exclusive synchronization object.
             *   can be acquired by only one thread at a time.(like lock)
             *   System.Threading.Mutex class:
             *   Mutex(bool iniallyOwned) if is true
             *   the initial state of mutex is owned by the calling thread
             *   Mutex() 
             *   to acquire mutex m.WaitOne() on the mutex;
             *   it blocks the execution of the calling thread 
             *   until the specified mutex is available.
             *   always return true;
             *   ReleaseMutex() to free mutex enabling to be acquired
             *   by another threads;
             *   localy created mutex is known only by the process that
             *   created it;
             *   to create system wide mutex must create a named mutex!!!
             *   public Mutex(bool initiallyOwned,string name)
             *   public Mutex(bool initiallyOwned,string name,out bool createdNew)
             */
            //Mutex m = new Mutex(true);

            // Mutex 

            //m.WaitOne(); // to acquire it,it suspends the calling thread until the mutex acquired

            //// access to shared resource
            //m.ReleaseMutex();// releases mutex

            //SharedResource.Count = 0;
            //IncThread inc = new IncThread("Inc", 5);
            //DecThread dec = new DecThread("Dec", 5);
            //IncThread inc2 = new IncThread("Inc2", 5);

            #endregion

            #region Semaphore
            /*
             * it is the same as mutex but can grant more than one thread access
             * to a shared resource at the same time;
             * it is useful when a collection of resources is being synchronized
             * it controls the access to the shared resource through the
             * the use of a counter;
             * thus to access the resource a thread mest be graned a permit from 
             * the semaphore;
             * it allows access to shared resource through the counter
             * if counter> 0 access is allowed if == 0  denied;
             * if thread acquires the permit(counter>0) then counter decrements
             * otherwise the thread will block until  permit can be acquired;
             * when thread releases the semathore it increments the counter 
             * and another thread acquires access to the shared resource;
             * the numbber of simultaneous access permitted is specified when 
             * semaphore is created.
             * thread trues to acquire a permit
             */

            //Semaphore sem = new Semaphore(2, 2, "Mysem");

            //SemaphoreMyThread s1 = new SemaphoreMyThread("thread 1");
            //SemaphoreMyThread s2 = new SemaphoreMyThread("thread 2");
            //SemaphoreMyThread s3 = new SemaphoreMyThread("thread 3");
            //SemaphoreMyThread s4 = new SemaphoreMyThread("thread 4");

            //s1.thrd.Join();
            //s2.thrd.Join();
            //s3.thrd.Join();
            //s4.thrd.Join();

            //Console.WriteLine(new SemaphoreMyThread("ff"));


            #endregion

            #endregion

            #region Using Events
            /*
             * event type of synchronization;
             * two types of events:
             * manual and auto reset;
             * these classes are used in situations in which one thread is waiting for some 
             * event to occur in another thread;
             * when the event takes place, the second thread signals the first, allowing
             * it to resume execution;
             *  ManualResetEvent m = new ManualResetEvent(bool initialState);
                AutoResetEvent auto = new AutoResetEvent(bool initialState);
                initialState - if true means the event is initially signaled;
                for ManualResetEvent : a thread that is awaiting for some event calls WaitOne() on 
                the event object representing that event.WaitOne() returns immediately if he vent object
                is in a signaled state.
                After  another thread performs the event, that thread sets the event object ot a signaled
                state by calling Set().
                Thus a call Set() signals that an event has occured;
                after event object is set to signaled state the call WaitOne() will return 
                and the first thead will resume execution.The event returned to
                none-signaled state by calling Reset();

                the difference between AutoResetEvent and ManualResetEvent : how the event gets reset;
                ManualResetEvent, the event remains signaled until a call to Reset() is made.
                AutoResetEvent, the event automatically changes to a none-signaled state as soon as
                a thread waiting on the event receives the event notification and resumes execution;
                call to Reset() is not necessary using AutoResetEvent.
             */


            //ManualResetEvent manual = new ManualResetEvent(false);
            //ManualReset m1 = new ManualReset("th1", manual);

            //Console.WriteLine("Main thread waiting for event");

            //manual.WaitOne(0,true); // wait
            //Console.WriteLine("1-st time!!!!!!!!!!!!!");
            //manual.Reset();// reset the event; if auto reset is not necessary

            //m1 = new ManualReset("th2", manual);
            //Console.WriteLine("Main thread waiting for event");

            //manual.WaitOne();
            //Console.WriteLine("2-nd time!!!!!!!!!!!!!");

            #endregion

            #region Interlocked Class
            /*
             * Interlocked
             * garantees that operation is perfomed as a single,
             * uniterruptable, thus no other synchronization is needed
             */

            //InterlockedIncThread th1 = new InterlockedIncThread("th1");
            //InterlockedDecThread th2 = new InterlockedDecThread("th2");

            //th1.th.Join();
            //th2.th.Join();


            #endregion

            // CountdownEvent c = new CountdownEvent(5);// releases a signal when countdown completes
            // Barrier  causes threads to wait at a specified point until all threads arrive

            #endregion

            #region Abort Thread
            /*
             * abort() throws an exception to the thread on which abort() is called;
             * this exception causes the thread to terminate.
             * Abort() doesnt stop thread immediately, to do it immediately
             * use after abort() join();
             * abort(0 should not be used as the normal means of stopping a thread. it s meant for 
             * the specialized situations. because its entry point method returns;
             * Abort() has two overloads with 
             * Abort() and Abort(object stateInfo)
             */

            //MyAbortThread abort = new MyAbortThread("thread_1");

            //Thread.Sleep(2000);
            //// abort.th.Abort();
            //abort.th.Abort(0); // with object
            //// this variable is accessible within ExceptionState variable of the ThreadAbortException instacnce
            //abort.th.Join();

            /// CANCELLING ABORT!!!
            /// 
            /* Thread can override a request to abort;
             * in order to prevent exception from automatic rethrow
             * call ResetAbort()
             */
            #endregion

            // switching the contexts of the threads is the expensive operation
            // well designed programs must have not many threads to operate efficiently'

            //object locker = new object();
            //Mutex m = new Mutex();

            //CountdownEvent c = new CountdownEvent(3);

            //int j = 0;

            //Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        //m.WaitOne();
            //      //  lock (locker)
            //        {
            //            j += i;
            //        }
            //        // m.ReleaseMutex();
            //    }

            //    c.Signal();
            //});

            //Task.Factory.StartNew(() =>
            //{


            //    for (int i = 0; i < 10; i++)
            //    {
            //        // m.WaitOne();
            //        //lock (locker)
            //        {
            //            j += i;
            //        }
            //        // m.ReleaseMutex();
            //    }
            //    c.Signal();
            //});

            //Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(113);
            //    for (int i = 0; i < 10; i++)
            //    {

            //        // m.WaitOne();
            //       // lock (locker)
            //        {
            //            j += i;
            //        }
            //        //m.ReleaseMutex();
            //    }
            //    c.Signal();
            //});

            //Task.Factory.StartNew(() => { c.Wait(); });
            //Task.Factory.StartNew(() => { c.Wait(); });
            //Task.Factory.StartNew(() => { c.Wait(); });

            //c.Wait();

            //Console.WriteLine("end " + j);
            //List<string> lst = new List<string>();
            //int j = 0;

            //CountdownEvent ev = new CountdownEvent(2);
            //Task.Factory.StartNew(() =>
            //{
            //    lock (lst)
            //        for (int i = 0; i < 1000; i++)
            //    {
            //        {
            //            j += i;
            //            Console.WriteLine(j);
            //            Thread.Sleep(10);
            //        }
            //    }
            //    ev.Signal();
            //    ev.Wait();
            //    Console.WriteLine("Over in Thread" + Thread.CurrentThread.ManagedThreadId);

            //});

            //Task.Factory.StartNew(() =>
            //{
            //    lock (lst)
            //        for (int i = 0; i < 1000; i++)
            //    {

            //        {
            //            j -= i;
            //            Console.WriteLine(j);
            //            Thread.Sleep(10);
            //        }
            //    }
            //    ev.Signal();
            //    ev.Wait();
            //    Console.WriteLine("Over in Thread" + Thread.CurrentThread.ManagedThreadId);
            //});

            //Thread.Sleep(1000);
            //lock(lst)
            //for (int i = 0; i < 1000000; i++)
            //{
            //    lst.Add(i.ToString());
            //}

            //ev.Wait();
            ////Thread.Sleep(1);
            //Console.WriteLine(j);

            #endregion

            #region  Separate Task
            /*
             * to start one program within another one use Process class ;
             * public static Process(string name)// name of the executable file 
             * or the file that is associated with an excutable one
             * Close() // frees memory associated with the process;
             * CloseMainWindow() close application with gui;
             * if the application ignores the request it will not be terminated;
             * Kill() causes uncontrolled termination of the process any unsaved data associated with
             * such a process will be lost or WaitForExit() wait until the process will save data and terminate
             * waits for the specified number of milliseconds
             */

            //int i = 0;
            //Process[] col = Process.GetProcesses();
            //foreach (var item in col.OrderBy<Process, long>(x => x.NonpagedSystemMemorySize64))
            //{
            //    try
            //    {
            //        i += item.Threads.Count;
            //        Console.WriteLine(item.ProcessName + "  " + item.NonpagedSystemMemorySize64);
            //        if (item.PrivateMemorySize64 > 838860800)
            //            item.Kill();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //}
            //Console.WriteLine("Threads are running" + i);
            //Process proc = Process.GetProcesses().
            //     Where(x => x.ProcessName.ToLower().StartsWith("STDU".ToLower())).SingleOrDefault<Process>();

            //if (proc != null || !col.Contains<Process>(proc))
            //{
            //    Process p = Process.Start(@"E:\Entity\Entity.pdf");
            //    p.WaitForExit();
            //    p.Close();
            //}

            //Console.WriteLine("Process has ended up");


            #endregion

            #region TPL and PLINQ
            /*
             * two approaches to parallel programming:
             * 1.data parallelism - one operation on a collection of data is
             * broken into two or more concurrent threads, each operation on 
             * the portion of the data, for example:
             * when transformation in the array is needed two or more threads can
             * execute on different ranges of the array;
             * 2.task parallelism - executes two or more operations concurrentlyб
             * the advantage of Task is scalability;
             * Task execution is managed by a task scheduler,
             *  which works with the thread pool, several tasks might share the same 
             *  thread;
             *  
             *  by default the tasks start as background threads
             * 
             *   int? taskOrNot = Task.CurrentId;
             *   returns null if currently executing thread is not a task
             *   otherwise returns the id of the task
             */
            #region   Using Wait Methods
            /*
             * 
             *   wait() it pauses the thread until the invoking task completes
             *   Task.WaitAll(t,t2);
             *   Task.WaitAny(t,t2);
             */

            //DemoThread d = new DemoThread();

            //Action<object> ac = i => { };

            //for (int i = 0; i < 5; i++)
            //{
            //    Thread th = new Thread(() =>
            //    {
            //        d.Do();
            //    });

            //    th.Start();
            //}

            //Task t = new Task(d.Do, 'R');
            //Task t2 = new Task(d.Do, 'E');
            //Task t3 = null;

            //t.Start();
            //t2.Start();

            //try
            //{
            //    t3 = Task.Factory.StartNew(d.Do);

            //    // t.Wait();
            //    // t2.Wait();
            //    Task.WaitAll(t, t2, t3);
            //}
            //catch (ObjectDisposedException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (AggregateException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    foreach (var tsk in new Task[] { t, t2, t3 })
            //    {
            //        if (tsk != null) tsk.Dispose();
            //    }
            //}
            //Console.WriteLine(GC.GetTotalMemory(false));

            #endregion

            #region Create a Task Continuation
            /*
             * task continuation is a task that automatically begins when another
             * task finishes.
             */

            //Task taskContinueWith = new Task( async ()=>
            //{
            //    Mutex m = new Mutex(false, "writerMutex");
            //    Console.WriteLine("Initial task with id: " + Task.CurrentId);
            //    try
            //    {
            //        m.WaitOne();
            //        using (StreamWriter sw =
            //            new StreamWriter(File.OpenWrite(Environment.GetFolderPath( Environment.SpecialFolder.Desktop )+ "\\testFile.txt")))
            //        {
            //            await sw.WriteAsync("ffffffffv dsf sdf  ds v xcv xc vxcv ");
            //            //int i = 0;
            //            //i = 10 / i;
            //        }
            //        Console.WriteLine("I have written");
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //    finally
            //    {
            //        m.ReleaseMutex();
            //    }
            //}
            //);
            //Task newTask = taskContinueWith.ContinueWith(t => 
            //{
            //    try
            //    {
            //        Console.WriteLine("Accepted task with id: "+t.Id);

            //       // Console.WriteLine("Was there exceptions?");
            //        //foreach (var exception in t.Exception.Data.Values)
            //        //{
            //        //    Console.WriteLine(exception);
            //        //}


            //        using (StreamReader sr =
            //         new StreamReader(File.Open(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\testFile.txt", FileMode.Open)))
            //        {
            //            Console.WriteLine(sr.ReadToEnd());
            //        }
            //    }
            //    finally
            //    {
            //        Console.WriteLine("Finished");
            //    }

            //});

            //taskContinueWith.Start();

            //Task.WaitAll(newTask);

            //taskContinueWith.Dispose();
            //newTask.Dispose();

            #endregion

            #region Return a Value from a Task
            /*
             * 1.one can use a task to compute some result.it supports parallel computation
             * 2.calling process will block until the result is ready.NO need to do special
             * synchnonization to wait for the result.
             */

            //Task<int> taskInt = new Task<int>(() => 1);
            //taskInt.Start();
            //taskInt.Wait();
            //Console.WriteLine(taskInt.Result);

            #endregion

            #region Cancelling a Task and Using AggregateException
            /*
             * Cancellation Token are supported by Task class.
             * and thorugh startnew() factory method;
             * 
             * there 3 ways to watch for cancellation:
             * polling
             * using a callback
             * using a wait handle
             * 
             */

            //CancellationTokenSource tokenSource = new CancellationTokenSource();
            //Task TaskCancel = new Task(() =>
            //{
            //    try
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.WriteLine(".");
            //            Thread.Sleep(500);
            //           if(tokenSource.Token.IsCancellationRequested) // polling
            //                tokenSource.Token.ThrowIfCancellationRequested();// if 
            //        }
            //    }
            //    catch(OperationCanceledException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            //}, tokenSource.Token);

            //TaskCancel.Start();
            //Thread.Sleep(2000);
            //tokenSource.Cancel();
            //TaskCancel.Wait();
            //TaskCancel.Dispose();



            //CancellationTokenSource source = new CancellationTokenSource();

            //Task t = new Task(() => {
            //    while (true)
            //    {
            //        Thread.Sleep(100);
            //        Console.WriteLine("!");
            //        source.Token.ThrowIfCancellationRequested();
            //    }
            //}, source.Token);

            //Timer timer = new Timer((obj) => {
            //    CancellationTokenSource token = (CancellationTokenSource)obj;
            //    token.Cancel();

            //        }, source, 2222, 400);

            //t.Start();
            //while (true)
            //{
            //    Thread.Sleep(100);
            //    Console.WriteLine(".");
            //    if (t.IsCanceled)
            //        break;
            //}
            //t.Dispose();
            //timer.Dispose();

            #endregion

            #region Parallelizing Tasks via Invoke(Parallel Class)
            /*
             * it is a static class with methods
             * For(),ForEach(),Invoke();
             * For(),ForEach() - support parallelized loops(data parallelism)
             * invoke supports - task parallelism(concurrent execution of two or more methods);
             * after it executes concurrent execution of methods it waits until all finish its execution
             * no need to call wait();
             * but there is no garantee of multithreading execution because it depents on the 
             * numbe of the processors of the system;also the order of execution cannt be specified
             * and may not be the same as the order of the argument list.
             * 
             * when using invoked the calling thread is blocked until all threads are done in Parallel!!!
             * 
             * parallelizing small loops may create more overhead that the time that is saved;
             * for data parallelism to be effective, the operation being performed must usually be
             * none-trivial. if it isnt the sequential loop can be faster;
             * so the parallel class devides data in different portions so they can be run on 
             * in parallel if the pc has more than one processor;
             */


            //Parallel.Invoke(new Action[]{ MyMeth, MyMeth2});

            //Parallel.ForEach<int>(new int[] { 1, 2, 3, 4, 5 }, i => { i = -i; Console.WriteLine(i); });

            // Parallel.For(1, 100, i => Console.WriteLine(i*100));

            //int[] data = new int[5];
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //ParallelLoopResult res = 
            //    Parallel.For(0, data.Length, (i,currentLoopState) => { data[i] = i; if (i == 100) currentLoopState.Break(); });

            //currentLoopState.Stop() - makes a few iterrations after it was called
            //currentLoopState.Break() - breaks out of a loop
            // a call to break() stopes the loop as soon as possible wich might be a few iterations beyond
            // the one in which break() is called
            // also it runs in parallel so it doesnt mean if it was stopped on the 10th iterration that
            // is has went through the only 10 iterrations
            // such loops are useful for seach data purposes

            //sw.Stop();

            //Console.WriteLine("Parallel initialization of array, time {0}, was it completed? {1}",sw.ElapsedMilliseconds, res.IsCompleted);

            //sw.Reset();

            //sw.Start();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    data[i] = i;
            //}
            //sw.Stop();
            //Console.WriteLine("Sequential initialization of array, time {0}", sw.ElapsedMilliseconds);

            //int sum = 0;
            //Parallel.For(0, data.Length, (i, currentLoopState) =>
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        sum += j;
            //        Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId + " value:" + j);
            //    } });

            //Console.WriteLine("Finish with " + sum);

            #endregion

            #region PLINQ
            /*
             *  Enumerable - not parallel  
                ParallelEnumerable - parallel
             */

            //   int[] pdata = new int[100000];
            //   for (int i = 0; i < pdata.Length; i++)
            //   {
            //       pdata[i] = new Random(i).Next(-100, 100);
            //   }
            //   Console.WriteLine("start selecting...");
            //   CancellationTokenSource s = new CancellationTokenSource();
            ////   Task.Factory.StartNew(() => { Thread.Sleep(100); s.Cancel(); });
            //   try
            //   {
            //       var negative = from val in pdata.AsParallel<int>()
            //                                          .AsOrdered<int>()
            //                                          .WithDegreeOfParallelism(4)
            //                                          .WithCancellation(s.Token)
            //                      where val < 0
            //                      select val;
            //       foreach (var item in negative)
            //       {
            //           Console.WriteLine(item);
            //       }
            //   }
            //   catch (Exception ex)
            //   {
            //       Console.WriteLine(ex.Message);
            //   }


            // the order of found elements can be unpredictable
            // and brings different outcome

            //AsOrdered<int>() to reflect the proper order of the sequence need to use it
            //can be called only on the parallel object because it is parallel query extension

            /*
             * cancelling a parallel query:
             * is similar to cancelling a tas;it relies on the CancellationToker
             * */
            #endregion


            //Task t = new Task(() => Console.WriteLine("Hello world"));
            //t.ContinueWith(x => { Console.WriteLine("yes hello"); Thread.Sleep(1000); });
            //t.Start();

            //Task.WaitAll(t);

            //new Thread(() => { Thread.Sleep(3333); Console.WriteLine("waitiing"); }).Start();

            // Console.ReadKey(true);
            Console.WriteLine("after thread");



            #endregion

            #endregion

            #region Collections

            /*
             * Collection is a group of objects;
             * enumarators and iterators enable the contents of the collections to be cycles through
             * via foreach loop;
             * .NET general types of collections:
             *  -  none-generic,
             *  - specialized
             *  - bit-based
             *  - generic
             *  - concurrent;
             *  none-generic collections are not type safe as they can store references of any type
             *  within object reference(being contravarianced) e.a. operate on data of type object
             *  
             */
            #region None-generic collections

            /* general purpose structures that operate on object references;
             * can store different types of objects within one collection or when
             * the type of object is unknown in advance;
             * these collections are defined by a set of interfaces nad the classes that 
             * implement those interfaces;
             * 
             * None-generic interfaces(they define the functionality to all of the collection classes):
             * ICollection:
             * defines the elements that all non-generic collections must have;
             * since it implements IEnumarable extension methods are defined for it
             * like - asParallel(),AsQuaryable(),Cast(),OfType()
             * 
             * IComparer:
             * defines the Compare() method performing comparasion on objects stored in collection
             * IDictionary:
             * defines a collection that consists of key\value pairs
             * 
             * IDictionaryEnumerator:
             * defines the enumerator for a collection that implements IDictionary;
             * IEnumarable:
             * defines the GetEnumerator() method,which supplies the enumerator for a collection class
             * 
             * IEnumerator:
             * provides methods that enable the contents of a collection to be obtained one at a time;
             * IEqualityComparer:
             * compares two objects for equality;
             * 
             * IList:
             * defines a collection that can be accessed via an indexer;
             * 
             * IDictionary:
             * maps unique keys to values;
             * stores key/values pairs;
             * 
             * Ienumerable:
             * has method GetEnumerator();
             * which returns an object implementing Ienumerator interface
             * this lets a collection to be obtained by a foreach loop;
             *    IDictionaryEnumerator  - enumerator interface for Dictionaries;
             *    it facilitates the enumeration of dictionaries;
             *    
             *    IComparer: 
             *    defines method Compare(object x,object y);
             *    IEqualityComparer:
             *    bool Equals(object x,object y);
             *    int GetHashCode(object obj);
             *    
             *    IStructuralComparable and IStructuralEquatable:
             *    CompareTo() defined a way two objects are structurally compared for purposes of sorting
             *    ( cmopares the contents of the object, not the references);
             *    int CompareTo(object other,IComparer cmp);
             *    
             *    IStructuralEquatable:
             *    bool Equals(object other, IEqualityComparer comparer);
             *    int GetHashCode(IEqualityComparer comparer);
             *    
             *    the none-generic collection classes:
             *    ArrayList - dynamic array
             *    Hashtable - a hash for key/value pair
             *    Queue  -  a first-in,first-out list
             *    SortedList - a sorted list of key/value pairs
             *    Stack  - a first-in , last -out list
             *    Dictionrary<T>
             *    HashSet<T>
             *    SortedList<TKey,TValue>
             *    SortedDictinary<TKey,TValue>
             */

            //ArrayList ar = new ArrayList();
            //ar = ArrayList.Synchronized(ar);

            //SortedList<MyEnumerator, int> dd = new SortedList<MyEnumerator, int>();

            //dd.Add(new MyEnumerator(1), 1);
            //dd.Add(new MyEnumerator(2), 1);

            //Dictionary<int, int> d = new Dictionary<int, int>();

            //foreach (var item in d)
            //{
            //    Console.WriteLine(item);

            //   //int value = d[item];
            //   // d.ElementAt()
            //}
            // searching and sorting arraylist 

            //ArrayList arlst = new ArrayList();
            //for (int i = 0; i < 100; i++)
            //{
            //    arlst.Add(new Random(i).Next(100));
            //}
            //arlst.Add(11);
            //arlst.Sort();
            //Console.WriteLine(" index of value 11 is " + arlst.BinarySearch(11));

            // if the list contains different types of objects like int and string than it would fail
            // because it needs to have some compare object 
            // then it`s needed to supply it with custom comparer object

            /*Hashtable - collection that uses a hash table for storages
             * hash table uses mechanism called hashing
             * content of a key is used to determine the unique value,called its hash code
             * the hash code is used then as index at which the data associated with the key is stored
             * in the table. the transformation of he key into its hash code is performed automatically;
             * The advantage of hashing is that it allows the execution of time of lookup,retrieve
             * and set operations to remain constant,even for large sets;
             * hastable doesnt maintain an ordered collection, there is no specific order
             * to the collection of keys or values obrained.
             */

            //Hashtable ht = new Hashtable();

            //ht.Add("me", "hello");
            //ht.Add("you", "hi");
            //ht.Add("they", "dude");
            //ht.Add("she", "yeah");
            //ht.Add("he", "nice");

            //foreach (var key in ht) // printed without any order because no sorting
            //{
            //    Console.WriteLine(key + "  " + ht[key]);
            //}

            //// generics ArrayList  = linkedList<T>; Hashtable = Dictionary<T>

            //MyEnumerator[] me = new MyEnumerator[] { new MyEnumerator(new int[] { 1, 2, 3 }), new MyEnumerator(new int[] { 11, 22, 32 }) };
            //MyEnumerator[] sec = new MyEnumerator[] { new MyEnumerator(new int[] { 44, 233, 322}), new MyEnumerator(new int[] { 11, 22, 32 }) };


            //Dictionary<int, MyEnumerator> dic = new Dictionary<int, MyEnumerator>();
            //dic.Add(1, new MyEnumerator(new int[] { 1, 2, 3 }));
            //dic.Add(2, new MyEnumerator(new int[] { 4, 5, 6 }));
            //dic.Add(3, new MyEnumerator(new int[] { 7, 8, 9 }));

            //var v =
            //    dic.Select<KeyValuePair<int, MyEnumerator>, KeyValuePair<int, MyEnumerator>>((KeyValuePair<int, MyEnumerator> x) => x);

            //foreach (var item in me.Union(sec))
            //{
            //    Console.WriteLine("UNION:");
            //    foreach (var i in item.i)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //var v2 =
            //     dic.SelectMany<KeyValuePair<int, MyEnumerator>, int>(x => x.Value.i).GroupBy(x => x % 2);

            //foreach (var item in v2)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var itm in item)
            //    {
            //        Console.Write(" " + itm);
            //    }
            //    Console.WriteLine();
            //}

            /* 
             * KeyValuePair<TKey,TValue> Structure
             * is used to store key and its value;
             */


            //MyEnumerator en = new MyEnumerator(new int[] { 1, 2, 3, 4 });
            //foreach (var item in en)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in en)
            //{
            //    Console.WriteLine(item);
            //}


            #endregion

            #region Concurrent collections
            /*
             * BlockingCollection<T>
             * ConcorrentBag<T>
             * ConcurrentDictionary<TKey,TValue>
             *  - queue
             *  - stack;
             *   IProducerConsumerCollection is the interaface 
             *   supports two methods that can work for some parttern like
              producer/consumer one task creates items and the other consumes them;
                      
            when called on bounded collection method add() will block if the collection is full
            when called on unbounded method add() will add item and return;
            when called on an empty collection take() will block until item is availabe
             */

            // when working with generic collections User defined classes in order to be sorted
            // the types of items must implement ICompable<T> or as option IComparer<T>
            // a class that implements this interface with comparation of two objects

            //BlockingDemo.bc = new BlockingCollection<char>(2);

            //Task th = new Task(BlockingDemo.Producer);
            //Task th2 = new Task(BlockingDemo.Consumer);

            //try
            //{
            //    th.Start();
            //    th2.Start();

            //    Task.WaitAll(th, th2);
            //}
            //catch (AggregateException)
            //{

            //}
            //catch (Exception)
            //{

            //}
            //finally
            //{
            //    th.Dispose();
            //    th2.Dispose();
            //    BlockingDemo.bc.Dispose();
            //}

            #endregion

            #region Iterators
            /*
             * an Iterator is a method,operator, or accessor that returns the members of a set of objects
             * one member at one time,from start to finish.
             * it enables to use an object with an iterator to be used in a foreach loop
             * 
             * when creating an iterator the compiler automatically impements an interface to the class(IEnumerable)
             */

            //Myiter<char> iter = new Myiter<char>(new char[] { 'a', 'b', 'c', 'd' });

            //foreach (var item in iter)
            //{
            //    Console.WriteLine(item);
            //}

            //AlphabetStopIterator al = new AlphabetStopIterator();

            //foreach (var item in al)
            //{
            //    Console.WriteLine(item);
            //}

            //AlphabetMultipleReturn mltReturn = new AlphabetMultipleReturn();

            //foreach (var item in mltReturn)
            //{
            //    Console.WriteLine(item);
            //}

            /*
            // stopping an iterator
            // yield break;
            when this statement executes the iterator signals that the end of the collection
            has been reached, which efficiently stopes the iterator
            ********************************************
            * inside iterator function there can be more than one yield return statment
            * each executes one at a time when being called by foreach loop
            * *************************************************
            * named iterator:
            * in this approach one creates a method,  operator, or accessor that returns
            * a reference to an IEnumerable object.Code will use this object to supply the iterator.
            * Named iterator is a method with general form:
            * public IEnumerable itr-name(parameter-list)
            * {
            * ....
            * yield return obj;
            * }
            * Once named iter is created it can be used anywhere,like to control foreach loop
            * args can be passed to iterator that controls waht elements are obtained
            */

            //NamedIter namedIter = new NamedIter();
            //foreach (var item in namedIter.MyIter(10,15))
            //{
            //    Console.WriteLine(item);
            //}

            //MyIter<int> m = new MyIter<int>(new int[] { 1, 2, 3 });

            //foreach (int qwer in m.en(10))
            //{
            //    Console.WriteLine(qwer);
            //}

            #endregion

            #endregion

            #region NetWorking
            //Uniform Resource Identifier
            /* describes the location of some resource in the internet
             * Protocol://HostName/filePath?Query
             * Protocol specifies the protocol being used;
             * HostName identifies the specific server;
             * FilePath  - specific file;
             * if the filePath is not specified then the default page at the specific HostName is 
             * obtained;
             * Query specifies information that will be sent to the server(Optional)
             */

            /*
             *  WebRequest.RegisterPrefix() 
             *  the prefix of the specific protocol 
             *  this approach is benefitial because the code remains the same no matter what type
             *  of protocol you are using
             */

            /*  WebRequest
             * it is abstract since it doesnt implement any specific protocol.
             * to create a request to a URL must create  object derived from WebRequest
             *  with specific protocol
             * */
            //try
            //{


            //    HttpWebRequest r = (HttpWebRequest)WebRequest.Create("https://msdn.microsoft.com/en-us/default.aspx");

            //    r.CookieContainer = new CookieContainer();

            //    HttpWebResponse response = (HttpWebResponse)r.GetResponseAsync().Result;
            //    /*
            //     * WebResponse
            //     * the result of a request;
            //     */
            //   if( response.Headers.Count>0)
            //    {
            //        foreach (var item in response.Headers.AllKeys)
            //        {
            //            Console.WriteLine(item + ":" );
            //            foreach (var pr in response.Headers.GetValues(item))
            //            {
            //                Console.WriteLine(pr);
            //            }
            //        }
            //    }

            //    Console.WriteLine("Last Modified: " + response.LastModified);
                 
            //    Console.WriteLine("cookies:");
            //    foreach (Cookie item in response.Cookies)
            //    {
            //        Console.WriteLine(item.Name + ":" + item.Value);
            //    } 

            //  HttpWebRequest wr = (HttpWebRequest)WebRequest.Create("https://www.google.com.ua/?gfe_rd=cr&ei=g2KHWdTZLe-uyAWJq6zwAg");

            //    HttpWebResponse wrp = (HttpWebResponse)wr.GetResponse();

            //    Stream s = wrp.GetResponseStream();

            //    int ch;
            //    for (int i = 0; ; i++)
            //    {
            //        ch = s.ReadByte();
            //        if (ch == -1) break;
            //        Console.Write((char)ch);

            //    }
            //    wrp.Close(); // it is important to close the response stream!!! 

              

            //}
            //catch(WebException web)
            //{

            //}
            //catch(ProtocolViolationException ex)
            //{

            //}
            //catch (UriFormatException ex)
            //{

            //}
            //catch
            //{

            //}

            //// exception handling

            ///* URI
            // * 
            // */
            //Uri u = new Uri("https://www.google.com.ua/?gfe_rd=cr&ei=g2KHWdTZLe-uyAWJq6zwAg");
            //Console.WriteLine();
            //Console.WriteLine("AbsolutePath:" + u.AbsolutePath);
            //Console.WriteLine("LocalPath:" + u.LocalPath);
            //Console.WriteLine("Host:" + u.Host);
            //Console.WriteLine("Port:" + u.Port);
            //Console.WriteLine("Scheme:" + u.Scheme);
            //Console.WriteLine("Query:" + u.Query);
            //Console.WriteLine("UserInfo:" + u.UserInfo);

            //WebClient client = new WebClient();
            //client.BaseAddress = u.AbsolutePath;
            //var str = client.DownloadString(client.BaseAddress);


            // mini crawler

            string link = null;
            string str;
            string anwser;
            int curloc;
            string uristr = "http://mcgraw-hill.com";

            HttpWebResponse resp = null;
            //try
            //{
            //    do
            //    {
            //        Console.WriteLine("Linking to " + uristr);
            //        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uristr);
            //        uristr = null;
            //        resp = (HttpWebResponse)req.GetResponse();
            //        Stream stream = resp.GetResponseStream();
            //        StreamReader sr = new StreamReader(stream);
            //        str = sr.ReadToEnd();
            //        curloc = 0;

            //        do
            //        {
            //            link = MiniCrawler.FindLink(str, ref curloc);

            //            if (link != null)
            //            {
            //                Console.WriteLine("Linking to " + link);
            //                Console.WriteLine("Link more?");
            //                anwser = Console.ReadLine();
            //                if (anwser.Equals("L"))
            //                {
            //                    uristr = string.Copy(link);
            //                    break;
            //                }
            //                else if (anwser.Equals("Q")) break;
            //                else if (anwser.Equals("M"))
            //                {
            //                    Console.WriteLine("Searchin for another link");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("NO link found");
            //                break;
            //            }
            //        } while (link.Length > 0);
            //        if (resp != null) resp.Close();
            //    } while (uristr != null);

            //}
            //catch
            //{

            //}

            // WebClient
            /*
             * used for donwloading and uploading data from or to the internet
             */
            
            Console.WriteLine("downloading data from " + uristr);

            WebClient w = new WebClient();
            w.DownloadFile(uristr, "data.html");

            Process.Start("data.html");

            int i = 1;
            MiniCrawler.FindLink("", ref i);

            #endregion
        }


        #region WebClasses
        /// <summary>
        /// ttttttttt
        /// 
        /// </summary>
        class MiniCrawler
        {
           /// <summary>
           /// ggg
           /// </summary>
           /// <param name="htmlstr"></param>
           /// <param name="startloc"></param>
           /// <returns>bbbb</returns>
            public static string FindLink(string htmlstr,ref int startloc)
            {
                int i;
                int start, end;
                string uri = null;

                i = htmlstr.IndexOf("href=\"http", startloc, StringComparison.Ordinal);
                //if (i == -1)
                //{
                //    htmlstr.IndexOf("href=", startloc, StringComparison.Ordinal);
                //}

                startloc = i + 1;
                if (i != -1)
                {
                    start = htmlstr.IndexOf('"', i) + 1;
                    end = htmlstr.IndexOf('"', start);
                    uri = htmlstr.Substring(start, end - start);
                }
                return uri;
            }
          
            
        }
        #endregion

        #region Collection Classes
        class MyIter<T>
        {
            T[] t;
            public MyIter(T[]t)
            {
                this.t = t;
            }
            public IEnumerable<T> en(int times)
            {
                for (int i = 0; i < times && i<t.Length; i++)
                {
                    yield return t[i];
                }
            }
        }

        class NamedIter
        {
            char ch = 'A';
            public IEnumerable MyIter(int end)
            {
                for (int i = 0; i < end; i++)
                {
                    yield return (char)(ch+i); 
                }
            }
            public IEnumerable MyIter(int start,int end)
            { 
                for (int i = start; i < end; i++)
                {
                    yield return (char)(ch + i);
                }
            }
        }
        class AlphabetMultipleReturn
        {
            public virtual IEnumerator GetEnumerator()
            {
                yield return 'A';
                yield return 'B';
                yield return 'C';
                yield return 'D';
            }
        }
        class AlphabetStopIterator
        {
            char ch = 'A';
            public virtual IEnumerator GetEnumerator()
            {
                for (int i = 0; i < 26; i++)
                {
                    if (i == 10) yield break;
                    yield return (char)(i + ch);
                }
            }
        }
        class Alphabet
        {
            char ch = 'A';
            public virtual IEnumerator GetEnumerator()
            {
                for (int i = 0; i < 26; i++)
                {
                    yield return (char) (i + ch);
                }
            }
        }

        class Myiter<T>
        {
            T[] collection;

            public Myiter(T[] col)
            {
                this.collection = col;
            }
            public IEnumerator<T> GetEnumerator()
            {
                foreach (T item in collection)
                {
                    yield return item;
                    // yield return  statement returns the next object in a collection
                    // yield is contextual word it has special meaning inside an iterator block
                    // outise an iteratro yield can be used as any other idenfier
                    // iterator doesnt need to be backed by the array
                    // it must return the netxt elment in a group of elements
                    // this means elements can be dynamically constructed using the algorithm
                }
            }
        }
        class BlockingDemo
        {
            public static BlockingCollection<char> bc = null;

            public static void Producer()
            {
                for (char ch = 'A'; ch < 'Z'; ch++)
                {
                    bc.Add(ch);
                    Console.WriteLine("Producing: " + ch);
                }
            }

            public static void Consumer()
            {
                for (int i = 0; i < 26; i++)
                {
                    Console.WriteLine("Consuming: " + bc.Take());
                }
            }
        }

        class Containter<T> : IEnumerable<T>,IEnumerator<T> where T:IEnumerator
        {
            T[] values = default(T[]);
            int current = -1;

            public T Current
            {
                get
                {
                   return values[current];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return values[current];
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                yield return (T)this.values.GetEnumerator();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                current = -1;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                 return values.GetEnumerator();
            }

        }
        class MyEnumerator: IEnumerable,IEnumerator
        {
            int max;
            public int[] i;
            int current = -1;
            public MyEnumerator(int max)
            {
                this.max = max;
                i = new int[max];
            }
            public MyEnumerator(int[] iarr)
            {
                i = iarr;
            }

            public object Current
            {
                get
                {
                   return i[current];
                }
            }

            public IEnumerator GetEnumerator()
            {
                return this;
            }

            public bool MoveNext()
            {
                bool res = (++current) < i.Length;
                if (res)
                    return true;
                else
                {
                  Reset(); // if GetEnumerator returns this then it must Reset() count!!! for this object!!!
               
                    return false;
                }
                
            }

            public void Reset()
            {
                current = -1;      // initial index(if it s array) of enums must be not in range of accessible indexes
            }
        }

        #endregion

        #region Threading Classes2
        static void MyMeth()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("im my meth:" + i++);
                Thread.Sleep(500);
            }
        }
        static void MyMeth2()
        {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("im my MyMeth2:" + i++);
                Thread.Sleep(500);
            }
        }

        class DemoThread
        {
            Mutex m = new Mutex();
            public void Do(object o)
            {

                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("id: " + Task.CurrentId + " value:" + (char)o);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("end");

            }
            public void Do()
            {
                //m.WaitOne();
                //int[] ar = new int[100000000];
                lock (this)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine("id: " + Task.CurrentId??"unknown" + " value: E");
                        Thread.Sleep(300);
                    }
                    Console.WriteLine("end");
                }
               //s m.ReleaseMutex();
            }
        }
        #endregion

        #region Threading Classes1
        //************************Abort******************************
        class MyAbortThread
        {
            public Thread th { get; set; }

            public MyAbortThread(string name)
            {
                th = new Thread(this.Run);
                th.Name = name;
                th.Start();
            }
            void Run()
            {
                try
                {
                    Console.WriteLine("Start thread " + th.Name);
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("...");
                        Thread.Sleep(300);
                    }

                }
                catch (ThreadAbortException ex)
                {

                    Console.WriteLine("exiting on exception  but terminates normally " + ex.ExceptionState);
                    if (((int)ex.ExceptionState) == 0)
                        Thread.ResetAbort();
                    else
                        Console.WriteLine("Will be rethrown automatically");
                    // automatically rethrows exception to stop the thread
                }
                Console.WriteLine("exiting normally!!!!!!!!!!!!!!!!!");

            }
        }
        class Resource
        {
            public int i = 0;
        }
        //************************Interlocked class********************************************
        class SharedInterlockedResource
        {
            public static int count = 0;
        }
        class InterlockedIncThread
        {

            public Thread th;
            public InterlockedIncThread(string name)
            {
                th = new Thread(this.Run);
                th.Name = name;
                th.Start();
            }


            private void Run()
            {
                for (int i = 0; i < 5; i++)
                {
                    Interlocked.Increment(ref SharedResource.Count);
                    Console.WriteLine(th.Name + " count is " + SharedResource.Count);
                }
            }
        }
        class InterlockedDecThread
        {

            public Thread th;
            public InterlockedDecThread(string name)
            {
                th = new Thread(this.Run);
                th.Name = name;
                th.Start();
            }


            private void Run()
            {
                for (int i = 0; i < 5; i++)
                {
                    Interlocked.Decrement(ref SharedResource.Count);
                    Console.WriteLine(th.Name + " count is " + SharedResource.Count);
                }
            }
        }
        //************************Event class********************************************
        class ManualReset
        {
            public Thread Thrd;
            ManualResetEvent mre;
            public ManualReset(string name, ManualResetEvent mre)
            {
                Thrd = new Thread(this.Run);
                Thrd.Name = name;
                this.mre = mre;
                Thrd.Start();
            }

            void Run()
            {
                Console.WriteLine("Inside thread " + Thrd.Name);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(Thrd.Name);
                    Thread.Sleep(400);
                }
                Console.WriteLine(Thrd.Name + " done");
                mre.Set(); // if not to call then deadlock happens
            }
        }
        //****************************Semaphore and Mutex********************************
        class SemaphoreMyThread
        {
            public Thread thrd;
            static Semaphore sem = new Semaphore(2, 2);
            public SemaphoreMyThread(string name)
            {
                thrd = new Thread(this.Run);
                thrd.Name = name;
                thrd.Start();
            }
            void Run()
            {
                // sem.WaitOne();

                Console.WriteLine(thrd.Name + " is waiting for permit");

                Semaphore.OpenExisting("Mysem").WaitOne();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(thrd.Name + " has acquired permit");
                Console.ForegroundColor = ConsoleColor.Gray;

                for (char c = 'A'; c < 'D'; c++)
                {
                    Console.WriteLine(thrd.Name + " : " + c + " ");
                    Thread.Sleep(500);

                }
                Console.WriteLine(thrd.Name + " releases a permit.");

                Semaphore.OpenExisting("Mysem").Release();
                // sem.Release();

            }
        }

        class SharedResource
        {
            public static int Count = 0;
            public static Mutex mtx = new Mutex();
        }
        class IncThread
        {
            int num;
            public Thread Thrd;
            public IncThread(string name, int n)
            {
                this.Thrd = new Thread(this.Run);
                this.Thrd.Name = name;
                num = n;
                this.Thrd.Start();

            }

            private void Run()
            {

                Console.WriteLine(Thrd.Name + " is waiting for mutex");
                SharedResource.mtx.WaitOne();// it is a common Mutex because static

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " thread id;");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(Thrd.Name + " acquired mutex");
                Console.WriteLine("In " + Thrd.Name + ",Initially sharedResource.Count is " + SharedResource.Count);
                do
                {
                    Thread.Sleep(500);
                    SharedResource.Count++;
                    Console.WriteLine("In " + Thrd.Name + ", sharedResource.Count is " + SharedResource.Count);
                    num--;
                } while (num > 0);
                Console.WriteLine("Mutex released in " + Thrd.Name);
                SharedResource.mtx.ReleaseMutex();

            }
        }
        class DecThread
        {
            int num;
            public Thread Thrd;
            public DecThread(string name, int n)
            {
                this.Thrd = new Thread(this.Run);
                this.Thrd.Name = name;
                num = n;
                this.Thrd.Start();
            }

            private void Run()
            {

                Console.WriteLine(Thrd.Name + " is waiting for mutex");

                SharedResource.mtx.WaitOne(); // it is a common Mutex because static

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " thread id;");
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(Thrd.Name + " acquired mutex");
                Console.WriteLine("In " + Thrd.Name + ",Initially sharedResource.Count is " + SharedResource.Count);
                do
                {
                    Thread.Sleep(500);
                    SharedResource.Count--;
                    Console.WriteLine("In " + Thrd.Name + ", sharedResource.Count is " + SharedResource.Count);
                    num--;
                } while (num > 0);
                Console.WriteLine("Mutex released in " + Thrd.Name);

                SharedResource.mtx.ReleaseMutex();

            }
        }

        //************************Lock and Monitor.wait(),pulse()*************************
        //  [MethodImplAttribute(MethodImplOptions.Synchronized)]

        class TickTockFixed
        {
            [MethodImplAttribute(MethodImplOptions.Synchronized)]
            public void Tick(bool running)
            {
                if (!running)
                { // stop the clock
                    Monitor.Pulse(this); // notify any waiting threads
                    return;
                }
                Thread.Sleep(100);
                Console.Write("Tick ");
                Monitor.Pulse(this); // let Tock() run
                Monitor.Wait(this); // wait for Tock() to complete
            }

            [MethodImplAttribute(MethodImplOptions.Synchronized)]
            public void Tock(bool running)
            {
                if (!running)
                { // stop the clock
                    Monitor.Pulse(this); // notify any waiting threads
                    return;
                }
                Thread.Sleep(100);
                Console.WriteLine("Tock");
                Monitor.Pulse(this); // let Tick() run

                Monitor.Wait(this); // wait for Tick() to complete
            }

            [MethodImplAttribute(MethodImplOptions.Synchronized)]
            public void MyTick(bool running, string display)
            {
                if (!running)
                { // stop the clock
                    //Monitor.Pulse(lockOn); // notify any waiting threads
                    return;
                }
                if (Thread.CurrentThread.Name ==
                    "Tick")
                {
                    Monitor.Pulse(this); // let Tick() run
                    Monitor.Wait(this);
                }

                Console.WriteLine(display);
                Monitor.Pulse(this); // let Tick() run
                Monitor.Wait(this); // wait for Tick() to complete
            }
        }
        class MyThreadTickerFixed
        {
            public Thread Thrd;
            TickTockFixed ttOb;
            // Construct a new thread.
            public MyThreadTickerFixed(string name, TickTockFixed tt)
            {
                Thrd = new Thread(this.Run);
                ttOb = tt;
                Thrd.Name = name;
                Thrd.Start();
            }

            // Begin execution of new thread.
            void Run()
            {
                switch (Thrd.Name)
                {
                    case "Tick":
                        for (int i = 0; i < 10; i++) ttOb.Tick(true);
                        ttOb.Tick(false);
                        break;
                    case "Tock":
                        for (int i = 0; i < 10; i++) ttOb.Tock(true);
                        ttOb.Tock(false);
                        break;
                }

                //switch (Thrd.Name)
                //{
                //    case "Tick":
                //        for (int i = 0; i < 100; i++) ttOb.MyTick(true, Thrd.Name);
                //        ttOb.MyTick(false, Thrd.Name);
                //        break;
                //    case "Tock":
                //        for (int i = 0; i < 100; i++) ttOb.MyTick(true, Thrd.Name);
                //        ttOb.MyTick(false, Thrd.Name);
                //        break;
                //}
            }
        }

        class MyThread
        {
            public int sum { private set; get; }
            public string Name
            {
                get { return job.Name; }
                set { job.Name = value; }
            }
            public Thread job { private set; get; }
            const int max = 10;
            public MyThread(string name)
            {
                job = new Thread(this.doJob);
                job.Name = name;
                job.Start();
            }
            public MyThread(string name, int count)
            {
                job = new Thread(this.doJobNTimes);
                job.Name = name;
                // job.IsBackground = true;
                job.Start(count);
            }
            public void doJobNTimes(object o)
            {
                for (sum = 0; sum < (int)o; sum++)
                {
                    Console.WriteLine("id:" +
                   Thread.CurrentThread.ManagedThreadId + " sum:" + sum);
                    Thread.Sleep(500);
                }
            }
            public void doJob()
            {
                for (sum = 0; sum < 10; sum++)
                {
                    Console.WriteLine("id:" +
                   Thread.CurrentThread.ManagedThreadId + " sum:" + sum);
                    Thread.Sleep(500);
                }
            }
            public bool IsJobDone()
            {
                return job.IsAlive;
            }
        }

        class ArrayLogic
        {
            int sum;
            public int DoSumming(int[] arr)
            {
                sum = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Thread {0}; new value {1}; old value {2}",
                        Thread.CurrentThread.Name, sum += i, sum);
                    if (Thread.CurrentThread.Name.Equals("THREAD#1"))
                        Thread.Sleep(50);
                    else
                        Thread.Sleep(30);
                }
                return sum;
            }
        }
        class ArraySummer
        {
            private static ArrayLogic logic = new ArrayLogic();
            int[] arr;
            public Thread th { private set; get; }
            int result;
            public ArraySummer(string name, int[] arr)
            {
                this.th = new Thread(this.DoAction);
                this.th.Name = name;
                this.arr = arr;
                this.th.Start();
            }
            private void DoAction()
            {
                lock (logic) // one can use Monitor class as alternative
                {
                    result = logic.DoSumming(arr);
                    Console.WriteLine("Result {0} in thread:{1}", this.result, Thread.CurrentThread.Name);
                }
            }
        }

        class TickTock
        {
            object lockon = new object();
            public void Tick(bool running)
            {
                lock (lockon)
                {
                    if (!running)
                    {
                        Monitor.Pulse(lockon);// notify any awaiting threads
                        return;
                    }

                    Console.WriteLine("Tick");
                    Monitor.Pulse(lockon);// let Tock() run
                    Monitor.Wait(lockon);//wait for Tock() to complete
                }
            }
            public void Tock(bool running)
            {
                lock (lockon)
                {
                    if (!running)
                    {
                        Monitor.Pulse(lockon);// notify any awaiting threads
                        return;
                    }

                    Console.WriteLine("Tock");
                    Monitor.Pulse(lockon);// let Tock() run
                    Monitor.Wait(lockon);//wait for Tock() to complete
                }
            }
        }
        class Clock
        {
            public Thread th;
            TickTock ttOb;
            public Clock(string name, TickTock tt)
            {
                th = new Thread(this.Run);
                this.ttOb = tt;
                th.Name = name;
                th.Start();
            }
            void Run()
            {
                if (th.Name == "Tick")
                {
                    for (int i = 0; i < 5; i++)
                        ttOb.Tick(true);
                    ttOb.Tick(false);
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                        ttOb.Tock(true);
                    ttOb.Tock(false);
                }
            }
        }

        #endregion



        enum Parts { WEST, EAST, SOUTH, NORTH }
        class MyClassComparable : IComparable<MyClassComparable>
        {
            int value;
            public MyClassComparable(int i)
            {
                value = i;
            }
            public int CompareTo(MyClassComparable other)
            {
                if (other.value == this.value) return 0;
                else if (other.value > this.value) return -1;
                else return 1;
            }
            public override string ToString()
            {
                return value.ToString();

            }
        }

        static int GetZerobalance()
        {
            return 0;
        }
        class ReadOnlyTestClass
        {
            readonly int[] i; // set once the size of array
            public ReadOnlyTestClass(int size)
            {
                this.i = new int[size];
            }
        }
        static class ReadOnlyTestStaticClass
        {
            public readonly static int i = 5; // set once the size of array
        }

        #region LinqClasses
        delegate Tres Del<in Param, out Tres>(Param p);
        class LinqSet<T>
        {

        }
        class subClass
        {

        }
        class Email
        {
            public string name { private set; get; }
            public string email { private set; get; }

            public Email(string name, string email)
            {
                this.name = name;
                this.email = email;
            }
        }
        class ContactList : Email
        {
            public string phoneNumber;
            public ContactList(string name, string email, string phoneNumber) : base(name, email)
            {
                this.phoneNumber = phoneNumber;
            }

        }

        class Transport
        {
            public string How { private set; get; }
            public string Name { private set; get; }
            public Transport(string name, string how)
            {
                Name = name;
                How = how;
            }
        }


        // A class that links an item name with its number.
        class Item
        {
            public string Name { get; set; }
            public int ItemNumber { get; set; }
            public Item(string n, int inum)
            {
                Name = n;
                ItemNumber = inum;
            }
            public Item()
            {

            }
        }
        // A class that links an item number with its in-stock status.
        class InStockStatus
        {
            public int ItemNumber { get; set; }
            public bool InStock { get; set; }
            public InStockStatus(int n, bool b)
            {
                ItemNumber = n;
                InStock = b;
            }
        }
        // A class that encapsulates a name with its status.
        class Temp
        {
            public string Name { get; set; }
            public bool InStock { get; set; }
            public Temp(string n, bool b)
            {
                Name = n;
                InStock = b;
            }
        }


        class PairChar
        {
            char s1;
            char s2;
            public PairChar(char s1, char s2)
            {
                this.s1 = s1;
                this.s2 = s2;
            }
            public override string ToString()
            {
                return s1 + " " + s2;
            }
        }



        #endregion

        #region GenericClasses


        delegate bool MyDelegateCon1<in V>(V param); // can return any derived type and accept
        delegate T MyDelegateCon2<out T, in V>(V param); // can return any derived type and accept

        interface ContraVariance<in T> // contravariance in
        {
            void Do(T param);
        }
        interface CoVariance<out T>
        {
            T getObj();// can return a reference of type T
            // or any derived class from T if out(not sctrict type)
            /* returns a base type and can accept any derived type
             * if it is said to be out!!!
             * */
        }
        interface CoVariance2<out T> : CoVariance<T> // possbile to extend covariant interface
        {
            T getIt();
        }

        class GenCovarince<T> : CoVariance<T>, ContraVariance<T>
        {
            T obj;
            public GenCovarince(T obj)
            {
                this.obj = obj;
            }
            public T getObj()
            {
                return this.obj;
            }
            public override string ToString()
            {
                return obj.ToString();
            }

            public void Do(T param)
            {
                Console.WriteLine("contravarince:" + param.ToString());
            }
        }
        class GenericClassA
        {
            public string s;
            public GenericClassA(string s)
            {
                this.s = s;
            }
            public override string ToString()
            {
                return s;
            }

            public bool IsEqualByValue(GenericClassA obj)
            {
                return this.s == obj.s;
            }
        }
        class GenericClassB : GenericClassA
        {
            public GenericClassB(string s) : base(s)
            {

            }
        }


        ///*********************************



        class MyCoVarianClass<T> : CoVariance<T>
        {
            T obj;
            public MyCoVarianClass(T obj)
            {
                this.obj = obj;
            }
            public T getObj()
            {
                return this.obj;
            }
        }
        class Alfa
        {
            string name;
            public Alfa(string name)
            {
                this.name = name;
            }
            public string getName()
            {
                return name;
            }
        }
        class Beta : Alfa
        {
            public Beta(string name) : base(name)
            {
            }
        }

        class AmbigityM<T, V>
        {
            T obj1;
            V obj2;
            public void set(T obj1)
            {
                this.obj1 = obj1;
            }
            public void set(V obj2)
            {
                this.obj2 = obj2;
            }
        }

        delegate T GenericDelegate<T>(T obj); // where T:class;

        public static bool CompareMethod<T>(T item, T[] items) where T : IComparable<T>
            // thus garantees it`s known how to compare only types that implement IComparable
        {
            for (int i = 0; i < items.Length; i++)
            {
                //if (item == items[i]) // compiler doesnt know precisely how to compare two object of equality

                if (item.CompareTo(items[i]) == 0) // if in list
                    return true;
            }
            return false;
        }
        // event GenericDelegate<string> MyEvent;

        public abstract class PhoneNumber
        {
            public string Name { get; protected set; }
            public string Phone { get; protected set; }
            public PhoneNumber(string Name, string Phone)
            {
                this.Name = Name;
                this.Phone = Phone;
            }
            public override string ToString()
            {
                return String.Format("Name:{0}; Phone:{1} Type:{2}", Name, Phone, this.GetType().Name);
            }
        }

        class Friend : PhoneNumber
        {
            protected bool IsWorkNumber;
            public Friend(string Name, string Phone, bool IsWorkNumber) : base(Name, Phone)
            {
                this.IsWorkNumber = IsWorkNumber;
            }
            public override string ToString()
            {
                return base.ToString() + string.Format(" IsWorkNumber:{0}", IsWorkNumber);
            }

        }

        class Supplier : PhoneNumber
        {
            protected bool IsPermanent;
            public Supplier(string Name, string Phone, bool IsPermanent) : base(Name, Phone)
            {
                this.IsPermanent = IsPermanent;
            }
        }

        class Gen<T, V> where V : T  //  V inherits from T
                       where T : class, new()
        {

        }

        /* parent class constrain enables to access parent properties and methods
         * within derived classed and garantees proper class types be used in place
         * */
        class PhoneList<T> where T : PhoneNumber
        {
            List<T> contacts = new List<T>();
            public PhoneList(T contact)
            {
                contacts.Add(contact);
            }

            public List<T> findByName(string name)
            {
                List<T> found = new List<T>();
                foreach (T cont in this.contacts)
                {
                    if (cont.Name.Equals(name))
                    {
                        found.Add(cont);
                    }
                }
                if (found.Capacity > 0)
                    return found;
                else
                    throw new ContactNotFound();
            }
            public List<T> findByNumber(string number)
            {
                List<T> found = new List<T>();
                foreach (T cont in this.contacts)
                {
                    if (cont.Name.Equals(number))
                    {
                        found.Add(cont);
                    }
                }
                if (found.Capacity > 0)
                    return found;
                else
                    throw new ContactNotFound();
            }
            public static List<T> findByNumber(PhoneList<T> contactList, string number)
            {
                List<T> searched = contactList.contacts;
                List<T> found = new List<T>();
                foreach (T cont in searched)
                {
                    if (cont.Name.Equals(number))
                    {
                        found.Add(cont);
                    }
                }
                return found;
            }
            public void Add(T contact)
            {
                this.contacts.Add(contact);
            }
        }
        class ContactNotFound : Exception
        {
            public ContactNotFound()
            {
            }

            public ContactNotFound(string message) : base(message)
            {
            }

            public ContactNotFound(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ContactNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        class customObj
        {
            public customObj()
            {
                Console.WriteLine("Hello World");
            }
        }
        class C<T> where T : new() // must occupy the last position in the list
        {
            T obj;
            public C()
            {
                obj = new T(); // calling ctor()
            }
        }

        class testGen<T> where T : Stream, new()
        {
            T stream;
            public testGen(T t)
            {
                stream = t;
            }
            public T getStr()
            {
                return stream;
            }
        }
        class GenericClass<Tobj>//T will be replaced by the real parameter
                                // prefix T and decriptive name is a common practice to asign such names
        {
            Tobj obj;

            public GenericClass(Tobj obj)
            {
                this.obj = obj;

            }

            public Tobj getObj()
            {
                return this.obj;
            }

            public void ShowType()
            {
                Console.WriteLine(typeof(Tobj).Name);
            }

        }
        // one can use constraint params to ensure having some proper methods
        // within the class for instance
        class GenClassTwoParams<Tobj, Vobj> where Tobj : class
        {
            Tobj t1;
            Vobj t2;
            public GenClassTwoParams(Tobj t1, Vobj t2)//possible for both 
                                                      //to be the same type like string,string
            {
                this.t1 = t1;
                this.t2 = t2;
            }
            public void ShowTypes()
            {
                Console.WriteLine(t1.GetType().Name);
                Console.WriteLine(t2.GetType().Name);
            }

        }
        class MyReferenceClass<T> where T : class
        {
            T obj;
            public MyReferenceClass()
            {
                obj = null;
            }
        }
        class MyStructClass<T> where T : struct
        {

        }

        class NotGeneric
        {
            int i;
            public NotGeneric(int i = 0)
            {
                this.i = i;
            }
            public virtual string getObjProperties()
            {
                return i.ToString();
            }

        }
        class Generic<T> : NotGeneric // not generic to generic
        {
            T obj;
            IEnumerator<T> en;
            public Generic(T obj) : base(100)
            {
                this.obj = obj;
            }
            public void Do()
            {
            }


        }
        class Hierarchy1<T>
        {
            T obj;
            public Hierarchy1(T obj)
            {
                this.obj = obj;
            }
            public virtual T getObj()
            {
                return this.obj;
            }
            public virtual string ShowValues()
            {
                return obj.ToString();
            }
        }
        class Hierarchy2<T, V> : Hierarchy1<T>
        {
            IEnumerable<T> en;
            V anotherChildElement;
            public Hierarchy2(T obj, V elem) : base(obj)
            {
                anotherChildElement = elem; // an example
            }

            /////so one...
            public override string ShowValues()
            {
                return base.ShowValues() + " " + anotherChildElement.ToString();
            }
        }
        interface GenInterface<T>
        {
            T sum(T par);
        }
        class MyArr<T> : IComparable<MyArr<T>> where T : IComparable<T>
        {
            public T value = default(T);
            public MyArr(T val)
            {
                this.value = val;
            }
            public int CompareTo(MyArr<T> other)
            {
                return this.value.CompareTo(other.value);
            }
            public override string ToString()
            {
                return value.ToString();
            }
            public override bool Equals(object obj)
            {
                MyArr<T> myOjb = obj as MyArr<T>;
                if (myOjb != null)
                    return this.Equals(myOjb);
                return false;
            }
        }
        class P<T> where T : new()
        {
            //  public T obj  = 0;- works only with value type

            //public T obj  = null; - works only with reference type

            public T obj = default(T);// lets asign default value  
        }
        struct Struc<T> where T : struct
        {
            T i1;
            T i2;
            public Struc(T i1, T i2)
            {
                this.i1 = default(T);
                this.i2 = default(T);
            }

        }
        class ArrayCopy
        {
            public static bool CopyInsert<T>(T e, uint index, T[] source, T[] target) where T : new() //- param list
            {
                if (source.Length + 1 > target.Length || index > target.Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                for (int i = 0, j = 0; i < source.Length; i++, j++)
                {
                    if (index == i)
                    {
                        target[j++] = e;
                    }
                    target[j] = source[i];
                }

                if (index == target.Length - 1)
                {
                    target[target.Length - 1] = e;
                }

                return true;
            }
        }
        class GenDelegateDemo
        {
            string s;
            public GenDelegateDemo(string s)
            {
                this.s = s;
            }
            public int AbsNumber(int i)
            {

                return Math.Abs(i);
            }
            public GenDelegateDemo Do(GenDelegateDemo a)
            {
                this.s += a.s;
                return this;
            }
            public override string ToString()
            {
                return base.ToString() + s;
            }
        }
        class Holder : IEnumerable<int>
        {
            private int[] iArr;
            public int[] Arr
            {
                get { return iArr; }
            }
            public Holder(int size)
            {
                iArr = new int[size];
            }
            public Holder()
            {
                iArr = new int[1];
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in iArr)
                {
                    sb.Append(item.ToString() + " ");
                }
                return sb.ToString();
            }

            private class Iterator : IEnumerator<int>
            {
                int size;
                int current;
                int[] Arr;
                public void Dispose()
                {

                }
                public Iterator(int[] iArr)
                {
                    Arr = iArr;
                    size = iArr.Length;
                    current = -1;
                }

                public int Current
                {
                    get { return Arr[current]; }
                }

                int IEnumerator<int>.Current
                {
                    get { return Arr[current]; }
                }

                public bool MoveNext()
                {
                    return ++current < size;
                }

                public void Reset()
                {
                    current = -1;
                }

                object System.Collections.IEnumerator.Current
                {
                    get { throw new NotImplementedException(); }
                }
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new Iterator(this.iArr);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Attribute Classes
        //AttributeTargets.  - can be combined with another options
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.All, AllowMultiple = true, Inherited = true)] // can be applied to all types of items
        // it is possbile to narrow the list of items to which an attribute can be attached
        class RemarkAttribute : Attribute
        {
            private string remark;
            public string supplement; // serves as named parameter
            public int Priority { get; set; }
            public RemarkAttribute(string comment)
            {
                remark = comment;
                supplement = "None";
                Priority = 1;
            }
            public string Remark
            {
                get
                {
                    return remark;
                }
            }
        }

        /* preceeds the item to which it is attached
         * and is specified by enclosing its constructor inside square brackets
         * */
        [RemarkAttribute("it uses an attribute")]

        // not necessary to specify the suffix Attribute
        class UseAttribute
        {

        }

        [RemarkAttribute("it uses an attribute", supplement = "yes", Priority = 25)]
        //positional params come in order in wich they appear
        // named param comes with a specified name within ctor declaration

        class UseAttributeWithNamedParam
        {

        }

        [Obsolete("Old shit")]
        class TestAttribute
        {
            [Conditional("TRIAL")]
            [Obsolete("Use Another Method", false)]

            public void TRIAL() // called only if #define TRIAL
            {
                Console.WriteLine("TRIAL");
            }

            [Conditional("RELEASE")]

            public void RELEASE() // called only if #define RELEASE
            {
                Console.WriteLine("RELEASE");
            }
        }


        #endregion

        #region Classes

        class AnotherClass
        {
            string message;
            public AnotherClass(string str)
            {
                message = str;
            }
            public string Show()
            {
                return message;
            }
        }
        internal class ParentClass
        {
            int i, j;
            public ParentClass(int i = 0)
            {
                this.i = j = i;
            }
            public ParentClass()
            {

            }
            public ParentClass(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
            private Boolean isbetween(int v)
            {
                return v >= i && v <= j;
            }
            public int sum()
            {
                return i + j;
            }
            public void show()
            {
                Console.WriteLine("{0} and {1}", i, j);
            }
            public static void Work(int i)
            {
                Console.WriteLine("Doing work {0}", i);
            }

        }

        internal class ChildClass : ParentClass
        {

        }

        public class TestAccessModifiers
        {
            protected internal int x;// unable outside the program(assembly)
        }

        public static Dictionary<char, int> dictionary = new Dictionary<char, int>();

        public static void HandlerCaller(object o, EventArgs e)
        {
            CustomFormClickArgs clickArg;
            if ((o as Z1) != null)
            {
                clickArg = e as CustomFormClickArgs;
                Console.WriteLine(clickArg);
            }

        }

        public class CustomFormClickArgs : EventArgs
        {
            public int i;
            public CustomFormClickArgs() : base()
            {

            }
            public CustomFormClickArgs(int i)
            {
                this.i = i;
            }
            public override string ToString()
            {
                return "CustomFormClickArgs " + i;
            }
        }

        public class MyClassWithEvent // manual event handling 
        {
            public event Action SomeEvent;
            Stack<Action> stack = new Stack<Action>(3);

            private Action[] arrHandlers = new Action[3];

            public event Action SomeEventManual
            {
                add
                {
                    //int i;
                    //for ( i = 0; i < arrHandlers.Length; ++i)
                    //{
                    //    if (arrHandlers[i] == null)
                    //    {
                    //        arrHandlers[i] = value;
                    //        break;
                    //    }
                    //}
                    //if (i == 3)
                    //    Console.WriteLine("Stack is full");
                    stack.Push(value);

                }// when handler is added by using +=
                remove
                {
                    //int i;
                    //for ( i = 0; i < arrHandlers.Length; ++i)
                    //{
                    //    if (arrHandlers[i] == value)
                    //    {
                    //        arrHandlers[i] = null;
                    //        break;
                    //    }
                    //}
                    //if (i == 3)
                    //    Console.WriteLine("event handler not found!");

                }
                // when handler is removed by using -=
                /* where value is an event handler(function)
                 * here one can define custom event storage scheme
                 * one could use an array,list,stack,queue of handlers
                 * */
            }

            public event Action<X> SomeEvent2;
            public void onSomeEvent()
            {
                SomeEvent.Invoke();
            }

            public void onSomeEvent2(X obj)
            {
                if (SomeEvent2 != null)
                {
                    SomeEvent2.Invoke(obj);
                }
            }
            // event accessors
            public void onSomeEventManual()
            {
                //for (int i = 0; i < arrHandlers.Length; i++)
                //{
                //    if (arrHandlers[i] != null)
                //    {
                //        arrHandlers[i].Invoke();
                //    }
                //}
                foreach (Action item in stack)
                {
                    item.Invoke();
                }

            }

        }
        public class X
        {
            private int i;
            public X()
            {

            }
            public X(int i)
            {
                this.i = i;
            }
            public void AsignNewValue(X obj)
            {
                int old = this.i;
                this.i = obj.i;
                Console.WriteLine("Object : {0}, old value:{1} , new value:{2}", obj.ToString(), old, this.i);
            }
            public void Xhandler()
            {
                Console.WriteLine("Xhandler");
            }
        }
        public class Y
        {
            public void Yhandler()
            {
                Console.WriteLine("Yhandler");
            }
        }
        public abstract class Z
        {
            public abstract event Action MyEvent;
            // pu public event EventHandler Click;blic virtual event Action MyEvent;

        }
        public class Z1 : Z
        {
            // public override event Action MyEvent;
            private static int i = 0;
            public override event Action MyEvent
            {
                add { }
                remove { }
            }
            public event EventHandler Click;
            public event EventHandler<CustomFormClickArgs> ClickWithProperArgs;

            //public void callAsync(AsyncCallback callBack = null,object obj = null)
            //{
            //    Click.BeginInvoke(this, new CustomFormClickArgs(++i), callBack,obj);
            //}
            public void call()
            {
                Click(this, new CustomFormClickArgs(++i));
            }
            public void callProperArgs()
            {
                ClickWithProperArgs(this, new CustomFormClickArgs(5));
            }

        }
        public class Z2
        {
            public delegate void MyDel(object o, CustomFormClickArgs e);
            public event EventHandler<CustomFormClickArgs> OtherEvent;

            public event MyDel MyEvent;
            // use of generics instead of defining own delegate types
            public event EventHandler<CustomFormClickArgs> evnt2;
        }

        /******************************************************/
        public class KeyEventArgs : EventArgs
        {
            public char ch;
            public KeyEventArgs()
            {

            }
            public KeyEventArgs(char ch)
            {
                this.ch = ch;
            }
        }

        public class KeyEventPressed
        {
            public event EventHandler<KeyEventArgs> KeyPressed;
            public void OnKeyPressed(char ch)
            {
                if (KeyPressed != null)
                    KeyPressed.BeginInvoke(this, new KeyEventArgs(ch), null, null);// must have only one target
            }
        }
        /*******************************************************/

        delegate bool lambdaDelegate<Range>(Range value, Range limitLow, Range limitHigh);
        delegate int lambdaDelegate(int i);
        delegate int CountSum(int times);
        delegate void Count(int times);
        delegate void Vd();
        /************************/
        delegate void StringChain(ref string s);
        delegate void MyDelegate();
        delegate string StringAction(string s);
        static CountSum counter()
        {
            int sum = 0;//outer variable - captured variable
            CountSum cs = delegate (int times)
            {
                for (int i = 0; i <= times; ++i)
                {
                    sum += i;
                    Console.WriteLine(i);
                }
                return sum;
            };
            return cs;
        }
        public static void CallDelegete()
        {
            Console.WriteLine("this context Called");
        }
        public static string ReplaceSpaces(string s)
        {
            return s.Replace(' ', '-');
        }
        public static string RemoveSpaces(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                if (!s[i].Equals(' '))
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }
        public static string Reverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; --i)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
    }



    class X
    {
        public int Val;
        public static implicit operator int(X x)
        {
            return x.Val;
        }// just for fun
    }
    class Y : X
    {

    }


    delegate console.X ChangeIt(console.Y obj);
    class Contravariance
    {
        public static console.X incA(console.X obj)
        {
            console.X tmp = new console.X();
            tmp.Val = obj.Val + 1;
            return tmp;
        }
        public static console.Y incB(console.Y obj)
        {
            console.Y tmp = new console.Y();
            tmp.Val = obj.Val + 1;
            return tmp;
        }
    }

    class StringOps
    {
        public string ReplaceSpaces(string s)
        {
            return s.Replace(' ', '-');
        }
        public string RemoveSpaces(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                if (!s[i].Equals(' '))
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }
        public string Reverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; --i)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
    }
    class StringOpsByRef
    {
        public void ReplaceSpaces(ref string s)
        {
            s = s.Replace(' ', '-');
        }
        public void RemoveSpaces(ref string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; ++i)
            {
                if (!s[i].Equals(' '))
                {
                    sb.Append(s[i]);
                }
            }
            s = sb.ToString();
        }
        public void Reverse(ref string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; --i)
            {
                sb.Append(s[i]);
            }
            s = sb.ToString();
        }
    }
    public class Cacl
    {
        public Func<int, int, int> Minus()
        {
            //return new Func<int, int, int>( delegate (int x, int y) { return x - y; });
            return new Func<int, int, int>(delegate (int x, int y) { return x - y; });
        }
        public Func<int, int, int> Plus()
        {
            //return new Func<int, int, int>( delegate (int x, int y) { return x + y; });
            return delegate (int x, int y) { return x + y; };
            // return (x,y) => x + y;
        }
    }
    public class RangeArray : IEnumerator, IEnumerable
    {
        public RangeArray(int lower, int upper)
        {
            if (lower >= upper) throw new OutOfRange("Out of range");
            LowerBound = lower;
            UpperBound = upper;
            arr = new int[++upper - LowerBound];
            Length = UpperBound - LowerBound;
        }

        public int Length { get; private set; }
        int[] arr;
        private int index;
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }

        public int this[int index]
        {
            get
            {
                if (ok(index))
                {
                    return arr[index - LowerBound];
                }
                else
                {
                    throw new OutOfRange("Out of range");
                }
            }
            set
            {
                if (ok(index))
                {
                    arr[index - LowerBound] = value;
                }
                else
                    throw new OutOfRange("Out of range");
            }
        }

        private bool ok(int index)
        {
            if (index >= LowerBound && index <= UpperBound)
                return true;
            else
                return false;
        }

        public object Current
        {
            get
            {
                return arr[index];
            }
        }

        public bool MoveNext()
        {
            return ++index < Length;
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }
    public class DelegateAsync
    {
        public delegate Task myDelAsync();
        myDelAsync del = async delegate () { Thread.Sleep(100); Console.WriteLine("Hello"); };

        public async void CallFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                del += del;
            }
            if (del != null)
            {
                await del();
            }
        }
    }
    class J
    {
        public J()
        {

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(dec);
            doc.AppendChild(doc.CreateElement("Root"));
            doc.Save("my.xml");
        }
    }
    public class OutOfRange : Exception
    {
        protected readonly string message;
        public OutOfRange() : base()
        {

        }
        public OutOfRange(string str) : base(str)
        {
            message = str;
        }
        public OutOfRange(string message, Exception innerException) :
            base(message, innerException)
        {

        }
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}

#endregion
