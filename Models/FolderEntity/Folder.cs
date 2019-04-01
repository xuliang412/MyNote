using Models.NoteEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Folder
    {
        public string FolderId { get; set; }

        public string FolderName { get; set; }

        public string UserId { get; set; }

        public IEnumerable<Note> Notes { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
