using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IPublisherRepository
    {
        void SavePublisher(Publisher publisher);
        Publisher GetPublisherById(int id);
        void DeletePublisher(Publisher publisher);
        List<Publisher> GetPublishers();
        void UpdatePublisher(Publisher publisher);
    }
}
