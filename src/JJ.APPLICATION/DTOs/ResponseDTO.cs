namespace JJ.APPLICATION.DTOs
{
    public class ResponseDto
    {
        public bool Success { get; protected set; } = true;

        public string Message { get; protected set; } = string.Empty;

        public ResponseDto() { }

        public ResponseDto(string message)
        {
            Success = false;
            Message = message;
        }
    }
}