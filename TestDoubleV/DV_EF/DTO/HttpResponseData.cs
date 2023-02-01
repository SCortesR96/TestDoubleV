namespace TestDoubleV.DV_EF.DTO
{
    public class HttpResponseData
    {
        /// <summary>
        /// Property used for returning the status of the Http Request
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Property used for giving any important information to show
        /// </summary>
        public dynamic Data { get; set; }
    }
}
