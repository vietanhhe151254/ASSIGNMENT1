using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObjects;

namespace DataAccess.DAO
{
    public class PublisherDAO
    {
        public static List<Publisher> GetPublishers()
        {
            var publisherList = new List<Publisher>();

            try
            {
                using (var context = new MyDbContext())
                {
                    publisherList = context.Publishers.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publisherList;
        }

        public static Publisher FindPublisherById(int id)
        {
            Publisher publisher = new Publisher();

            try
            {
                using (var context = new MyDbContext())
                {
                    publisher = context.Publishers.SingleOrDefault(p => p.PublisherId==id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return publisher;
        }

        public static void SavePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Publishers.Add(publisher);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while saving the entity changes.", e);
            }

        }

        public static void UpdatePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Publisher>(publisher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeletePublisher(Publisher publisher)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var p = context.Publishers.SingleOrDefault(p => p.PublisherId == publisher.PublisherId);
                    if (p != null)
                    {
                        context.Publishers.Remove(p);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
