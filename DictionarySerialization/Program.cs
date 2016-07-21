using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DictionarySerialization
{
	[KnownType(typeof(IReadOnlyDictionary<string, string>))]
	public class Sample
	{
		public string SampleProperty1 { get; set; }
		public IReadOnlyDictionary<string, string> SampleProperty2 { get; set; } 
	}

	class Program
	{
		static void Main(string[] args)
		{
			var sampleInstance = new Sample()
			{
				SampleProperty1 = "laskjd",
				SampleProperty2 = new Dictionary<string, string>()
				{
					{"key1", "key2"}
				}
			};

			var serializer = new DataContractJsonSerializer(typeof(Sample));
			string serialized;
			using (var stream = new MemoryStream())
			{
				// This will fail :(
				serializer.WriteObject(stream, sampleInstance);
				serialized = Encoding.UTF8.GetString(stream.ToArray());
			}

			Console.WriteLine(serialized);
			Console.ReadLine();
		}
	}
}
