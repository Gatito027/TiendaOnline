namespace TiendaOnline.Models.Dto
{
    public class StripeRequestDto
    {
        public string? StripeSessionUrl { get; set; }
        public string? StripeSessionId { get; set; }
        public string ApprovedUrl { get; set; }
        public string CanceldUrl { get; set; }
        public OrderHeaderDto OrderHeaderDto { get; set; }
    }
}
