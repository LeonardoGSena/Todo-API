﻿using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable, IHandler<CreateTodoCommand>, IHandler<UpdateTodoCommand>, IHandler<MarkTodoAsDoneCommand>, IHandler<MarkTodoAsUndoneCommand>
{
    private readonly ITodoRepository _repository;
    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que usa tarefa está errada", command.Notifications);

        // Gera o TodoItem
        var todo = new TodoItem(command.Title, command.User, command.Date);

        // Salvar no banco
        _repository.Create(todo);

        // Retornar o resultado
        return new GenericCommandResult(true, "Tarefa salva!", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que usa tarefa está errada", command.Notifications);

        // Recupera TodoItem (Rehidratação)
        var todo = _repository.GetById(command.Id, command.User);

        //Altera o Titulo
        todo.UpdateTitle(command.Title);

        // Salva no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa atualizada!", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que usa tarefa está errada", command.Notifications);

        // Recupera TodoItem (Rehidratação)
        var todo = _repository.GetById(command.Id, command.User);

        //Altera o estado
        todo.MakeAsDone();

        // Salva no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa concluida!", todo);
    }

    public ICommandResult Handle(MarkTodoAsUndoneCommand command)
    {
        // Fail fast validation
        command.Validate();
        if (command.Invalid)
            return new GenericCommandResult(false, "Ops, parece que usa tarefa está errada", command.Notifications);

        // Recupera TodoItem (Rehidratação)
        var todo = _repository.GetById(command.Id, command.User);

        //Altera o estado
        todo.MakeAsUndone();

        // Salva no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa não concluida!", todo);
    }
}
