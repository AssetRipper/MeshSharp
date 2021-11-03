using System;

namespace MeshSharp.FBX.Exceptions
{

	[Serializable]
	public class FbxConverterException : Exception
	{
		public FbxConverterException() { }
		public FbxConverterException(string message) : base(message) { }
		public FbxConverterException(string message, Exception inner) : base(message, inner) { }
		protected FbxConverterException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
