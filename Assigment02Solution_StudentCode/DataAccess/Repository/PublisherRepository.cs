using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
using DataAccess.DAO;
using DataAccess.IRepository;

namespace DataAccess.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        public void SavePublisher(Publisher publisher)
        {
            PublisherDAO.SavePublisher(publisher);
        }

        public Publisher GetPublisherById(int id)
        {
            return PublisherDAO.FindPublisherById(id);
        }

        public void DeletePublisher(Publisher publisher)
        {
            PublisherDAO.DeletePublisher(publisher);
        }

        public List<Publisher> GetPublishers()
        {
            return PublisherDAO.GetPublishers();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            PublisherDAO.UpdatePublisher(publisher);
        }
    }
}
