using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Task FetchNotification(string id );
    }
}
