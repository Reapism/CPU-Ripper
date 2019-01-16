using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace CPU_Ripper.util {

    /// <summary>
    /// The <seealso cref="RipperSettings"/> class.
    /// <para>Contains accessor and mutator methods
    /// which control the <seealso cref="Ripper"/> settings.</para>
    /// Using <seealso cref="DataContractJsonSerializer"/> for serialization.
    /// <para>Author: Reapism / Anthony Jaghab (c), all rights reserved.</para>
    /// </summary>

    [DataContract]
    public class RipperSettings {

        /// <summary>
        /// Represents how many tests given (n) iterations to
        /// be used to average the results.
        /// 
        /// The higher, the better.
        /// </summary>
        
        public enum IterationsAverageTests {

            /// <summary>
            /// Results in doing 3 tests of each function.
            /// <para>>> The minimum time to compute given
            /// (n) iterations per function.</para>
            /// </summary>

            Naive,

            /// <summary>
            /// Results in doing 5 tests of each function.
            /// <para>>> Likely will take a while.</para>
            /// </summary>

            Intermediate,

            /// <summary>
            /// Results in doing 10 tests of each function.
            /// <para>>> This will take a very long time depending on
            /// the iterations for each function and what
            /// function.</para>
            /// </summary>

            Competent }

        /// <summary>
        /// Gets the number of iterations per test to average.
        /// </summary>

        public byte AverageIterations { get; set; }

        /// <summary>
        /// The number of iterations for a <seealso cref="System.Collections.Generic.SortedSet{T}"/>
        /// <para>- Includes inserting, deleting, and searching.</para>
        /// </summary>       
        [DataMember(Name = "iter_tree")]
        public ulong IterationsTree { get; set; }

        /// <summary>
        /// The number of iterations for a <seealso cref="System.Collections.Generic.Queue{T}"/>
        /// <para>- Includes adding, removing, searching, and sorting a
        /// <seealso cref="System.Collections.Generic.Queue{T}"/></para>
        /// </summary>
        [DataMember(Name = "iter_queue")]
        public ulong IterationsQueue { get; set; }

        /// <summary>
        /// The number of iterations for a <seealso cref="System.Collections.Generic.LinkedList{T}"/>
        /// <para>- Includes adding, removing, searching, and sorting a 
        /// <seealso cref="System.Collections.Generic.LinkedList{T}"/>.</para>
        /// </summary>
        [DataMember(Name = "iter_linkedlist")]
        public ulong IterationsLinkedList { get; set; }

        /// <summary>
        /// The number of iterations of boolean logic.
        /// </summary>
        [DataMember(Name = "iter_bool")]
        public ulong IterationsBoolean { get; set; }

        /// <summary>
        /// The number of iterations of successorship.
        /// </summary>
        [DataMember(Name = "iter_successor")]
        public ulong IterationsSuccessorship { get; set; }

        /// <summary>
        /// Automatically check for updates when
        /// the program runs.
        /// </summary>
        [DataMember(Name = "auto_updates")]
        public bool AutoCheckForUpdates { get; set; }

        /// <summary>
        /// Preloads all windows, and has them fade in/out.
        /// <para>Allocates resources when initial window loads
        /// to improve performance loading them up in the future.</para>
        /// </summary>
        [DataMember(Name = "fluid_loading")]
        public bool FluidLoading { get; set; }

        /// <summary> Serializes a <seealso cref="RipperSettings"/> class into a JSON.
        /// <para>Internally catches possible exceptions, and if found, returns false.</para>
        /// </summary>
        /// <param name="path">The path to store the JSON.</param>
        /// <param name="obj">The <seealso cref="RipperSettings"/> instance to serialize.</param>

        public static bool SerializeJSON(string path, ref RipperSettings obj) {
            StreamWriter sw;
            MemoryStream ms;
            DataContractJsonSerializer ser;
            byte[] data;
            string utf8String;

            try {
                ser = new DataContractJsonSerializer(typeof(RipperSettings));
                ms = new MemoryStream();
                ser.WriteObject(ms, obj);
                data = ms.ToArray();
                utf8String = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                sw = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                sw.Write(utf8String);
            } catch (Exception) {
                return false;
            }

            ms.Close();
            sw.Close();
            return true;
        }

        /// <summary> Deserializes a <seealso cref="RipperSettings"/> JSON into an instance.
        /// <para>Internally catches possible exceptions, and if found, returns false, and sets
        /// the out <seealso cref="RipperSettings"/> object to null.</para>
        /// </summary>
        /// <param name="path">The path to store the JSON.</param>
        /// <param name="obj">Passing <seealso cref="RipperSettings"/> instance to serialize.</param>

        public static bool DeserializeJSON(string path, out RipperSettings obj) {
            FileStream reader;
            StreamReader sr;
            byte[] bArr;
            MemoryStream ms;
            string utf8Str;
            DataContractJsonSerializer ser;

            try {
                reader = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(reader, System.Text.Encoding.UTF8);
                utf8Str = sr.ReadToEnd();
                bArr = System.Text.Encoding.Unicode.GetBytes(utf8Str);
                ms = new MemoryStream(bArr);
                ser = new DataContractJsonSerializer(typeof(RipperSettings));
                obj = (RipperSettings)ser.ReadObject(ms);
            } catch (Exception) {
                obj = null;
                return false;
            }

            reader.Close();
            sr.Close();
            ms.Close();

            return true;
        }

        /// <summary> Serializes a <seealso cref="RipperSettings"/> class into a JSON.
        /// <para>Internally catches possible exceptions, and if found, returns false.</para>
        /// </summary>
        /// <param name="path">The path to store the JSON.</param>
        /// <param name="obj">The <seealso cref="RipperSettings"/> instance to serialize.</param>

        public static bool SerializeXML(string path, ref RipperSettings obj) {
            StreamWriter sw;
            MemoryStream ms;
            DataContractSerializer ser;
            byte[] data;
            string utf8String;

            try {
                ser = new DataContractSerializer(typeof(RipperSettings));
                ms = new MemoryStream();
                ser.WriteObject(ms, obj);
                data = ms.ToArray();
                utf8String = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                sw = new StreamWriter(path, true, System.Text.Encoding.UTF8);
                sw.Write(utf8String);
            } catch (Exception) {
                return false;
            }

            ms.Close();
            sw.Close();
            return true;
        }

        /// <summary> Deserializes a <seealso cref="RipperSettings"/> JSON into an instance.
        /// <para>Internally catches possible exceptions, and if found, returns false, and sets
        /// the out <seealso cref="RipperSettings"/> object to null.</para>
        /// </summary>
        /// <param name="path">The path to store the JSON.</param>
        /// <param name="obj">Passing <seealso cref="RipperSettings"/> instance to serialize.</param>

        public static bool DeserializeXML(string path, out RipperSettings obj) {
            FileStream reader;
            StreamReader sr;
            byte[] bArr;
            MemoryStream ms;
            string utf8Str;
            DataContractSerializer ser;

            try {
                reader = new FileStream(path, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(reader, System.Text.Encoding.UTF8);
                utf8Str = sr.ReadToEnd();
                bArr = System.Text.Encoding.Unicode.GetBytes(utf8Str);
                ms = new MemoryStream(bArr);
                ser = new DataContractSerializer(typeof(RipperSettings));
                obj = (RipperSettings)ser.ReadObject(ms);
            } catch (Exception) {
                obj = null;
                return false;
            }

            reader.Close();
            sr.Close();
            ms.Close();

            return true;
        }

    }
}
