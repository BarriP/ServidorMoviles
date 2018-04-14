using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Comentario
    {
        public long Id { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
        public long UserId { get; set; }
        public long CommentType { get; set; }
        public long? CommentTargetId { get; set; }

        public Usuario User { get; set; }
    }
}
