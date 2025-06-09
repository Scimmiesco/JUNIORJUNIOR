namespace JJ.APPLICATION.DTOs
{
    public class DataResponseDto<T> : ResponseDto
    {
        public T? Data { get; set; }

        public DataResponseDto(T data) : base()
        {
            Data = data;
        }

        public DataResponseDto(string message) : base(message) { }
    }
}
