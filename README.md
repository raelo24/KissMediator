## Kiss Mediator

This mediator builds on the principle of YAGNI(You Ain't Gonna Need It). So, the implimentation is short and simple for the purpose of mediator design. Any further extension can be done depending on your use cases and project requirements. 

## Usage

All the commands and notifications can be registered automatically alongside their respective handler implementations using

```
    serviceCollection.AddKissMediator();
```

You can create the command handlers this way

``` 
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CreatedTodoResponse>
    {
        public Task<CreatedTodoResponse?> HandleAsync(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            //your implementation here
           ...
        }
    }    
```

...with the commands and response models defined as

```
    public class CreateTodoCommand : IRequest<CreatedTodoResponse>
    {
        public string Name { get; set; }
    }

    public class CreatedTodoResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }   
```

 You can invoke the implemenation by injecting IMediator into any class and then calling

```
    await _mediator.SendAsync(command);
```

## Testing

 The test project covers the unit tests cases to confirm the mediator works fine.

## Licence

This is provided under the MIT Licence


