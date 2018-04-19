namespace VideoGameBlog.Data.Responses
{
	public class GenericResponse<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public T Payload { get; set; }
	}
}