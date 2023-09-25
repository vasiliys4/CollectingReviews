using System.ComponentModel.DataAnnotations;

namespace CollectingReviews.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OrganizationName { get; set;}
        public string Address {  get; set;}
        public string GoodFeedback {  get; set;}
        public string BadFeedback {  get; set;}
        public string Coments {  get; set;}
        public int Estimation {  get; set;}
    }
}
