using ApwPayroll_Application.Interfaces.Repositories;
using ApwPayroll_Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDataContext _applicationDataContext;
        public NotificationRepository(ApplicationDataContext applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
        }
        public Task FetchNotification(string id)
        {
            throw new NotImplementedException();
        }
    }
}
