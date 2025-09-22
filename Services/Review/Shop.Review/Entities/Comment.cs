namespace Shop.Review.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }

        public string CommentNameSurname { get; set; }

        public string CommentEmail{ get; set; }

        public string CommentDetail { get; set; }

        public int CommentRate{ get; set; }

        public DateTime CommentCreateDate{ get; set; }

        public bool CommentStatus{ get; set; }

        public string ProductID { get; set; }
    }
}
