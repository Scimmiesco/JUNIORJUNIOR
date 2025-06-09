namespace JJ.APPLICATION.DTOs
{

    public class PaginatedResponseDto<T> : ResponseDto
    {

        public List<T> Data { get; set; } = new List<T>();

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)TotalCount / PageSize) : 0;

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public PaginatedResponseDto(List<T> items, int totalCount, int pageNumber, int pageSize)
            : base()
        {
            Data = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PaginatedResponseDto(string message) : base(message) { }
    }
}
