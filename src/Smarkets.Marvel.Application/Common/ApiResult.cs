namespace Smarkets.Marvel.Application.Common
{
	public class ApiResult<TResult>
	{
		public int OffSet { get; set; }
		public int Limit { get; set; }
		public int Total { get; set; }
		public int Count { get; set; }
		public TResult Results { get; set; }
	}
}
