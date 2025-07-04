﻿using KissMediator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.UseCases.Todo.Events
{
    public class TodoCompletedEventHandler : INotificationHandler<TodoCompletedEvent>
    {
        public Task HandleAsync(TodoCompletedEvent notification, CancellationToken cancellationToken)
        {
            //perform some action here
            return Task.CompletedTask;
        }
    }
}
