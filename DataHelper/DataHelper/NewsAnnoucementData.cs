using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper.DataHelper
{
    public class NewsAnnoucementData
    {
        public bool Save(string title, string content)
        {
            int result = 0;
            using (MessagesDataContext c = new MessagesDataContext())
            {
                NewsAndAnnouncement na = new NewsAndAnnouncement();
                na.DateOfPost = DateTime.Now;
                na.Title = title;
                na.Content = content;

                c.NewsAndAnnouncements.InsertOnSubmit(na);
                result = c.GetChangeSet().Inserts.Count;
                c.SubmitChanges();
            }
            return result > 0;
        }

        public bool Update(int recordId, string title, string content)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                NewsAndAnnouncement na = context.NewsAndAnnouncements.FirstOrDefault(c => c.RecordID == recordId);
                if (na != null)
                {
                    na.Title = title;
                    na.Content = content;

                    result = context.GetChangeSet().Updates.Count;
                    context.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            return result > 0;
        }

        public bool Delete(int recordId)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                NewsAndAnnouncement na = context.NewsAndAnnouncements.FirstOrDefault(c => c.RecordID == recordId);
                if (na != null)
                {
                    context.NewsAndAnnouncements.DeleteOnSubmit(na);
                    result = context.GetChangeSet().Deletes.Count;
                    context.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            return result > 0;
        }

        public NewsAndAnnouncement GetOneNewsAndAnnoucement(int recordId)
        {
            NewsAndAnnouncement result = null;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.NewsAndAnnouncements.FirstOrDefault(c => c.RecordID == recordId);
            }
            return result;
        }

        public List<NewsAndAnnouncement> GetTopTen()
        {
            List<NewsAndAnnouncement> result = new List<NewsAndAnnouncement>();
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.NewsAndAnnouncements.Take(10).OrderByDescending(x => x.DateOfPost).ToList();
            }
            return result;
        }
    }
}
