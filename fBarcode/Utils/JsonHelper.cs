using System;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;


namespace fBarcode.Utils
{
	public static class JsonHelper
	{
		public static JsonSerializerOptions jsonOptions = new JsonSerializerOptions
		{
			WriteIndented = true,
			PropertyNamingPolicy = new FirstLetterLowerCaseNamingPolicy(),
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.All),
			Converters = { new RoundedNumericConverter() }
		};

		private class FirstLetterLowerCaseNamingPolicy : JsonNamingPolicy
		{
			public override string ConvertName(string name)
			{
				if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
				{
					return name;
				}

				return char.ToLower(name[0]) + name.Substring(1);
			}
		}
		private class RoundedNumericConverter : JsonConverter<double>
		{
			public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				// Implementation for deserialization is not needed for this example.
				throw new NotImplementedException();
			}

			public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
			{
				value = Math.Round(value, 2); // Round the value to two decimal places
				writer.WriteNumberValue(value);
			}
		}
	}
}