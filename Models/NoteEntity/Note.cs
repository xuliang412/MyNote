using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.NoteEntity
{
    public class Note
    {
        public string NoteId { get; set; }

        public string NoteName { get; set; }

        public string UserId { get; set; }

        public string FolderId { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
