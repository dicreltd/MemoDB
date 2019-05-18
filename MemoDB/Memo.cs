using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoDB
{
    class Memo
    {
        private int mid;
        private string title;
        private string body;
        private DateTime udate;

        public Memo(int mid, string title, string body, DateTime udate)
        {
            this.Mid = mid;
            this.Title = title;
            this.Body = body;
            this.Udate = udate;
        }

        public int Mid { get => mid; set => mid = value; }
        public string Title { get => title; set => title = value; }
        public string Body { get => body; set => body = value; }
        public DateTime Udate { get => udate; set => udate = value; }
    }
}
